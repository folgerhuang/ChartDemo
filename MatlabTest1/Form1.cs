using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;
using myplus;
using Myplotsin;

namespace MatlabTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MWArray i = Convert.ToInt32(textBox1.Text);
                Myplus obj = new Myplus();
                MWArray result = obj.myplus(i);
                label1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,"请输入整数！\n"+ex.ToString(),"警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MWArray i = Convert.ToInt32(textBox1.Text);
                plotsin obj = new plotsin();
                obj.Myplotsin(i);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "请输入整数！\n" + ex.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
