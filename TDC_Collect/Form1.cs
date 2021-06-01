using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; // 串口包
using System.Collections;

namespace TDC_Collect
{
    public partial class Form1 : Form
    {
        private SerialPort sp;
        private ArrayList undealData; // 负责处理上次未处理完成的数据
        private bool isStartSave; // 是否开始保存
        private int savedNums; // 保存的数目


        public Form1()
        {
            InitializeComponent();

            btnOpen.BackColor = Color.LightGray;
            btnOpen.ForeColor = Color.Black;

            btnScan.BackColor = Color.LightGray;
            btnScan.ForeColor = Color.Black;

            undealData = new ArrayList();

            isStartSave = false;

            sp = new SerialPort
            {
                BaudRate = Convert.ToInt32(921600),//设置串口的波特率
                StopBits = StopBits.One,
                DataBits = Convert.ToInt16(8),//设置数据位
                Parity = Parity.None,
                ReadTimeout = -1,//设置超时读取时间
                RtsEnable = true,
                ReceivedBytesThreshold = 1
            };
            //定义 DataReceived 事件，当串口收到数据后触发事件
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);

            channelSave0.ChannelName = channelSave0.Name;
            channelSave2.ChannelName = channelSave2.Name;
            channelSave3.ChannelName = channelSave3.Name;
            channelSave5.ChannelName = channelSave5.Name;

            channelSave0.lbChannel.Text = "0";
            channelSave2.lbChannel.Text = "2";
            channelSave3.lbChannel.Text = "3";
            channelSave5.lbChannel.Text = "5";

            channelSave0.btnSaveChannel.Enabled = false;
            channelSave2.btnSaveChannel.Enabled = false;
            channelSave3.btnSaveChannel.Enabled = false;
            channelSave5.btnSaveChannel.Enabled = false;

            savedNums = 0;


        }

