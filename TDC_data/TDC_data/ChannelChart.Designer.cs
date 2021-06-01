namespace TDC_data
{
    partial class ChannelChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelChannel = new System.Windows.Forms.Label();
            this.tBx_X_value = new System.Windows.Forms.TextBox();
            this.label_X_value = new System.Windows.Forms.Label();
            this.label_bangaokuan = new System.Windows.Forms.Label();
            this.tBx_bangaokuan = new System.Windows.Forms.TextBox();
            this.tBx_fangcha = new System.Windows.Forms.TextBox();
            this.label_fangcha = new System.Windows.Forms.Label();
            this.label_junzhi = new System.Windows.Forms.Label();
            this.tBx_junzhi = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Font = new System.Drawing.Font("宋体", 14F);
            this.labelChannel.ForeColor = System.Drawing.Color.Black;
            this.labelChannel.Location = new System.Drawing.Point(3, 15);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(66, 19);
            this.labelChannel.TabIndex = 77;
            this.labelChannel.Text = "无通道";
            // 
            // tBx_X_value
            // 
            this.tBx_X_value.Enabled = false;
            this.tBx_X_value.Location = new System.Drawing.Point(7, 190);
            this.tBx_X_value.Name = "tBx_X_value";
            this.tBx_X_value.Size = new System.Drawing.Size(78, 21);
            this.tBx_X_value.TabIndex = 76;
            // 
            // label_X_value
            // 
            this.label_X_value.AutoSize = true;
            this.label_X_value.Location = new System.Drawing.Point(8, 175);
            this.label_X_value.Name = "label_X_value";
            this.label_X_value.Size = new System.Drawing.Size(71, 12);
            this.label_X_value.TabIndex = 75;
            this.label_X_value.Text = "X轴中点(ns)";
            // 
            // label_bangaokuan
            // 
            this.label_bangaokuan.AutoSize = true;
            this.label_bangaokuan.Location = new System.Drawing.Point(8, 136);
            this.label_bangaokuan.Name = "label_bangaokuan";
            this.label_bangaokuan.Size = new System.Drawing.Size(65, 12);
            this.label_bangaokuan.TabIndex = 74;
            this.label_bangaokuan.Text = "半高宽(ps)";
            // 
            // tBx_bangaokuan
            // 
            this.tBx_bangaokuan.Enabled = false;
            this.tBx_bangaokuan.Location = new System.Drawing.Point(7, 151);
            this.tBx_bangaokuan.Name = "tBx_bangaokuan";
            this.tBx_bangaokuan.Size = new System.Drawing.Size(78, 21);
            this.tBx_bangaokuan.TabIndex = 73;
            // 
            // tBx_fangcha
            // 
            this.tBx_fangcha.Enabled = false;
            this.tBx_fangcha.Location = new System.Drawing.Point(7, 112);
            this.tBx_fangcha.Name = "tBx_fangcha";
            this.tBx_fangcha.Size = new System.Drawing.Size(78, 21);
            this.tBx_fangcha.TabIndex = 72;
            // 
            // label_fangcha
            // 
            this.label_fangcha.AutoSize = true;
            this.label_fangcha.Location = new System.Drawing.Point(8, 97);
            this.label_fangcha.Name = "label_fangcha";
            this.label_fangcha.Size = new System.Drawing.Size(65, 12);
            this.label_fangcha.TabIndex = 71;
            this.label_fangcha.Text = "标准差(ps)";
            // 
            // label_junzhi
            // 
            this.label_junzhi.AutoSize = true;
            this.label_junzhi.Location = new System.Drawing.Point(8, 58);
            this.label_junzhi.Name = "label_junzhi";
            this.label_junzhi.Size = new System.Drawing.Size(77, 12);
            this.label_junzhi.TabIndex = 70;
            this.label_junzhi.Text = "周期均值(ns)";
            // 
            // tBx_junzhi
            // 
            this.tBx_junzhi.Enabled = false;
            this.tBx_junzhi.Location = new System.Drawing.Point(7, 73);
            this.tBx_junzhi.Name = "tBx_junzhi";
            this.tBx_junzhi.Size = new System.Drawing.Size(78, 21);
            this.tBx_junzhi.TabIndex = 69;
            // 
            // chart
            // 
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.Title = "单位：ns";
            chartArea2.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(91, 3);
            this.chart.Name = "chart";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "概率密度";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(362, 251);
            this.chart.TabIndex = 68;
            this.chart.Text = "chart";
            // 
            // ChannelChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelChannel);
            this.Controls.Add(this.tBx_X_value);
            this.Controls.Add(this.label_X_value);
            this.Controls.Add(this.label_bangaokuan);
            this.Controls.Add(this.tBx_bangaokuan);
            this.Controls.Add(this.tBx_fangcha);
            this.Controls.Add(this.label_fangcha);
            this.Controls.Add(this.label_junzhi);
            this.Controls.Add(this.tBx_junzhi);
            this.Controls.Add(this.chart);
            this.Name = "ChannelChart";
            this.Size = new System.Drawing.Size(456, 257);
            this.Load += new System.EventHandler(this.ChannelChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.TextBox tBx_X_value;
        private System.Windows.Forms.Label label_X_value;
        private System.Windows.Forms.Label label_bangaokuan;
        public System.Windows.Forms.TextBox tBx_bangaokuan;
        public System.Windows.Forms.TextBox tBx_fangcha;
        private System.Windows.Forms.Label label_fangcha;
        private System.Windows.Forms.Label label_junzhi;
        public System.Windows.Forms.TextBox tBx_junzhi;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}
