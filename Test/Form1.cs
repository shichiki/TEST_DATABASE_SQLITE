using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Test
{
    public partial class Form1 : Form
    {
        SQLiteConnection conn = new SQLiteConnection();
        SQLiteCommand cmd = new SQLiteCommand();

        SQLiteDataAdapter adapter = new SQLiteDataAdapter();
        DataTable dt1 = new DataTable();
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);//Thêm sự kiện click  
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SQLiteDataAdapter da = new SQLiteDataAdapter("Select * From User", conn);//Chọn toàn bảng  
            //DataTable dt = new DataTable("Lite");
            //da.Fill(dt);//Xuất dữ liệu ra bảng  
            //dataGridView1.DataSource = dt;  
            LoadData();
        }
        private void LoadData()
        {
            cmd.Connection = conn;
            adapter.SelectCommand = cmd;
            conn.ConnectionString = @"data source=C:\Users\ShichiKi\Documents\Visual Studio 2013\Projects\Test\user01\Data.db";
            cmd.CommandText = "select * from User";
            adapter.SelectCommand = cmd;
            dt1.Rows.Clear();
            adapter.Fill(dt1);
            bs.DataSource = dt1;
            dataGridView1.DataSource = bs;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
