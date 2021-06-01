using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TDC_data
{
    public partial class ChannelChart : UserControl
    {
        
        List<double> pointlist = new List<double>();
        List<double> Time_Period = new List<double>();
        List<double> Time_Period_cut = new List<double>();
        double[] data_pic_X = new double[102];
        double[] data_pic_Y = new double[102];

        
        public int channel = -1;
        public static double basedata = 0.0;


        public ChannelChart()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        public void SetChannel(int i)
        {
            channel = i;
            if (i >= 0)
            {
                labelChannel.Text = "通道" + channel;
            }
            else 
            {
                labelChannel.Text = "无通道";
            }
        }        

        public void data_pant()
        {
            double PowOfE = 0;
            double result = 0;

            NormalData normalData = new NormalData();
            int count = Form1.data[channel].Count();
            int i = count > 100 ? count - 100 : 0;
            List<double> data = Form1.data[channel].GetRange(i, count - i);
            if (count > 100)
            {
                Form1.data[channel].RemoveRange(0, count - 100);
            }
            //求当前数据的平均值 方差 标准差
            normalData.dealWithData(data);

            int intA = 0;
            string str = tBx_X_value.Text;
            bool rst = Int32.TryParse(str, out intA); // return bool value hint y/n
            if (rst)
            {
                data_pic_X[0] = intA - 0.98;
            }
            else
            {
                data_pic_X[0] = 999982 - 0.98;
            }
            if (normalData.mDataVariance != 0 && normalData.mDataVarianceSqrt != 0)
            {
                PowOfE = -(Math.Pow(Math.Abs(data_pic_X[0] - normalData.mDataMean), 2) / (2 * normalData.mDataVariance));
                result = ((1 / Math.Sqrt(2 * Math.PI)) / normalData.mDataVarianceSqrt) * Math.Pow(Math.E, PowOfE);
            }
            data_pic_Y[0] = result;

            for (int k = 1; k < 102; k++)
            {
                data_pic_X[k] = data_pic_X[k - 1] + 0.02;

                PowOfE = -(Math.Pow(Math.Abs(data_pic_X[k] - normalData.mDataMean), 2) / (2 * normalData.mDataVariance));
                result = ((1 / Math.Sqrt(2 * Math.PI)) / normalData.mDataVarianceSqrt) * Math.Pow(Math.E, PowOfE);

                data_pic_Y[k] = result;
            }

            //*****************画图*****************************************
            chart.Series["概率密度"].Points.Clear();
            for (int pointIndex = 0; pointIndex < 102; pointIndex++)
            {
                chart.Series["概率密度"].Points.AddXY(data_pic_X[pointIndex], data_pic_Y[pointIndex]);
                //chart.Series["概率密度"].Points.c

            }
            // Set fast line chart type
            chart.Series["概率密度"].ChartType = SeriesChartType.FastLine;

        }

        public void Setbasedata(double data)
        {
            basedata = data;
        }

        public void readyNormalGraphData(NormalData normalData) 
        {
            chart.Series["概率密度"].Points.Clear();
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "N3";            

            chart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 6;
            chart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
            //chart.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //chart.ChartAreas[0].AxisX.;

            chart.ChartAreas[0].AxisX.Minimum = normalData.mDataMean - 0.5;
            chart.ChartAreas[0].AxisX.Maximum = normalData.mDataMean + 0.5;
            //chart.ChartAreas[0].AxisX.Interval = 10;
            //chart.ChartAreas[0].AxisX.MinorCount = 10;            //显示X轴间隔数量


            double data_FWHM = normalData.mDataVarianceSqrt * 2.355;

            tBx_junzhi.Text = "" + Math.Round(normalData.mDataMean, 3);
            tBx_fangcha.Text = "" + Math.Round(normalData.mDataVarianceSqrt * 1000, 5);
            tBx_bangaokuan.Text = "" + Math.Round(data_FWHM * 1000, 5);
            tBx_X_value.Text = normalData.mPeriods.Count.ToString();
            //tBx_X_value.Text = basedata.ToString();
            //tBx_X_value.Text = Form1.data[channel].Count().ToString();

            double leftPart = 1 / (normalData.mDataVarianceSqrt * Math.Sqrt(2 * Math.PI)); //
            double pointX = normalData.mDataMean - 0.5;
            while (pointX <= normalData.mDataMean + 0.5)
            {
                double resultPointX = leftPart * Math.Exp(-1 * (pointX - normalData.mDataMean)
                                                  * (pointX - normalData.mDataMean) / (2 * normalData.mDataVariance));
                //resultPointX = resultPointX > 1 ? 1 : resultPointX;
                resultPointX = resultPointX < 0 ? 0 : resultPointX;
                chart.Series["概率密度"].Points.AddXY(pointX, resultPointX);
                pointX += 0.02;
            }
        }
        
        public void paintGraph()
        {            
            int count = Form1.data[channel].Count();
            if (count < 500)
            {
                return;
            }
            //int i = count > 500 ? count - 500 : 0;
            //List<double> data = Form1.data[channel].GetRange(i, count - i);
            List<double> data = Form1.data[channel].GetRange(count - 500, 500);
            NormalData normalData= new NormalData();
            if (count > 500)
            {
                Form1.data[channel].RemoveRange(0, count - 500);
            }
            //求当前数据的平均值 方差 标准差
            normalData.dealWithData(data);
            readyNormalGraphData(normalData);

            //if (basedata != 0)
            //{
            //    readyNormalGraphData(normalData);
            //}
        }


        private void ChannelChart_Load(object sender, EventArgs e)
        {

        }       
    }
}
