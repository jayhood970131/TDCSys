using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDC_data
{
    public partial class Form2 : Form
    {
        int checkcount = 0;
        int ckbcount;
        List<CheckBox> btns = new List<CheckBox>();

        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            ckbcount = Form1.channelcount;            
            for (int i = 0; i < ckbcount; i++)
            {
                //btns[i] = new CheckBox();
                btns.Add(new CheckBox());
                btns[i].Name = "ckb" + i.ToString();    //定义控件名称                
                btns[i].Text = "通道" + i;
                btns[i].CheckedChanged += new EventHandler(ckb_CheckedChanged);
                flowLayoutPanel1.Controls.Add(btns[i]);
            }
            if (ckbcount >= 6)  //默认选中通道0,2,3,5
            {
                for (int i = 0; i < 4; i++)
                {
                    int num = Form1.check[i];
                    if (num >= 0 && num < ckbcount)
                    {
                        btns[num].Checked = true;
                    }
                }       
            }
        }
                
        
        private void ckb_CheckedChanged(object sender, EventArgs e)
        {            
            CheckBox cb = (CheckBox)sender;  //sender是被勾选的CheckedBox,引用之前先强制转换为CheckedBox类型
            String str = cb.Name.Substring(3, cb.Name.Length - 3);
            int i = int.Parse(str);
            if (cb.Checked)
            {             
                ++checkcount;
            }
            else
            {
                --checkcount;
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (checkcount > 4)
            {
                MessageBox.Show("最多选择4个", "Error");
            }
            else
            {                
                int num = 0;
                for (int i = 0; i < ckbcount; i++)
                {
                    if (btns[i].Checked == true)
                    {
                        Form1.check[num++] = i;
                    }
                }
                while (num < 4)
                {
                    Form1.check[num++] = -1;
                }

                checkcount = 0;
                this.Close();
            }            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
