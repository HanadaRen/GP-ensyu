using System;
using System.Windows.Forms;
using System.IO;

namespace Gp_app
{
    public partial class Login : Form
    {
        MainMenu MainMenu = null;
        public Login()
        {
            InitializeComponent();
            ControlBox = false;
        }

        /// <summary>
        /// ログインボタン
        /// </summary>
        private void LoginButtton_Click(object sender, EventArgs e)
        {
            /*if(PasswordBox.Text == "8899")
            {
                if(MainMenu == null || IsDisposed)
                {
                    MainMenu = new MainMenu();
                    MainMenu.Show();
                    this.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("パスワードが違うよん", "てめぇ！！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordBox.Text = "";
            }*/

            if(UserNameBox.Text == "" || PasswordBox.Text == "")
            {
                MessageBox.Show("空欄です", "残念",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            else
            {
                bool fault = true;

                StreamReader streamReader = new StreamReader(@"K:\科目\10_GP演習\最終提出物フォルダ\システム\G2A130花田琉\Gp_app\" + "accounts.csv");

                while(streamReader.Peek() > -1)
                {
                    string s = streamReader.ReadLine();

                    string[] s_array = s.Split(',');

                    if(s_array[0] == UserNameBox.Text && s_array[1] == PasswordBox.Text)
                    {
                        fault = false;
                    }
                }
                streamReader.Close();

                if (fault == true)
                {
                    MessageBox.Show("パスワードが一致しませんでした","お知らせ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    UserNameBox.Text = "";
                    PasswordBox.Text = "";
                }
                else
                {
                    if (MainMenu == null || MainMenu.IsDisposed)
                    {
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Show();
                    }
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        private void EndButton_Click(object sender, EventArgs e)
        {
            this.Close();

            StartMenu startMenu = new StartMenu();

            startMenu.Visible = true;
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            PasswordBox.UseSystemPasswordChar = !PasswordBox.UseSystemPasswordChar;
        }
    }
}