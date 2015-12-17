using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraTreeList;



namespace TreeListDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataShowTree();
        }

        private void DataShowTree()
        {
            string strsql = "SELECT [field_id]    as [id]  " +
                                 " ,[fieldname]   as [name]" +
                                 "  ,[company_id]  as [parent_id]  " +
                             " FROM [ZWJQuickEvaluation].[dbo].[FIELD_T]" +
                           "  union " +
                          "  SELECT [well_id]  " +
                            "      ,[well_name]" +
                                "  ,[field_id] " +
                            "  FROM [ZWJQuickEvaluation].[dbo].[WELL_T] " +
                           " union  " +
                            "  SELECT [company_id] " +
                               "   ,[company_name]  " +
                             "     ,[company_id] " +
                             " FROM [ZWJQuickEvaluation].[dbo].[COMPANY_T]";
            string  strConnectionString = "server=localhost;uid=sa;pwd=Landmark1;database=ZWJQuickEvaluation";
            SqlConnection conn = new SqlConnection(strConnectionString);
            SqlDataAdapter da = null;
            try
            {
                DataSet ds = new DataSet();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.ConnectionString = strConnectionString;
                    conn.Open();
                }
                da = new SqlDataAdapter(strsql, conn);
                da.Fill(ds);

                DataView dvData = ds.Tables[0].DefaultView;

                treeList1.KeyFieldName = "id";
                treeList1.ParentFieldName = "parent_id";
                treeList1.DataSource = dvData;
               
                treeList1.ForceInitialize();
            }
            finally
            {
                da.Dispose();
                  if (conn != null && conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        //conn.Dispose();
                    }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            MessageBox.Show("show a new window to create a company !");
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {

            TreeList tree = sender as TreeList;
            if (e.Button == MouseButtons.Right
             && ModifierKeys == Keys.None
                        && treeList1.State == TreeListState.Regular)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    tree.SetFocusedNode(hitInfo.Node);
                }

                if (tree.FocusedNode != null & tree.FocusedNode.Level == 0)
                {
                    popupMenu1.ShowPopup(p);
                }
               // else
               //     popupMenu2.ShowPopup(p);
            }


        }

        private void treeList1_MouseUp_1(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            if (e.Button == MouseButtons.Right
             && ModifierKeys == Keys.None
                        && treeList1.State == TreeListState.Regular)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
                if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    tree.SetFocusedNode(hitInfo.Node);
                }

                if (tree.FocusedNode != null & tree.FocusedNode.Level == 0)
                {
                    popupMenu1.ShowPopup(p);
                }
                // else
                //     popupMenu2.ShowPopup(p);
            }
        }
    }
}
