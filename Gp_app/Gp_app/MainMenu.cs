using System;
using System.Windows.Forms;

namespace Gp_app
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            ControlBox = false;
        }

        /// <summary>
        /// 登録画面移動ボタン
        /// </summary>
        private void CreationAccountButtonClick(object sender, EventArgs e)
        {
            //creation_accountをcaと定義
            CreationAccount creationAccount = new CreationAccount();

            //creation_accountを呼び出す
            creationAccount.Show();

            //main_menuを非表示
            this.Visible = false;
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        private void ExitButtonClick(object sender, EventArgs e)
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
        /// 検索ボタン
        /// </summary>
        private void SearchButtonClick(object sender, EventArgs e)
        {
            //画面非表示
            this.Visible = false;

            //search_menu_mk2をsmと定義
            SearchMenu searchMenu = new SearchMenu();

            //search_menu_mk2を呼び出す
            searchMenu.Show();
        }

        /// <summary>
        /// DB画面ボタン
        /// </summary>
        private void DbButtonClick(object sender, EventArgs e)
        {
            //画面非表示
            this.Visible = false;

            //Form1をf1と定義
            Form1 form1 = new Form1();

            //Form1を呼び出す
            form1.Show();
        }
    }
}