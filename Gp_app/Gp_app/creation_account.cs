using System;
using System.Data;
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

            if (result == DialogResult.Yes)//ダイアログでYesを入力したら
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

            if (result == DialogResult.Yes)//ダイアログでYesを入力したら
            {   
                main_menu mm = new main_menu();
                //main_menuをmmと定義

                mm.Visible = true;
                //main_menuを表示

                DateTime dt = DateTime.Now;
                //現在時刻を取得

                using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))//students.dbをconと定義
                {
                    con.Open();//students.dbを開いて操作できる状態にする
                    using (SQLiteTransaction trans = con.BeginTransaction()){
                        SQLiteCommand cmd = con.CreateCommand();
                        //インサート
                        cmd.CommandText = "INSERT INTO t_product (no,email_address,student_name,sex,department,school_year,class,attendance_number,club_name,registered_date)" +
                                                       " VALUES (@No,@Email_address,@Student_name,@Sex,@Department,@School_year,@Class,@Attendance_number,@Club_name,@Rgis_date)";
                        //パラメータリセット
                        cmd.Parameters.Add("No", DbType.Int32);//学籍番号
                        cmd.Parameters.Add("Email_address", DbType.String);//メルアド
                        cmd.Parameters.Add("Student_name", DbType.String);//名前
                        cmd.Parameters.Add("Sex", DbType.String);//性別
                        cmd.Parameters.Add("Department", DbType.String);//学科
                        cmd.Parameters.Add("School_year", DbType.String);//学年
                        cmd.Parameters.Add("Class", DbType.String);//クラス
                        cmd.Parameters.Add("Attendance_number", DbType.Int32);//出席番号
                        cmd.Parameters.Add("Club_name", DbType.String);//クラブ名
                        cmd.Parameters.Add("Rgis_date", DbType.DateTime);//登録日時
                        //データ追加
                        cmd.Parameters["No"].Value = nobox.Text;//学籍番号
                        cmd.Parameters["Email_address"].Value = textBox2.Text;//メルアド
                        cmd.Parameters["Student_name"].Value = textBox3.Text;//名前
                        cmd.Parameters["Sex"].Value = comboBox5.SelectedItem;//性別
                        cmd.Parameters["Department"].Value = comboBox1.SelectedItem.ToString();//学科
                        cmd.Parameters["School_year"].Value = comboBox2.SelectedItem.ToString();//学年
                        cmd.Parameters["Class"].Value = comboBox3.SelectedItem.ToString();//クラス
                        cmd.Parameters["Attendance_number"].Value = textBox4.Text;//出席番号
                        cmd.Parameters["Club_name"].Value = comboBox4.SelectedItem.ToString();//クラブ名
                        cmd.Parameters["Rgis_date"].Value = dt;//登録日時
                        cmd.ExecuteNonQuery();
                        //コミット
                        trans.Commit();
                    }
                }
                this.Close();
                //画面を閉じる
            }
        }

    }
}