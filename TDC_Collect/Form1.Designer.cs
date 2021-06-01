namespace TDC_Collect
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
            this.gpPort = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.cobxSerialPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpSave = new System.Windows.Forms.GroupBox();
            this.channelSave5 = new TDC_Collect.ChannelSave();
            this.channelSave3 = new TDC_Collect.ChannelSave();
            this.channelSave2 = new TDC_Collect.ChannelSave();
            this.channelSave0 = new TDC_Collect.ChannelSave();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxNums = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gpPort.SuspendLayout();
            this.gpSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpPort
            // 
            this.gpPort.Controls.Add(this.btnOpen);
            this.gpPort.Controls.Add(this.btnScan);
            this.gpPort.Controls.Add(this.cobxSerialPort);
            this.gpPort.Controls.Add(this.label1);
            this.gpPort.Location = new System.Drawing.Point(22, 21);
            this.gpPort.Name = "gpPort";
            this.gpPort.Size = new System.Drawing.Size(451, 123);
            this.gpPort.TabIndex = 0;
            this.gpPort.TabStop = false;
            this.gpPort.Text = "串口控制";
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpen.Location = new System.Drawing.Point(155, 66);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(91, 30);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "打开串口";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(36, 65);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(91, 33);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "扫描串口";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // cobxSerialPort
            // 
            this.cobxSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobxSerialPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cobxSerialPort.FormattingEnabled = true;
            this.cobxSerialPort.Location = new System.Drawing.Point(90, 25);
            this.cobxSerialPort.Name = "cobxSerialPort";
            this.cobxSerialPort.Size = new System.Drawing.Size(136, 24);
            this.cobxSerialPort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // gpSave
            // 
            this.gpSave.Controls.Add(this.channelSave5);
            this.gpSave.Controls.Add(this.channelSave3);
            this.gpSave.Controls.Add(this.channelSave2);
            this.gpSave.Controls.Add(this.channelSave0);
            this.gpSave.Controls.Add(this.btnClear);
            this.gpSave.Controls.Add(this.label2);
            this.gpSave.Controls.Add(this.tbxNums);
            this.gpSave.Controls.Add(this.btnSave);
            this.gpSave.Location = new System.Drawing.Point(22, 150);
            this.gpSave.Name = "gpSave";
            this.gpSave.Size = new System.Drawing.Size(754, 441);
            this.gpSave.TabIndex = 10;
            this.gpSave.TabStop = false;
            this.gpSave.Text = "保存";
            // 
            // channelSave5
            // 
            this.channelSave5.ChannelName = null;
            this.channelSave5.Location = new System.Drawing.Point(49, 301);
            this.channelSave5.Name = "channelSave5";
            this.channelSave5.Size = new System.Drawing.Size(579, 59);
            this.channelSave5.TabIndex = 23;
            // 
            // channelSave3
            // 
            this.channelSave3.ChannelName = null;
            this.channelSave3.Location = new System.Drawing.Point(49, 236);
            this.channelSave3.Name = "channelSave3";
            this.channelSave3.Size = new System.Drawing.Size(579, 59);
            this.channelSave3.TabIndex = 23;
            // 
            // channelSave2
            // 
            this.channelSave2.ChannelName = null;
            this.channelSave2.Location = new System.Drawing.Point(49, 171);
            this.channelSave2.Name = "channelSave2";
            this.channelSave2.Size = new System.Drawing.Size(579, 59);
            this.channelSave2.TabIndex = 23;
            // 
            // channelSave0
            // 
            this.channelSave0.ChannelName = null;
            this.channelSave0.Location = new System.Drawing.Point(49, 106);
            this.channelSave0.Name = "channelSave0";
            this.channelSave0.Size = new System.Drawing.Size(579, 59);
            this.channelSave0.TabIndex = 22;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(498, 40);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 30);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "清除保存";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(86, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 19);
            this.label2.TabIndex = 20;
            this.label2.Text = "设置保存的个数";
            // 
            // tbxNums
            // 
            this.tbxNums.Location = new System.Drawing.Point(252, 46);
            this.tbxNums.Name = "tbxNums";
            this.tbxNums.Size = new System.Drawing.Size(100, 21);
            this.tbxNums.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(379, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "开始保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 620);
            this.Controls.Add(this.gpSave);
            this.Controls.Add(this.gpPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gpPort.ResumeLayout(false);
            this.gpPort.PerformLayout();
            this.gpSave.ResumeLayout(false);
            this.gpSave.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpPort;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ComboBox cobxSerialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxNums;
        private System.Windows.Forms.Button btnClear;
        private ChannelSave channelSave5;
        private ChannelSave channelSave3;
        private ChannelSave channelSave2;
        private ChannelSave channelSave0;
    }
}

