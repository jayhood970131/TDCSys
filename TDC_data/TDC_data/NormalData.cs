using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TDC_data
{
    public class NormalData
    {
        public List<double> mPeriods = new List<double>(); // 当前通道的数据
        public double mDataMean = 0.0; // 平均值
        public double mDataVariance = 0.0; // 方差
        public double mDataVarianceSqrt = 0.0; // 标准差

        public void dealWithData(List<double>currentChannelData)
        {
            if (currentChannelData.Count < 2)
            {
                return;
            }

            int dataSize = currentChannelData.Count();
            double baseCorrect = ChannelChart.basedata == 0.0 ? (currentChannelData[1] - currentChannelData[0]) : ChannelChart.basedata;  // 基准数据
            //double baseCorrect = currentChannelData[1] - currentChannelData[0];
            for (int i = 0; i<dataSize - 1; ++i)
            {
                double period = currentChannelData[i + 1] - currentChannelData[i];
                if (System.Math.Abs(period - baseCorrect) > 0.1)   // 如果误差大于1ns，丢弃
                {
                    continue;
                }
                mDataMean += period; // 平均周期的分母部分
                mPeriods.Add(period);
            }

            int periodsSize = mPeriods.Count();
            if (periodsSize == 0)
            {
                return;
            }

            mDataMean /= periodsSize; // 求平均值            

            for (int i = 0; i < periodsSize; ++i)
            {
                mDataVariance += (mPeriods[i] - mDataMean) * (mPeriods[i] - mDataMean); // 方差的分母部分
            }
            mDataVariance /= periodsSize; // 求方差
            mDataVarianceSqrt = System.Math.Sqrt(mDataVariance); // 求标准差

            if (periodsSize > 200)
            {
                ChannelChart.basedata = mDataMean;
            }

            //if (currentChannelData.Count > 300 && periodsSize < 50)
            //{
            //    FileStream fSteam = new FileStream("E:\\data-50.txt", FileMode.Open);
            //    for (int i = 0; i < currentChannelData.Count; i++)
            //    {
            //        string str = currentChannelData[i].ToString() + "\r\n";
            //        byte[] data = System.Text.Encoding.Default.GetBytes(str);
            //        fSteam.Write(data, 0, data.Length);
            //    }
            //    fSteam.Close();
            //}

        }

    }
}
