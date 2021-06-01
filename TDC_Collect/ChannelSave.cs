using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TDC_Collect
{
    public partial class ChannelSave : UserControl
    {
        public Queue<double> channelData;

        public ChannelSave()
        {
            InitializeComponent();
            // 收集数据的队列
            channelData = new Queue<double>();
        }

        public string ChannelName
        {
            get;
            set;
        }

        private void btnSaveChannel_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileLog = new SaveFileDialog();
            fileLog.Filter = "文本文件|*.txt";
            string strDate = DateTime.Now.ToString("D");
            string strHour = DateTime.Now.ToString("HH");
            string strMin = DateTime.Now.ToString("mm");
            string strSec = DateTime.Now.ToString("ss");
            fileLog.FileName = "log_" + this.ChannelName + "_" + strDate + strHour + strMin + strSec;
            if (fileLog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter mySw = File.CreateText(fileLog.FileName);
                foreach (double obj in channelData)
                {
                    mySw.WriteLine(obj);
                }
                mySw.Flush();
                mySw.Close();
                MessageBox.Show("已保存日志", "提示");
            }
        }
    }
}
