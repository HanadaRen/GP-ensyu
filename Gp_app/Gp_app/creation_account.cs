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
    public partial class creation_account : Form
    {
        public creation_account()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//戻るボタン
        {
            DialogResult result = MessageBox.Show("入力したデータがすべて消えます。本当に戻りますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //ダイアログの選択結果をresultに入れる

            if (result == System.Windows.Forms.DialogResult.Yes)//ダイアログでYesを入力したら
            {
                this.Close();
                //画面を閉じる

                main_menu mm = new main_menu();
                //main_menuをmmと定義

                mm.Visible = true;
                //main_menuを表示
            }
        }

        private void button2_Click(object sender, EventArgs e)//登録ボタン
        {
            DialogResult result = MessageBox.Show("このデータで登録を完了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //ダイアログの選択結果をresultに入れる

            if (result == System.Windows.Forms.DialogResult.Yes)//ダイアログでYesを入力したら
            {
                this.Close();
                //画面を閉じる

                main_menu mm = new main_menu();
                //main_menuをmmと定義

                mm.Visible = true;
                //main_menuを表示

                using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))//students.dbをconと定義
                {
                    con.Open();//students.dbを開いて操作できる状態にする
                    using (SQLiteTransaction trans = con.BeginTransaction())
                    {
                        SQLiteCommand cmd = con.CreateCommand();
                        //インサート
                        cmd.CommandText = "INSERT INTO t_product (no,email_address,student_name,sex,department,school_year,class,attendance_number,club_name) VALUES (@No, @Email, @Student,@Sex,@Department,@School,@Class,@Attendance,@Club)";
                        //パラメータセット
                        cmd.Parameters.Add("Product", System.Data.DbType.String);
                        cmd.Parameters.Add("Price", System.Data.DbType.Int64);
                        //データ追加
                        cmd.Parameters["No"].Value = int.Parse(textBox1.Text);
                        cmd.Parameters["Email"].Value = textBox2.Text;
                        cmd.Parameters["Student"].Value = textBox3.Text;
                        cmd.Parameters["Sex"].Value = radioButton1.Checked;
                        cmd.Parameters["Sex"].Value = radioButton2.Checked;
                        cmd.Parameters["Sex"].Value = radioButton3.Checked;
                        cmd.Parameters["Department"].Value = comboBox1.Items;
                        cmd.Parameters["School"].Value = comboBox2.Items;
                        cmd.Parameters["Class"].Value = comboBox3.Items;
                        cmd.Parameters["Attendance"].Value = int.Parse(textBox4.Text);
                        cmd.Parameters["Club"].Value = comboBox4.Items;
                        cmd.ExecuteNonQuery();
                        //コミット
                        trans.Commit();
                    }
                }
            }
        }
    }
}