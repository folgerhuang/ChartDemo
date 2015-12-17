using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> xData = new List<string>() { "A", "B", "C", "D" };
            List<int> yData = new List<int>() { 10, 20, 30, 40 };
            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Read";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);

            List<int> yyData = new List<int> { 10, 30,60, 100 };
            chart1.Series[1].Points.DataBindXY(xData, yyData);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            //title1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            title1.Name = "Title1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Text = "年度销售汇总";
            this.chart1.Titles.Add(title1);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
