using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;

namespace Gp_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ControlBox = false;
            this.Load += search_start;
        }
        private void button1_Click(object sender, EventArgs e)//テーブル作成ボタン
        {
            //コネクションを開いてテーブル作成をして閉じる
            using (var con = new SQLiteConnection("Data Source=students.db"))
            {
                con.Open();
                using (SQLiteCommand command = con.CreateCommand())
                {
                    command.CommandText =
                        "create table t_product(no INTEGER PRIMARY KEY AUTOINCREMENT,email_address TEXT,student_name TEXT,sex TEXT,department TEXT,school_year TEXT,class TEXT,attendance_number INTEGER,club_name TEXT,registered_date TEXT)";
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
                var adapter = new SQLiteDataAdapter("SELECT* FROM t_product ", con);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].HeaderText = "学籍番号";
                dataGridView1.Columns[1].HeaderText = "メルアド";
                dataGridView1.Columns[2].HeaderText = "名前";
                dataGridView1.Columns[3].HeaderText = "性別";
                dataGridView1.Columns[4].HeaderText = "学科";
                dataGridView1.Columns[5].HeaderText = "学年";
                dataGridView1.Columns[6].HeaderText = "クラス";
                dataGridView1.Columns[7].HeaderText = "出席番号";
                dataGridView1.Columns[8].HeaderText = "クラブ名";
                dataGridView1.Columns[9].HeaderText = "登録日時";

                //データグリッドビューの列名を中央揃え
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //データグリッドビューを書き換え不可に設定
                dataGridView1.ReadOnly = true;

                //データグリッドビューの奇数行の背景を水色に変更
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
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
            MainMenu mm = new MainMenu();//main_menuをmmと定義
            mm.Visible = true;//main_menuを表示
        }
        private void search_start(object sender, EventArgs e)//データグリッドビューに一覧を表示
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
            {   //DataTableを作成します。
                var dataTable = new DataTable();
                //SQLの実行
                var adapter = new SQLiteDataAdapter("SELECT* FROM t_product ", con);
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].HeaderText = "学籍番号";
                dataGridView1.Columns[1].HeaderText = "メルアド";
                dataGridView1.Columns[2].HeaderText = "名前";
                dataGridView1.Columns[3].HeaderText = "性別";
                dataGridView1.Columns[4].HeaderText = "学科";
                dataGridView1.Columns[5].HeaderText = "学年";
                dataGridView1.Columns[6].HeaderText = "クラス";
                dataGridView1.Columns[7].HeaderText = "出席番号";
                dataGridView1.Columns[8].HeaderText = "クラブ名";
                dataGridView1.Columns[9].HeaderText = "登録日時";

                //データグリッドビューの列名を中央揃え
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //データグリッドビューを書き換え不可に設定
                dataGridView1.ReadOnly = true;

                //データグリッドビューの奇数行の背景を水色に変更
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.IndianRed;

            button4.BackColor = Color.IndianRed;
        }
    }
}