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

        /// <summary>
        /// ログインボタン
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            //ログイン画面を表示
            login.Show();

            //スタートメニューを非表示
            this.Visible = false;
        }

        /// <summary>
        /// アカウント登録ボタン
        /// </summary>
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            //スタートメニューを非表示
            this.Visible = false;

            RegisterMenu registerMenu = new RegisterMenu();

            //アカウント登録画面を表示
            registerMenu.Show();
        }
    }
}