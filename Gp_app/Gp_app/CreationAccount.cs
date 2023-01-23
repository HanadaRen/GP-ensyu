using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;

namespace Gp_app
{
    public partial class CreationAccount : Form
    {
        public CreationAccount()
        {
            InitializeComponent();
            ControlBox = false;
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        private void ReturnButtonClick(object sender, EventArgs e)
        {
            //ダイアログの選択結果をresultに入れる
            DialogResult result = MessageBox.Show("入力したデータがすべて消えます。本当に戻りますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //ダイアログでYesを入力したら
            if (result == DialogResult.Yes)
            {
                //画面を閉じる
                this.Close();

                //main_menuをmmと定義
                MainMenu mainMenu = new MainMenu();

                //main_menuを表示
                mainMenu.Visible = true;
            }
        }

        /// <summary>
        /// 登録ボタン
        /// </summary>
        private void RegisterButtonClick(object sender, EventArgs e)
        {
            //ダイアログの選択結果をresultに入れる
            DialogResult result = MessageBox.Show("このデータで登録を完了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            TextBox[] txtArray = { textBox1, textBox2, textBox3, textBox4 };
            ComboBox[] cmbArray = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5 };

            foreach (TextBox i in txtArray)
            {
                if (String.IsNullOrEmpty(i.Text))
                {
                    i.BackColor = Color.Red;
                }
                else
                {
                    i.BackColor = Color.White;

                }
            }

            foreach (ComboBox i in cmbArray)
            {
                if (String.IsNullOrEmpty(i.Text))
                {
                    i.BackColor = Color.Red;
                }
                else
                {
                    i.BackColor = Color.White;
                }
            }

            //ダイアログでYesを入力したら
            if (result == DialogResult.Yes)
            {
                //main_menuをmmと定義
                MainMenu mainMenu = new MainMenu();

                //main_menuを表示
                mainMenu.Visible = true;

                //現在時刻を取得
                DateTime dateTime = DateTime.Now;

                //students.dbをconと定義
                using (SQLiteConnection studentsDb = new SQLiteConnection("Data Source=students.db"))
                {
                    //students.dbを開いて操作できる状態にする
                    studentsDb.Open();
                    using (SQLiteTransaction trans = studentsDb.BeginTransaction())
                    {
                        //インサート
                        SQLiteCommand cmd = studentsDb.CreateCommand();

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
                        cmd.Parameters["No"].Value = textBox1.Text;//学籍番号
                        cmd.Parameters["Email_address"].Value = textBox2.Text;//メルアド
                        cmd.Parameters["Student_name"].Value = textBox3.Text;//名前
                        cmd.Parameters["Sex"].Value = comboBox5.SelectedItem;//性別
                        cmd.Parameters["Department"].Value = comboBox1.SelectedItem.ToString();//学科
                        cmd.Parameters["School_year"].Value = comboBox2.SelectedItem.ToString();//学年
                        cmd.Parameters["Class"].Value = comboBox3.SelectedItem.ToString();//クラス
                        cmd.Parameters["Attendance_number"].Value = textBox4.Text;//出席番号
                        cmd.Parameters["Club_name"].Value = comboBox4.SelectedItem.ToString();//クラブ名
                        cmd.Parameters["Rgis_date"].Value = dateTime;//登録日時
                        cmd.ExecuteNonQuery();
                        //コミット
                        trans.Commit();
                    }
                }
                this.Close();
                //画面を閉じる
            }
        }

        /// <summary>
        /// 実験
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] txtArray = { textBox1, textBox2, textBox3, textBox4 };
            ComboBox[] cmbArray = { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5 };

            foreach (TextBox i in txtArray)
            {
                if (String.IsNullOrEmpty(i.Text))
                {
                    i.BackColor = Color.Red;
                }
                else
                {
                    i.BackColor = Color.White;
                }
            }

            foreach (ComboBox i in cmbArray)
            {
                if (String.IsNullOrEmpty(i.Text))
                {
                    i.BackColor = Color.Red;
                }
                else
                {
                    i.BackColor = Color.White;
                }
            }
        }
    }
}