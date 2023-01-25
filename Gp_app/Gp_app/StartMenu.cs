using System;
using System.Windows.Forms;

namespace Gp_app
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
            ControlBox = false;
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        private void EnterButton_Click(object sender, EventArgs e)
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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            login.Show();

            this.Visible = false;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterMenu registerMenu = new RegisterMenu();

            registerMenu.Show();
        }
    }
}
