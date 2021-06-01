namespace TDC_data
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxCOMPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxRecvData = new System.Windows.Forms.TextBox();
            this.btnCheckCom = new System.Windows.Forms.Button();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.btnCleanData = new System.Windows.Forms.Button();
            this.btnPolt = new System.Windows.Forms.Button();
            this.tbnChooseChannel = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.tbxChannelCount = new System.Windows.Forms.TextBox();
            this.channelChart1 = new TDC_data.ChannelChart();
            this.channelChart2 = new TDC_data.ChannelChart();
            this.channelChart3 = new TDC_data.ChannelChart();
            this.channelChart4 = new TDC_data.ChannelChart();
            this.SuspendLayout();
            // 
            // cbxCOMPort
            // 
            this.cbxCOMPort.FormattingEnabled = true;
            this.cbxCOMPort.Location = new System.Drawing.Point(412, 26);
            this.cbxCOMPort.Name = "cbxCOMPort";
            this.cbxCOMPort.Size = new System.Drawing.Size(92, 20);
            this.cbxCOMPort.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // tbxRecvData
            // 
            this.tbxRecvData.BackColor = System.Drawing.SystemColors.Control;
            this.tbxRecvData.Location = new System.Drawing.Point(17, 7);
            this.tbxRecvData.Multiline = true;
            this.tbxRecvData.Name = "tbxRecvData";
            this.tbxRecvData.ReadOnly = true;
            this.tbxRecvData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxRecvData.Size = new System.Drawing.Size(171, 59);
            this.tbxRecvData.TabIndex = 2;
            // 
            // btnCheckCom
            // 
            this.btnCheckCom.Location = new System.Drawing.Point(288, 26);
            this.btnCheckCom.Name = "btnCheckCom";
            this.btnCheckCom.Size = new System.Drawing.Size(75, 23);
            this.btnCheckCom.TabIndex = 95;
            this.btnCheckCom.Text = "串口检测";
            this.btnCheckCom.UseVisualStyleBackColor = true;
            this.btnCheckCom.Click += new System.EventHandler(this.btnCheckCom_Click);
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(510, 24);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCom.TabIndex = 96;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // btnCleanData
            // 
            this.btnCleanData.Location = new System.Drawing.Point(197, 26);
            this.btnCleanData.Name = "btnCleanData";
            this.btnCleanData.Size = new System.Drawing.Size(75, 23);
            this.btnCleanData.TabIndex = 98;
            this.btnCleanData.Text = "清空接收区";
            this.btnCleanData.UseVisualStyleBackColor = true;
            this.btnCleanData.Click += new System.EventHandler(this.btnCleanData_Click);
            // 
            // btnPolt
            // 
            this.btnPolt.Font = new System.Drawing.Font("宋体", 15F);
            this.btnPolt.Location = new System.Drawing.Point(787, 8);
            this.btnPolt.Name = "btnPolt";
            this.btnPolt.Size = new System.Drawing.Size(128, 54);
            this.btnPolt.TabIndex = 99;
            this.btnPolt.Text = "绘图";
            this.btnPolt.UseVisualStyleBackColor = true;
            this.btnPolt.Click += new System.EventHandler(this.btnpolt_Click);
            // 
            // tbnChooseChannel
            // 
            this.tbnChooseChannel.Location = new System.Drawing.Point(698, 22);
            this.tbnChooseChannel.Name = "tbnChooseChannel";
            this.tbnChooseChannel.Size = new System.Drawing.Size(75, 23);
            this.tbnChooseChannel.TabIndex = 100;
            this.tbnChooseChannel.Text = "选择通道";
            this.tbnChooseChannel.UseVisualStyleBackColor = true;
            this.tbnChooseChannel.Click += new System.EventHandler(this.tbnChooseChannel_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(602, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 101;
            this.label22.Text = "通道数";
            // 
            // tbxChannelCount
            // 
            this.tbxChannelCount.Location = new System.Drawing.Point(643, 24);
            this.tbxChannelCount.Name = "tbxChannelCount";
            this.tbxChannelCount.Size = new System.Drawing.Size(49, 21);
            this.tbxChannelCount.TabIndex = 102;
            this.tbxChannelCount.TextChanged += new System.EventHandler(this.tbxChannelCount_TextChanged);
            // 
            // channelChart1
            // 
            this.channelChart1.Location = new System.Drawing.Point(17, 72);
            this.channelChart1.Name = "channelChart1";
            this.channelChart1.Size = new System.Drawing.Size(456, 257);
            this.channelChart1.TabIndex = 107;
            // 
            // channelChart2
            // 
            this.channelChart2.Location = new System.Drawing.Point(479, 72);
            this.channelChart2.Name = "channelChart2";
            this.channelChart2.Size = new System.Drawing.Size(456, 257);
            this.channelChart2.TabIndex = 108;
            // 
            // channelChart3
            // 
            this.channelChart3.Location = new System.Drawing.Point(17, 335);
            this.channelChart3.Name = "channelChart3";
            this.channelChart3.Size = new System.Drawing.Size(456, 257);
            this.channelChart3.TabIndex = 109;
            // 
            // channelChart4
            // 
            this.channelChart4.Location = new System.Drawing.Point(479, 335);
            this.channelChart4.Name = "channelChart4";
            this.channelChart4.Size = new System.Drawing.Size(456, 257);
            this.channelChart4.TabIndex = 110;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(957, 602);
            this.Controls.Add(this.channelChart4);
            this.Controls.Add(this.channelChart3);
            this.Controls.Add(this.channelChart2);
            this.Controls.Add(this.channelChart1);
            this.Controls.Add(this.tbxChannelCount);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.tbnChooseChannel);
            this.Controls.Add(this.btnPolt);
            this.Controls.Add(this.btnCleanData);
            this.Controls.Add(this.btnOpenCom);
            this.Controls.Add(this.btnCheckCom);
            this.Controls.Add(this.tbxRecvData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxCOMPort);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TDC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCOMPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxRecvData;
        private System.Windows.Forms.Button btnCheckCom;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.Button btnCleanData;
        private System.Windows.Forms.Button btnPolt;
        private System.Windows.Forms.Button tbnChooseChannel;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tbxChannelCount;
        private ChannelChart channelChart1;
        private ChannelChart channelChart2;
        private ChannelChart channelChart3;
        private ChannelChart channelChart4;
    }
}

