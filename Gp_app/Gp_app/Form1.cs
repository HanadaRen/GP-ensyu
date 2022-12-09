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

namespace Gp_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//テーブル作成
        {   //コネクションを開いてテーブル作成をして閉じる
            using(var con = new SQLiteConnection("Data Source=students.db"))
            {
                con.Open();
                using (SQLiteCommand command = con.CreateCommand())
                {
                    command.CommandText =
                        "create table t_product(no INTEGER PRYMARY KEY,email_address TEXT,student_name TEXT,sex TEXT,department TEXT,school_year TEXT,class TEXT,attendance_number INTEGER,club_name TEXT)";
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        //private void button2_Click(object sender, EventArgs e)//データ追加ボタン
        //{
        //    using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
        //    {
        //        con.Open();
        //        using(SQLiteTransaction trans = con.BeginTransaction())
        //        {
        //            SQLiteCommand cmd = con.CreateCommand();
        //            //インサート
        //            cmd.CommandText = "INSERT INTO t_product (productname, price) VALUES (@Product, @Price)";
        //            //パラメータセット
        //            cmd.Parameters.Add("Product", System.Data.DbType.String);
        //            cmd.Parameters.Add("Price",  System.Data.DbType.Int64);
        //            //データ追加
        //            cmd.Parameters["Product"].Value = textBox1.Text;
        //            cmd.Parameters["Price"].Value = int.Parse(textBox2.Text);
        //            cmd.ExecuteNonQuery();
        //            //コミット
        //            trans.Commit();
        //        }
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)//読み込み
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
            {   //DataTableを作成します。
                var dataTable = new DataTable();
                //SQLの実行
                var adapter = new SQLiteDataAdapter("SELECT * FROM t_product " ,con);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using(SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
            {
                con.Open();
                using(SQLiteTransaction trans = con.BeginTransaction())
                {
                    SQLiteCommand cmd = con.CreateCommand();
                    //インサート
                    cmd.CommandText = "UPDATE t_product set productname = @Product, price = @Price WHERE CD = @Cd";
                    //パラメータリセット
                    cmd.Parameters.Add("Product", System.Data.DbType.String);
                    cmd.Parameters.Add("Price", System.Data.DbType.Int64);
                    cmd.Parameters.Add("Cd", System.Data.DbType.Int64);
                    //データ追加
                    cmd.Parameters["Product"].Value = textBox3.Text;
                    cmd.Parameters["Price"].Value = int.Parse(textBox4.Text);
                    cmd.Parameters["Cd"].Value = int.Parse(textBox5.Text);
                    cmd.ExecuteNonQuery();
                    //コミット
                    trans.Commit();
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            using(SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
            {
                con.Open();
                using(SQLiteTransaction trans = con.BeginTransaction())
                {
                    SQLiteCommand cmd = con.CreateCommand();
                    //インサート
                    cmd.CommandText = "DELETE FROM t_product WHERE CD = @Cd;";
                    //パラメータセット
                    cmd.Parameters.Add("Cd", System.Data.DbType.Int64);
                    //データ削除
                    cmd.Parameters["Cd"].Value = int.Parse(textBox6.Text);
                    cmd.ExecuteNonQuery();
                    //コミット
                    trans.Commit();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {   //コネクションを開いてテーブル削除をして閉じる
            using (var con = new SQLiteConnection("Data Source=students.db"))
            {
                con.Open();
                using (SQLiteCommand command = con.CreateCommand())
                {
                    command.CommandText =
                        "drop table t_product";
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}