        private void dataHelper(ref byte[] receievedData, int numBytesRead)
        {
            for (int i = 0; i < numBytesRead; ++i)
            {
                undealData.Add(receievedData[i]);
            }

            int size = undealData.Count;
            int aFrame = 8;
            int lastRawDataIndex = 0;
            bool wishSecond7f = false;
            ArrayList frame = new ArrayList(); // 存放一次完整的帧，除开7f，即7字节的帧数据

            int index = 0;
            while (index < size)
            {
                if (aFrame == 8)
                {
                    if ((byte)undealData[index] == 0x7f)
                        --aFrame;
                    ++index;
                    continue;
                }
                else if (aFrame == 7)
                {
                    if ((byte)undealData[index] != 0x7f)
                    {
                        frame.Add(undealData[index]);
                        --aFrame;
                        ++index;
                    }
                    else
                        aFrame = 8;
                    continue;
                }
                else
                {
                    if ((byte)undealData[index] == 0x7f)
                    {
                        if (wishSecond7f)
                        {
                            frame.Add(undealData[index]);
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
                        frame.Add(undealData[index]);
                        --aFrame;
                    }
                    ++index;
                }
                if (aFrame == 0)
                {
                    // 处理
                    tackleData(frame);
                    frame.Clear();
                    aFrame = 8;
                    lastRawDataIndex = index;
                }
            }

            if (lastRawDataIndex == size)
                undealData.Clear();
            else
            {
                undealData.RemoveRange(0, lastRawDataIndex);
            }

        }


        private void tackleData(ArrayList frame)
        {
            if (frame.Count != 7)
            {
                return;
            }

            int channel = (byte)frame[0] >> 5; // 获取通道号

            if (channel != 0 && channel != 2 && channel != 3 && channel != 5)
            {
                return;
            }

            /** 格雷码转二进制自然数 */
            ulong grayCNT = 0;
            ulong pre = 0;
            bool highestBit = true; // 判断当前是否为最高位
            /** 处理第39位-第0位 */
            for (int j = 6; j >= 2; --j)
            {
                for (int k = 0; k < 8; ++k)
                {
                    ulong bitValue = (ulong)(((byte)frame[j] >> k) & 1);

                    if (highestBit)
                    {
                        pre = bitValue;
                        highestBit = false;
                    }
                    else pre = pre ^ bitValue;

                    grayCNT = grayCNT | pre;
                    if (j != 2 || k != 7)
                        grayCNT = grayCNT << 1;
                }
            }

            /** 获取VDL细测量信息 */
            uint vdl = 0;
            for (int k = 0; k < 6; ++k)
            {
                vdl = vdl | (uint)(((byte)frame[1] >> k) & 1);
                if (k != 5)
                    vdl = vdl << 1;
            }


            /** 获取dll粗测量信息 */
            uint dll = 0;
            for (int k = 6; k < 8; ++k)
            {
                dll = dll | (uint)(((byte)frame[1] >> k) & 1);
                dll = dll << 1;
            }
            dll = dll | (uint)((byte)frame[0] & 1);

            double time = grayCNT * 10 + dll * 1.25 + vdl * 0.04;

            switch (channel)
            {
                case 0:
                    {
                        int dataCount = channelSave0.channelData.Count;
                        if (dataCount < savedNums)
                        {
                            channelSave0.channelData.Enqueue(time);
                            ++dataCount;
                            channelSave0.tbxSavedNums.Invoke((EventHandler)delegate
                            {
                                channelSave0.tbxSavedNums.Text = "已存: " + dataCount + " 个数据";
                            });
                        }
                        break;
                    }
                case 2:
                    {
                        int dataCount = channelSave2.channelData.Count;
                        if (dataCount < savedNums)
                        {
                            channelSave2.channelData.Enqueue(time);
                            ++dataCount;
                            channelSave2.tbxSavedNums.Invoke((EventHandler)delegate
                            {
                                channelSave2.tbxSavedNums.Text = "已存: " + dataCount + " 个数据";
                            });
                        }
                        break;
                    }
                case 3:
                    {
                        int dataCount = channelSave3.channelData.Count;
                        if (dataCount < savedNums)
                        {
                            channelSave3.channelData.Enqueue(time);
                            ++dataCount;
                            channelSave3.tbxSavedNums.Invoke((EventHandler)delegate
                            {
                                channelSave3.tbxSavedNums.Text = "已存: " + dataCount + " 个数据";
                            });
                        }
                        break;
                    }
                case 5:
                    {
                        int dataCount = channelSave5.channelData.Count;
                        if (dataCount < savedNums)
                        {
                            channelSave5.channelData.Enqueue(time);
                            ++dataCount;
                            channelSave5.tbxSavedNums.Invoke((EventHandler)delegate
                            {
                                channelSave5.tbxSavedNums.Text = "已存: " + dataCount + " 个数据";
                            });
                        }
                        break;
                    }
                default:
                    break;
            }
            
        }

        private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp.BytesToRead < 8 || !isStartSave) // 如果缓冲区字节数低
            {
                return;
            }
            byte[] receivedData = new byte[sp.BytesToRead];
            sp.Read(receivedData, 0, receivedData.Length);
            dataHelper(ref receivedData, receivedData.Length);

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!sp.IsOpen) // 若串口未打开，则设置串口属性再打开
            {
                if (cobxSerialPort.Text.Length == 0) // 如果串口为空
                {
                    MessageBox.Show("串口为空");
                }
                else // 如果串口不为空
                {
                    sp.PortName = cobxSerialPort.Text; // 设置串口名
                    sp.Open();
                    btnOpen.Text = "关闭串口";
                    btnOpen.BackColor = Color.Green;
                    btnOpen.ForeColor = Color.White;
                }
            }
            else
            {
                sp.Close();
                btnOpen.Text = "打开串口";
                btnOpen.BackColor = Color.LightGray;
                btnOpen.ForeColor = Color.Black;
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            cobxSerialPort.Items.Clear(); // 每次扫描前先清除旧的串口，防止存在不能用的串口
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length == 0)
            {
                MessageBox.Show("无可用串口", "串口", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cobxSerialPort.Items.AddRange(ports);
            cobxSerialPort.SelectedIndex = 0;
            cobxSerialPort.Text = cobxSerialPort.SelectedItem.ToString(); // 默认第一项为comboBox的值
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isStartSave) // 如果保存按键没按下
            {
                if (tbxNums.Text.Trim().Length == 0)
                {
                    MessageBox.Show("请设置保存数目");
                    return;
                }
                else
                {
                    btnClear.Enabled = false;
                    int tbxNumsTextToInt = Convert.ToInt32(this.tbxNums.Text.Trim());
                    savedNums = tbxNumsTextToInt > 1000 ? 1000 : tbxNumsTextToInt;
                    /* 设置保存键按下后的样式
                     */
                    isStartSave = true;
                    btnSave.Text = "停止保存";
                    btnSave.BackColor = Color.LightGreen;
                    tbxNums.Enabled = false;

                    channelSave0.btnSaveChannel.Enabled = false;   
                    channelSave2.btnSaveChannel.Enabled = false;
                    channelSave3.btnSaveChannel.Enabled = false;
                    channelSave5.btnSaveChannel.Enabled = false;

                }
            }
            else // 如果已经在保存
            {
                btnClear.Enabled = true;
                tbxNums.Enabled = true;
                channelSave0.btnSaveChannel.Enabled = true;
                channelSave2.btnSaveChannel.Enabled = true;
                channelSave3.btnSaveChannel.Enabled = true;
                channelSave5.btnSaveChannel.Enabled = true;

                isStartSave = false;
                btnSave.Text = "开始保存";
                btnSave.BackColor = Color.LightGray;
            }
            
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            channelSave0.channelData.Clear();
            channelSave2.channelData.Clear();
            channelSave3.channelData.Clear();
            channelSave5.channelData.Clear();

            tbxNums.Text = "";

            channelSave0.tbxSavedNums.Text = "";
            channelSave2.tbxSavedNums.Text = "";
            channelSave3.tbxSavedNums.Text = "";
            channelSave5.tbxSavedNums.Text = "";

            channelSave0.btnSaveChannel.Enabled = false;
            channelSave2.btnSaveChannel.Enabled = false;
            channelSave3.btnSaveChannel.Enabled = false;
            channelSave5.btnSaveChannel.Enabled = false;
        }
    }
}
