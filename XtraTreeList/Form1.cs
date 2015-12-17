using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlHelper;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
namespace XtraTreeList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // BindTreeList();
        }

        public void BindTreeList()
        {
            TreeListNode parentNode = null;
            TreeListNode childNode = null;

            treeList1.BeginUnboundLoad();
            treeList1.ClearNodes();
            string strSQL1 = "SELECT [CategoryID],[CategoryName] FROM [Northwind].[dbo].[Categories]";
            DataTable treeDv = SQLHelper.ExecuteDt(strSQL1);
            DataTable parentDt = null;
            DataTable childDt = null;
            parentDt = treeDv;
            foreach (DataRow parentDr in parentDt.Rows)
            {
                parentNode = this.treeList1.AppendNode(new object[] { parentDr["CategoryID"], parentDr["CategoryNameID"] }, 0);
                /*
                treeDv = new DataView(dt_F_表二费用表);
                treeDv.RowFilter = "上级费用ID='" + parentDr["IID"].ToString() + "'";
                childDt = treeDv.ToTable();
                foreach (DataRow childDr in childDt.Rows)
                {
                    childNode = this.treeList.AppendNode(new object[] { childDr["IID"], childDr["上级费用ID"] }, parentNode);
                }*/
            }

            treeList1.EndUnboundLoad();
            treeList1.ExpandAll();


        }
    }
}
