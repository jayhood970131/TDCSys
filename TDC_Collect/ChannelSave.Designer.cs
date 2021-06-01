namespace TDC_Collect
{
    partial class ChannelSave
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSaveChannel = new System.Windows.Forms.Button();
            this.tbxSavedNums = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbChannel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveChannel
            // 
            this.btnSaveChannel.Location = new System.Drawing.Point(459, 13);
            this.btnSaveChannel.Name = "btnSaveChannel";
            this.btnSaveChannel.Size = new System.Drawing.Size(91, 30);
            this.btnSaveChannel.TabIndex = 25;
            this.btnSaveChannel.Text = "另存为";
            this.btnSaveChannel.UseVisualStyleBackColor = true;
            this.btnSaveChannel.Click += new System.EventHandler(this.btnSaveChannel_Click);
            // 
            // tbxSavedNums
            // 
            this.tbxSavedNums.Enabled = false;
            this.tbxSavedNums.Location = new System.Drawing.Point(219, 19);
            this.tbxSavedNums.Name = "tbxSavedNums";
            this.tbxSavedNums.Size = new System.Drawing.Size(227, 21);
            this.tbxSavedNums.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(15, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 21);
            this.label9.TabIndex = 23;
            this.label9.Text = "Channel";
            // 
            // lbChannel
            // 
            this.lbChannel.AutoSize = true;
            this.lbChannel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbChannel.Location = new System.Drawing.Point(99, 19);
            this.lbChannel.Name = "lbChannel";
            this.lbChannel.Size = new System.Drawing.Size(21, 21);
            this.lbChannel.TabIndex = 26;
            this.lbChannel.Text = "x";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(126, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "已保存";
            // 
            // ChannelSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbChannel);
            this.Controls.Add(this.btnSaveChannel);
            this.Controls.Add(this.tbxSavedNums);
            this.Controls.Add(this.label9);
            this.Name = "ChannelSave";
            this.Size = new System.Drawing.Size(579, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnSaveChannel;
        public System.Windows.Forms.TextBox tbxSavedNums;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lbChannel;
        public System.Windows.Forms.Label label1;
    }
}
