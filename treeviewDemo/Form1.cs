using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace treeviewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            treeView1.LabelEdit = true;

        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            //构造节点显示内容、取消选定时显示图像索引号、选定时显示图像索引号
            if (txtRoot.Text != "")
            {
                TreeNode newNode = new TreeNode(this.txtRoot.Text, 0, 1);
                this.treeView1.Nodes.Add(newNode);
                this.treeView1.Select();

            }
         
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            if (txtChild.Text != "")
            {
                TreeNode selectedNode = this.treeView1.SelectedNode;
                if (selectedNode == null)
                {
                    MessageBox.Show("添加子节点之前必须先选中一个节点。", "提示信息");
                    return;
                }
                TreeNode newNode = new TreeNode(this.txtChild.Text, 2, 3);
                selectedNode.Nodes.Add(newNode);
                selectedNode.Expand();
                this.treeView1.Select();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("删除节点之前先选中一个节点。", "提示信息");
                return;
            }
            TreeNode parentNode = selectedNode.Parent;
            if (parentNode == null)
                this.treeView1.Nodes.Remove(selectedNode);
            else
                parentNode.Nodes.Remove(selectedNode);
            this.treeView1.Select();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }

       
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeView tree = sender as TreeView;
            if (e.Button == MouseButtons.Right
             && ModifierKeys == Keys.None && this.treeView1.SelectedNode!=null)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                
               
                popupMenu1.ShowPopup(p);

            }
        }

        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            /*TreeView tree = sender as TreeView;
            if (e.Button == MouseButtons.Right
             && ModifierKeys == Keys.None)
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
    
                    popupMenu1.ShowPopup(p);
               
            }*/

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeNode selectedNode = this.treeView1.SelectedNode;
            selectedNode.BeginEdit();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
