using System;
using System.Windows.Forms;
using System.IO;

namespace Gp_app
{
    public partial class RegisterMenu : Form
    {
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
            this.Close();

            StartMenu startMenu = new StartMenu();

            startMenu.Visible = true;
        }

        /// <summary>
        /// 登録ボタン
        /// </summary>
        private void RegistButton_Click(object sender, EventArgs e)
        {
            if(UserNameBox.Text == "" || PasswordBox.Text == "" || VerificationBox.Text == "" )
            {
                MessageBox.Show("空欄があります", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(PasswordBox.Text != VerificationBox.Text)
            {
                MessageBox.Show("パスワードが確認されたものと一致しません。もう一度入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordBox.Text = "";
                VerificationBox.Text = "";
            }
            else
            {
                StreamWriter streamWriter = new StreamWriter(@"K:\科目\10_GP演習\最終提出物フォルダ\システム\G2A130花田琉\Gp_app\" + "accounts.csv",true);
                string s = UserNameBox.Text + "," + PasswordBox.Text;
                streamWriter.WriteLine(s);
                streamWriter.Close();

                MessageBox.Show("登録しました", "確認",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                UserNameBox.Text = "";
                PasswordBox.Text = "";
                VerificationBox.Text = "";
                VerificationBox.Text = "";
            }
        }
    }
}
