﻿using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Gp_app
{
    public partial class delete_menu : Form
    {
        public delete_menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//削除ボタン
        {
            DialogResult result = MessageBox.Show("本当に削除しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //ダイアログの選択結果をresultに入れる

            if (!String.IsNullOrEmpty(textBox1.Text))//空白じゃなかったらtrue
            {
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
            else//空白だとfalse
            {
                DialogResult result2 = MessageBox.Show("数字を入力してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ダイアログの選択結果をresultに入れる
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
