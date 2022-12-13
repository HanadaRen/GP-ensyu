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

        private void button1_Click(object sender, EventArgs e)//テーブル作成ボタン
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
        private void button3_Click(object sender, EventArgs e)//読み込みボタン
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
        private void button6_Click(object sender, EventArgs e)//テーブル削除ボタン
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

        private void button2_Click(object sender, EventArgs e)//戻るボタン
        {
            this.Close();//画面を閉じる
            main_menu mm = new main_menu();//main_menuをmmと定義
            mm.Visible = true;//main_menuを表示
        }
    }
}