using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace TDC_data
{
    public partial class Form1 : Form
    {
        SerialPort sp = null;
        bool isOpen = false;
        bool isSetProperty = false;
        private bool Listening = false;//是否没有执行完invoke相关操作  
        private bool Closing = false;//是否正在关闭串口，执行Application.DoEvents，并阻止再次invoke        
        private bool isPlot = false;

        public static int channelcount;
        public static int[] check = { 0, 2, 3, 5 };
        public static Dictionary<int, List<double>> data = new Dictionary<int, List<double>>();
        List<ChannelChart> chart = new List<ChannelChart>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
            chart.Add(channelChart1);
            chart.Add(channelChart2);
            chart.Add(channelChart3);
            chart.Add(channelChart4);

            for (int i = 1; i <= 10; i++)//仅作初始化显示，后面会删除！没有作用。
            {
                cbxCOMPort.Items.Add("COM" + i.ToString());
            }
            cbxCOMPort.SelectedIndex = 0;   //默认显示com1
            tbxChannelCount.Text = "6";
            channelcount = 6;
        }

        private void btnCheckCom_Click(object sender, EventArgs e)
        {
            bool comExistence = false;//有可用串口标志位
            string[] str = SerialPort.GetPortNames();

            if (str == null)
            {
                MessageBox.Show("无可用串口", "Error");
                return;
            }

            //this.tbxRecvData.Text += str.Length+"data";
            this.cbxCOMPort.Items.Clear();              //清楚comport内显示的数据
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cbxCOMPort.Items.Add(s);
                comExistence = true;
            }
        }

        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            if (isOpen == false)
            {
                if (!CheckPortSetting())//检测串口设置
                {
                    MessageBox.Show("串口未设置！", "错误提示");
                    return;
                }

                if (!isSetProperty)//串口未设置则设置串口
                {
                    SetPortProperty();
                    isSetProperty = true;
                }
                try//打开串口
                {
                    sp.Open();
                    isOpen = true;
                    btnOpenCom.Text = "关闭串口";

                    //串口打开后则相关的串口设置按钮便不可再用
                    cbxCOMPort.Enabled = false;
                    Closing = false;
                }
                catch (Exception)
                {
                    //打开串口失败后，相应标志位取消
                    isSetProperty = false;
                    isOpen = false;
                    MessageBox.Show("串口无效或已被占用！", "错误提示");
                }
            }
            else
            {
                Closing = true;
                while (Listening) Application.DoEvents();

                sp.Close();
                isOpen = false;
                isSetProperty = false;
                isPlot = false;
                btnOpenCom.Text = "打开串口";

                //关闭串口后，串口设置选项便可以继续使用
                cbxCOMPort.Enabled = true;


            }
        }

        private bool CheckPortSetting()//检查串口是否设置
        {
            if (cbxCOMPort.Text.Trim() == "") return false;

            return true;
        }

        private void SetPortProperty()//设置串口的属性
        {

            sp = new SerialPort();
            sp.PortName = cbxCOMPort.Text.Trim();//设置串口名
            sp.BaudRate = Convert.ToInt32(921600);//设置串口的波特率
            sp.StopBits = StopBits.One;
            sp.DataBits = Convert.ToInt16(8);//设置数据位
            sp.Parity = Parity.None;

            sp.ReadTimeout = -1;//设置超时读取时间
            sp.RtsEnable = true;
            //定义 DataReceived 事件，当串口收到数据后触发事件
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
        }

        private string inttosting(int data)
        {
            string c = null;
            for (int j = 0; j < 8; j++)
            {
                if ((data >> (7 - j) & 0x01) == 0x01)
                {
                    c += "1 ";
                }
                else
                {
                    c += "0 ";
                }
            }
            return c;
        }

        private string bytetostingHI(byte data)
        {
            string c = null;
            for (int j = 0; j < 4; j++)
            {
                if ((data >> (7 - j) & 0x01) == 0x01)
                {
                    c += "1";
                }
                else
                {
                    c += "0";
                }
            }
            return c;
        }

        private string bytetostingLo(byte data)
        {
            string c = null;
            for (int j = 4; j < 8; j++)
            {
                if ((data >> (7 - j) & 0x01) == 0x01)
                {
                    c += "1";
                }
                else
                {
                    c += "0";
                }
            }
            return c;
        }

        private string stringToBinary(string st)
        {

            int value = Convert.ToInt32(st, 16);

            //string returndata = Convert.ToString(value, 2);
            string returndata = inttosting(value);

            return returndata;
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (Closing) return;//如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环
            try
            {
                Listening = true;//设置标记，说明我已经开始处理数据，一会儿要使用系统UI的。
                System.Threading.Thread.Sleep(500);//延时 100ms 等待接收完数据
                for (int i = 0; i < 4; i++)
                {
                    chart[i].Setbasedata(0.0);
                }

                //this.Invoke 就是跨线程访问 ui 的方法，也是本文的范例
                this.Invoke((EventHandler)(delegate
                {
                    byte[] spData = new byte[sp.BytesToRead]; //创建接收字节数组
                    sp.Read(spData, 0, spData.Length); //读取所接收到的数据                        
                    List<byte> ReceivedData = new List<byte>();
                    if (spData.Length > 150)
                    {
                        for (int i = 0; i < spData.Length; i++)
                        {
                            ReceivedData.Add(spData[i]);
                        }
                        dataHelper(ReceivedData);
                    }
                    else
                    {
                        sp.DiscardInBuffer();//丢弃接收缓冲区数据
                        return;
                    }
                    //RecvDataText += "\r\n";   //单次结束以 回车 作为标志

                    //try
                    //{
                    //    byte[] spData = new byte[sp.BytesToRead]; //创建接收字节数组
                    //    sp.Read(spData, 0, spData.Length); //读取所接收到的数据                        
                    //    List<byte> ReceivedData = new List<byte>();
                    //    if (spData.Length > 150)
                    //    {
                    //        for (int i = 0; i < spData.Length; i++)
                    //        {
                    //            ReceivedData.Add(spData[i]);
                    //        }
                    //        dataHelper(ReceivedData);
                    //    }
                    //    else
                    //    {
                    //        sp.DiscardInBuffer();//丢弃接收缓冲区数据
                    //        return;
                    //    }
                    //    //RecvDataText += "\r\n";   //单次结束以 回车 作为标志
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("接收异常！", "错误提示");
                    //    return;
                    //}

                    //sp.DiscardInBuffer();//丢弃接收缓冲区数据
                    //tbxRecvData.Text = "关闭串口停止接收";
                }));
            }
            finally
            {
                Listening = false;//我用完了，ui可以关闭串口了。  
            }
        }       
        
        private void dataHelper(List<byte> sr)
        {
            int size = sr.Count;
            int aFrame = 8;
            int lastRawDataIndex = 0;
            bool wishSecond7f = false;
            List<byte> frame = new List<byte>();  // 存放一次完整的帧，除开7f，即7字节的帧数据

            int index = 0;
            while (index < size)
            {
                if (aFrame == 8)
                {
                    if (sr[index] == 0x7f)
                        --aFrame;
                    ++index;
                    continue;
                }
                else if (aFrame == 7)
                {
                    if (sr[index] != 0x7f)
                    {
                        frame.Add(sr[index]);
                        --aFrame;
                        ++index;
                    }
                    else
                        aFrame = 8;
                    continue;
                }
                else
                {
                    if (sr[index] == 0x7f)
                    {
                        if (wishSecond7f)
                        {
                            frame.Add(sr[index]);
                            --aFrame;
                            wishSecond7f = false;
                        }
                        else
                        {
                            wishSecond7f = true;
                        }
                    }
                    else
                    {
                        frame.Add(sr[index]);
                        --aFrame;
                    }
                    ++index;
                }
                if (aFrame == 0)
                {
                    print(frame);
                    frame.Clear();
                    aFrame = 8;
                    lastRawDataIndex = index;
                }
            }
            if (lastRawDataIndex == size)
                sr.Clear();
            else
                sr.RemoveRange(0, lastRawDataIndex);
        }

        void print(List<byte> frame)
        {
            if (frame.Count() != 7)
            {
                tbxRecvData.Text = "data error";
                return;
            }

            int channel = frame[0] >> 5; // 获取通道号
            bool flag = false;
            int num = -1;            
            while (!flag && ++num < 4)
            {
                if (chart[num].channel == channel)
                    flag = true;
            }
            if (flag)     //判断是否是需要显示的通道数据
            {
                /** 格雷码转二进制自然数 */
                ulong grayCNT = 0;
                bool pre = ((frame[6] >> 0) & 1) == 1 ? true : false;
                bool highestBit = true; // 判断当前是否为最高位
                /** 处理第39位-第0位 */
                for (int j = 6; j >= 2; --j)
                {
                    for (int k = 0; k < 8; ++k)
                    {
                        bool bitValue = ((frame[j] >> k) & 1) == 1 ? true : false;

                        if (highestBit)
                        {
                            pre = bitValue;
                            highestBit = false;
                        }
                        else pre = pre ^ bitValue;
                        
                        grayCNT = pre ? (grayCNT | 1) : (grayCNT | 0);                        

                        if (j != 2 || k != 7)
                            grayCNT = grayCNT << 1;
                    }
                }

                /** 获取VDL细测量信息 */
                int vdl = 0;
                for (int k = 0; k < 6; ++k)
                {
                    vdl = vdl | ((frame[1] >> k) & 1);
                    if (k != 5)
                        vdl = vdl << 1;
                }

                /** 获取dll粗测量信息 */
                int dll = 0;
                for (int k = 6; k < 8; ++k)
                {
                    dll = dll | ((frame[1] >> k) & 1);
                    dll = dll << 1;
                }
                dll = dll | (frame[0] & 1);

                double time = grayCNT * 10 + dll * 1.25 + vdl * 0.04;
                data[channel].Add(time);
                //tbxRecvData.Text += time + "\r\n";
                if (isPlot)
                    chart[num].paintGraph();
            }

        }       
        
        private void btnCleanData_Click(object sender, EventArgs e)
        {
            tbxRecvData.Text = "";
            isPlot = false;           
            for (int i = 0; i < 4; i++)
            {
                chart[i].tBx_bangaokuan.Text = "";
                chart[i].tBx_fangcha.Text = "";
                chart[i].tBx_junzhi.Text = "";
                chart[i].chart.Series["概率密度"].Points.Clear();
            }
        }

        private void btnpolt_Click(object sender, EventArgs e)
        {
            isPlot = true;
            for (int i = 0; i < 4; i++)
            {
                chart[i].chart.Series["概率密度"].Points.Clear();
                chart[i].SetChannel(-1);
                if (check[i] >= 0)
                {
                    if (!data.ContainsKey(check[i]))
                    {
                        data.Add(check[i], new List<double>());
                    }
                    chart[i].SetChannel(check[i]);
                    //chart[i].paintGraph();
                }
            }
        }

        private void tbnChooseChannel_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void tbxChannelCount_TextChanged(object sender, EventArgs e)
        {
            String str = tbxChannelCount.Text;
            if (str!="") 
            {
                channelcount = int.Parse(str);
            }
        }
    }
}
