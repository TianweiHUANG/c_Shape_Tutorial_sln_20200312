using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SQLite;

namespace WFapp_myDATABASE_20200815
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            //using (var myDataBase_connection = new SQLiteConnection(@"data source=C:\Users\Administrator\Desktop\myDataBase.db"))
            using (var myDataBase_connection = new SQLiteConnection("data source=myDataBase.db"))
            {
                myDataBase_connection.Open();
                // SQL=>>> select * from myTable
                var command = new SQLiteCommand("select * from myTable", myDataBase_connection);
                var adapter = new SQLiteDataAdapter(command);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                var table = dataSet.Tables[0];
            }
        }

        private void timer_myTable_Tick(object sender, EventArgs e)
        {
            //using (var myDataBase_connection = new SQLiteConnection(@"data source=C:\Users\Administrator\Desktop\myDataBase.db"))
            using (var myDataBase_connection = new SQLiteConnection("data source=myDataBase.db"))
            {
                var adapter = new SQLiteDataAdapter("select * from myTable", myDataBase_connection);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView_myTable.DataSource = dataTable;
            }
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            //using (var myDataBase_connection = new SQLiteConnection(@"data source=C:\Users\Administrator\Desktop\myDataBase.db"))
            using (var myDataBase_connection = new SQLiteConnection("data source=myDataBase.db"))
            {
                myDataBase_connection.Open();
                // SQL=>>> insert into myTable values(3,"张三",22,"陕西省西安市长安区","看书,听音乐")
                var command = new SQLiteCommand("insert into myTable " + "values(3,\"张三\",22,\"陕西省西安市长安区\",\"看书,听音乐\")", myDataBase_connection);
                var result = command.ExecuteNonQuery();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //using (var myDataBase_connection = new SQLiteConnection(@"data source=C:\Users\Administrator\Desktop\myDataBase.db"))
            using (var myDataBase_connection = new SQLiteConnection("data source=myDataBase.db"))
            {
                myDataBase_connection.Open();
                // SQL=>>> delete from myTable where Id = 3
                var command = new SQLiteCommand("delete from myTable where Id = 3", myDataBase_connection);
                var result = command.ExecuteNonQuery();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            //using (var myDataBase_connection = new SQLiteConnection(@"data source=C:\Users\Administrator\Desktop\myDataBase.db"))
            using (var myDataBase_connection = new SQLiteConnection("data source=myDataBase.db"))
            {
                myDataBase_connection.Open();
                // SQL=>>> update myTable set Name = '王五' where Id = 3
                var command = new SQLiteCommand("update myTable set Name = '王五' where Id = 3", myDataBase_connection);
                var result = command.ExecuteNonQuery();
            }
        }
    }
}