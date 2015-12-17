using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DevExpress.Charts;
using DevExpress.XtraCharts;


namespace ReverseY
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        DataTable dataTb1 = null; 

        public Form1()
        {
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("form1.ico")));
            this.chartControl1.Series.Clear();
            this.chartControl1.Titles.Clear();
            string currentpath = getPath(Application.StartupPath, 2);
            this.Icon = new System.Drawing.Icon(currentpath + "\\Resources\\BusinessObject.ico"); 

        }

        public string getPath(string currentpath, int level)
        {
            string path = currentpath;
            for (int i = 0; i < level; i++) 
            {
                path = path.Substring(0, path.LastIndexOf("\\"));
            }
            return path;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = false;
            this.Text = "Depth Vs. DOL";
           // this.Icon = "/pic/BusinessObject.ico";
            //this.Icon = 
           
           // this.chartControl1.Series.Clear();
            //this.chartControl1.Titles.Clear();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SetTable(ref dataTb1);
            this.chartControl1.Series.Clear();

            Series S1 = new Series("Actual Progress", ViewType.Spline);
            S1.DataSource = dataTb1;
            S1.ArgumentDataMember= "DOL";
            S1.ValueDataMembers[0]= "Depth";
            DevExpress.XtraCharts.ChartTitle chartTitle1= new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            chartTitle2.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Left;
            chartTitle2.Text = "Depth:m";

            chartTitle1.Dock = DevExpress.XtraCharts.ChartTitleDockStyle.Top;
            chartTitle1.Text = "Depth Vs. DOL";
            chartTitle1.Font = new System.Drawing.Font("Stencil", 18F);
             chartTitle1.TextColor = System.Drawing.Color.FromName("Green");
            this.chartControl1.Titles.Clear();
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {chartTitle1,
                        chartTitle2});
            this.chartControl1.Series.Add(S1);
            




        }
    

        private void SetTable(ref DataTable dataTb)
        {

            dataTb = new DataTable("Depth Vs. DOL");

            DataColumn col = new DataColumn("Depth", typeof(int));
            dataTb.Columns.Add(col);

            DataColumn colName = new DataColumn("DOL", typeof(int));
            dataTb.Columns.Add(colName);

            DataTable ExcelTable;
            openFileDialog1.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";//过滤一下，只要表格格式的
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = getPath(Application.StartupPath, 2);
            openFileDialog1.ShowDialog();

            string MyFileName = openFileDialog1.FileName;
            if (MyFileName.Trim() == "")
            {
                this.chartControl1.Series.Clear();
                this.chartControl1.Titles.Clear();
                return;
            }

            string MyFilePath = MyFileName;
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + MyFilePath + ";Extended Properties=Excel 8.0;";

            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [Sheet1$] ";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);

            DataSet myDataSet = new DataSet();
            myCommand.Fill(myDataSet, "[Sheet1$]");

            myConn.Close();
            ExcelTable = myDataSet.Tables[0];

            int iRows = ExcelTable.Rows.Count;
            int iColums = ExcelTable.Columns.Count;

            int[,] StoreData = new int[iRows, iColums];
            string temp = "";
            for (int i = 0; i < ExcelTable.Rows.Count; i++)
            {
                DataRow dr = dataTb.NewRow();
                dr[0] = ExcelTable.Rows[i][0].ToString(); 
                temp = ExcelTable.Rows[i][1].ToString(); 
                dr[1] = ExcelTable.Rows[i][1].ToString(); ;
                dataTb.Rows.Add(dr);
            }


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.chartControl1.Series.Clear();
            this.chartControl1.Titles.Clear();

        }





        
    }
}
