using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Hospital
{
    public class MetalTestTreeCreate
    {
        static string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;//连接字符串
        OleDbConnection conn = new OleDbConnection(strcon);

        //创建树形菜单
        public void CreateTree(TreeView treeview)
        {
            conn.Open();
            string sql = "select * from tbl_testpaper where pid=0 and tid=1";//查找根节点
            TreeNode nodes = new TreeNode();
            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                nodes.Name = reader["tid"].ToString();
                nodes.Text = reader["tName"].ToString();
            }
            reader.Close();

            string sql1 = "select * from tbl_testpaper where pid=" + nodes.Name + " order by pid desc";//查找”父节点“为”根节点“的所有节点
            bind(conn, comm, sql1, nodes);
            conn.Close();
            treeview.Nodes.Add(nodes);
        }

        public void CreateTree2(TreeView treeview)
        {
            conn.Open();
            string sql = "select * from tbl_testpaper where pid=0 and tid=205";//查找根节点
            TreeNode nodes = new TreeNode();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                nodes.Name = reader["tid"].ToString();
                nodes.Text = reader["tName"].ToString();
            }
            reader.Close();

            string sql1 = "select * from tbl_testpaper where uflag=true order by pid desc";//查找”父节点“为”根节点“的所有节点
            bind(conn, comm, sql1, nodes);
            conn.Close();
            treeview.Nodes.Add(nodes);
            /*
            TreeNode nodes2 = new TreeNode();
            nodes2.Name = "0";
            nodes2.Text = "常用量表";
            treeview.Nodes.Add(nodes2);
             */
        }

        public void CreateTree3(TreeView treeview)
        {
            conn.Open();
            string sql = "select * from tbl_testpaper where pid=0 and tid=206";//查找根节点
            TreeNode nodes = new TreeNode();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                nodes.Name = reader["tid"].ToString();
                nodes.Text = reader["tName"].ToString();
            }
            reader.Close();

            string sql1 = "select * from tbl_testpaper where hflag=true order by pid desc";//查找”父节点“为”根节点“的所有节点
            bind(conn, comm, sql1, nodes);
            conn.Close();
            treeview.Nodes.Add(nodes);
            /*
            TreeNode nodes2 = new TreeNode();
            nodes2.Name = "0";
            nodes2.Text = "常用量表";
            treeview.Nodes.Add(nodes2);
             */
        }


        //在综合心理测试tree中，显示选中sflag字段的量表
        public void CreateTree4(TreeView treeview)
        {
            conn.Open();
            string sql = "select * from tbl_testpaper where pid=0 and tid=1";//查找根节点
            TreeNode nodes = new TreeNode();

            OleDbCommand comm = new OleDbCommand(sql, conn);
            OleDbDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                nodes.Name = reader["tid"].ToString();
                nodes.Text = reader["tName"].ToString();
            }
            reader.Close();

            string sql1 = "select * from tbl_testpaper where pid=" + nodes.Name + " order by pid desc";//查找”父节点“为”根节点“的所有节点
            bind4(conn, comm, sql1, nodes);
            conn.Close();
            treeview.Nodes.Add(nodes);
            /*
            TreeNode nodes2 = new TreeNode();
            nodes2.Name = "0";
            nodes2.Text = "常用量表";
            treeview.Nodes.Add(nodes2);
             */
        }

        //树形菜单绑定4
        private void bind4(OleDbConnection conn, OleDbCommand comm, string sql, TreeNode noed)
        {
            comm.CommandText = sql;
            comm.Connection = conn;
            OleDbDataReader reader = comm.ExecuteReader();
            List<TreeNode> A = new List<TreeNode>();
            while (reader.Read())
            {
                TreeNode node1 = new TreeNode();
                node1.Name = reader["tid"].ToString();
                node1.Text = reader["tName"].ToString();
                A.Add(node1);
            }
            reader.Close();

            for (int i = 0; i < A.Count; i++)
            {
                string sql1 = "select * from tbl_testpaper where sflag=true and pid=" + A[i].Name + " order by pid desc";//查找每个节点下的所有子节点
                noed.Nodes.Add(A[i]);
                bind(conn, comm, sql1, A[i]);//递归
            }
        }

        //树形菜单绑定
        private void bind(OleDbConnection conn, OleDbCommand comm, string sql, TreeNode noed)
        {
            comm.CommandText = sql;
            comm.Connection = conn;
            OleDbDataReader reader = comm.ExecuteReader();
            List<TreeNode> A = new List<TreeNode>();
            while (reader.Read())
            {
                TreeNode node1 = new TreeNode();
                node1.Name = reader["tid"].ToString();
                node1.Text = reader["tName"].ToString();
                A.Add(node1);
            }
            reader.Close();

            for (int i = 0; i < A.Count; i++)
            {
                string sql1 = "select * from tbl_testpaper where pid=" + A[i].Name + " order by pid desc";//查找每个节点下的所有子节点
                noed.Nodes.Add(A[i]);
                bind(conn, comm, sql1, A[i]);//递归
            }
        }
    }
}
