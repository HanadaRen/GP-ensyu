using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(PasswordBox.Text == "8899")
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
            }
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        private void EndButton_Click(object sender, EventArgs e)
        {
            //ダイアログの選択結果をresultに入れる
            DialogResult result = MessageBox.Show("本当に終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //ダイアログでYesを入力したら
            if (result == DialogResult.Yes)
            {
                //アプリケーションの終了
                Application.Exit();
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            PasswordBox.UseSystemPasswordChar = !PasswordBox.UseSystemPasswordChar;
        }
    }
}
