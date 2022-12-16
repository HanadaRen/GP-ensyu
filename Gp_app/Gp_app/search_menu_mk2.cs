using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Gp_app
{
    public partial class search_menu_mk2 : Form
    {
        public search_menu_mk2()
        {
            InitializeComponent();
            ControlBox = false;
            this.Load += search_start;
        }
        private void Search_button_Click(object sender, EventArgs e)//検索ボタン
        {
                string serch_no = textBox1.Text;//テキストボックスの内容をserch_noに入れる

            if (!String.IsNullOrEmpty(textBox1.Text))//空白じゃなかったらtrue
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
                {
                    var dataTable = new DataTable();//DataTableを作成
                    
                    var adapter = new SQLiteDataAdapter("SELECT * FROM t_product WHERE t_product.no LIKE " + serch_no, con);//SQLの実行
                    adapter.Fill(dataTable);//行を取得
                    dataGridView1.DataSource = dataTable;//グリッドビューに表示
                    //dataGridView1.Columns[0].HeaderText = "はじめの列";
                }
            }
            else//空白だとfalse
            {
                DialogResult result = MessageBox.Show("数字を入力してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ダイアログの選択結果をresultに入れる
            }

        }
        private void Return_button_Click(object sender, EventArgs e)//終了ボタン
        {
                this.Close();//画面を閉じる
                main_menu mm = new main_menu();//main_menuをmmと定義
                mm.Visible = true;//main_menuを表示
        }
        private void Fix_button_Click(object sender, EventArgs e)//修正ボタン
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))//空白じゃなかったらtrue
            {
                string serch_no = textBox1.Text;//テキストボックスの内容をserch_noに入れる

                DialogResult result = MessageBox.Show("この内容で修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //ダイアログの選択結果をresultに入れる

                if (result == DialogResult.Yes)//ダイアログでYesを入力したら
                {
                    using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
                    {
                        con.Open();
                        using (SQLiteTransaction trans = con.BeginTransaction())
                        {
                            SQLiteCommand cmd = con.CreateCommand();
                            // インサート
                            cmd.CommandText = "UPDATE t_product set student_name = @sname,attendance_number = @a_number WHERE no = @no;";
                            // パラメータセット
                            cmd.Parameters.Add("sname", DbType.String);
                            cmd.Parameters.Add("a_number", DbType.Int64);
                            cmd.Parameters.Add("no", DbType.Int64);
                            // データ修正
                            cmd.Parameters["no"].Value = int.Parse(textBox1.Text);
                            cmd.Parameters["a_number"].Value = int.Parse(textBox2.Text);
                            cmd.Parameters["sname"].Value = textBox3.Text;
                            cmd.ExecuteNonQuery();
                            // コミット
                            trans.Commit();

                            var dataTable = new DataTable();//DataTableを作成

                            var adapter = new SQLiteDataAdapter("SELECT * FROM t_product WHERE t_product.no LIKE " + serch_no, con);//SQLの実行
                            adapter.Fill(dataTable);//行を取得
                            dataGridView1.DataSource = dataTable;//グリッドビューに表示
                                                                 //dataGridView1.Columns[0].HeaderText = "はじめの列";
                        }
                    }
                }
            }
            else//ダイアログでNoを入力したら
            {
                DialogResult result2 = MessageBox.Show("記入漏れがあります。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_button_Click(object sender, EventArgs e)//削除ボタン
        {
            if (!String.IsNullOrEmpty(textBox1.Text))//空白じゃなかったらtrue
            {
                DialogResult result = MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //ダイアログの選択結果をresultに入れる

                if (result == DialogResult.Yes)//ダイアログでYesを入力したら
                {
                    using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
                    {
                        con.Open();
                        using (SQLiteTransaction trans = con.BeginTransaction())
                        {
                            SQLiteCommand cmd = con.CreateCommand();
                            // インサート
                            cmd.CommandText = "DELETE FROM t_product WHERE No = @no;";
                            // パラメータセット
                            cmd.Parameters.Add("no", DbType.Int64);
                            // データ削除
                            cmd.Parameters["no"].Value = int.Parse(textBox1.Text);
                            cmd.ExecuteNonQuery();
                            // コミット
                            trans.Commit();

                            this.Close();//画面を閉じる
                            main_menu mm = new main_menu();//main_menuをmmと定義
                            mm.Visible = true;//main_menuを表示
                        }
                    }
                }
            }
            else
            {
                DialogResult result2 = MessageBox.Show("削除したいデータを検索してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            }
        }
    }
}