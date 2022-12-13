using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Gp_app
{
    public partial class fix_menu : Form
    {
        public fix_menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//変更ボタン
        {
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
                        cmd.Parameters["sname"].Value = textBox1.Text;
                        cmd.Parameters["a_number"].Value = int.Parse(textBox2.Text);
                        cmd.Parameters["no"].Value = int.Parse(textBox3.Text);
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

        private void button2_Click(object sender, EventArgs e)//戻るボタン
        {
            DialogResult result = MessageBox.Show("入力したデータがすべて消えます。本当に戻りますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //ダイアログの選択結果をresultに入れる

            if (result == DialogResult.Yes)//ダイアログでYesを入力したら
            {
                this.Close();//画面を閉じる
                main_menu mm = new main_menu();//main_menuをmmと定義
                mm.Visible = true;//main_menuを表示
            }
        }
    }
    
}
