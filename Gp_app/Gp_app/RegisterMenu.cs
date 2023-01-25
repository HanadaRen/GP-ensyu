using System;
using System.Windows.Forms;
using System.IO;

namespace Gp_app
{
    public partial class RegisterMenu : Form
    {
        StartMenu StartMenu = null;
        public RegisterMenu()
        {
            InitializeComponent();
            ControlBox = false;
        }

        /// <summary>
        /// 戻るボタン
        /// </summary>
        private void ReturnButton_Click(object sender, EventArgs e)
        {
            //アカウント登録画面を閉じる
            this.Close();

            StartMenu startMenu = new StartMenu();

            //スタートメニューを表示
            startMenu.Visible = true;
        }

        /// <summary>
        /// 登録ボタン
        /// </summary>
        private void RegistButton_Click(object sender, EventArgs e)
        {
            //空欄があったら
            if(UserNameBox.Text == "" || PasswordBox.Text == "" || VerificationBox.Text == "" )
            {
                MessageBox.Show("空欄があります", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //空欄がない＋確認パスワードが一致しない場合
            else if(PasswordBox.Text != VerificationBox.Text)
            {
                MessageBox.Show("パスワードが確認されたものと一致しません。もう一度入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //テキストボックスを空にする
                PasswordBox.Text = "";
                VerificationBox.Text = "";
            }
            //すべて正しかったら
            else
            {
                //accounts.csvをstreamReaderに入れる
                StreamWriter streamWriter = new StreamWriter(@"K:\科目\10_GP演習\最終提出物フォルダ\システム\G2A130花田琉\Gp_app\" + "accounts.csv",true);

                //NewInformationにテキストボックスの中身を入れる
                string NewInformation = UserNameBox.Text + "," + PasswordBox.Text;

                //NewInformationの中身をcsvファイルに書き込む
                streamWriter.WriteLine(NewInformation);

                //csvファイルを閉じる
                streamWriter.Close();


                MessageBox.Show("登録しました", "確認",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //スタートメニューを開いてアカウント登録画面を閉じる
                if (StartMenu == null || StartMenu.IsDisposed)
                {
                    StartMenu startMenu = new StartMenu();
                    startMenu.Show();
                }
                this.Close();

            }
        }
    }
}