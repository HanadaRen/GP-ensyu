using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;

namespace Gp_app
{
    public partial class SearchMenu : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public SearchMenu()
        {
            InitializeComponent();
            ControlBox = false;//右上の_□×非表示
            this.Load += SearchStart;//searchstart呼び出し
        }

        /// <summary>
        /// 検索ボタン
        /// </summary>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            //テキストボックスの内容をserch_Noに入れる
            string serch_No = textBox1.Text;

            //空白じゃなかったらtrue
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
                {
                    //DataTableを作成
                    var dataTable = new DataTable();

                    //SQLの実行
                    var adapter = new SQLiteDataAdapter("SELECT * FROM t_product WHERE t_product.no LIKE " + serch_No, con);

                    //行を取得
                    adapter.Fill(dataTable);

                    //グリッドビューに表示
                    dataGridView1.DataSource = dataTable;
                }
            }
            //空白だと
            else
            {
                //ダイアログの選択結果をresultに入れる
                DialogResult result = MessageBox.Show("数字を入力してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        private void ReturnButtonClick(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();

            //main_menuをmmと定義
            MainMenu mainMenu = new MainMenu();

            //main_menuを表示
            mainMenu.Visible = true;
        }
        private void FixButtonClick(object sender, EventArgs e)//修正ボタン
        {
            //空白じゃなかったらtrue
            if (!String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox2.Text) &&
                !String.IsNullOrEmpty(textBox3.Text))
            {
                //テキストボックスの内容をserch_noに入れる
                string serch_No = textBox1.Text;

                //ダイアログの選択結果をresultに入れる
                DialogResult result = MessageBox.Show("この内容で修正しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //ダイアログでYesを入力したら
                if (result == DialogResult.Yes)
                {
                    using (SQLiteConnection studentsDb = new SQLiteConnection("Data Source=students.db"))
                    {
                        studentsDb.Open();
                        using (SQLiteTransaction trans = studentsDb.BeginTransaction())
                        {
                            SQLiteCommand cmd = studentsDb.CreateCommand();
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

                            //DataTableを作成
                            var dataTable = new DataTable();

                            //SQLの実行
                            var adapter = new SQLiteDataAdapter("SELECT * FROM t_product WHERE t_product.no LIKE " + serch_No, studentsDb);

                            //行を取得
                            adapter.Fill(dataTable);

                            //グリッドビューに表示
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            //ダイアログでNoを入力したら
            else
            {
                DialogResult result2 = MessageBox.Show("記入漏れがあります。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 削除ボタン
        /// </summary>
        private void DeleteButtonClick(object sender, EventArgs e)
        {
            //空白じゃなかったらtrue
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                //ダイアログの選択結果をresultに入れる
                DialogResult result = MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //ダイアログでYesを入力したら
                if (result == DialogResult.No)
                {
                    DialogResult result2 = MessageBox.Show("削除したいデータを検索してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
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

                        //画面を閉じる
                        this.Close();

                        //main_menuをmmと定義
                        MainMenu mm = new MainMenu();

                        //main_menuを表示
                        mm.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// データグリッドビューに一覧を表示
        /// </summary>
        private void SearchStart(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
            {   //DataTableを作成します。
                var dataTable = new DataTable();
                //SQLの実行
                var adapter = new SQLiteDataAdapter("SELECT* FROM t_product ", con);
                adapter.Fill(dataTable);

                //列名を付けた
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
    }
}