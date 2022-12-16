using System;
using System.Windows.Forms;

namespace Gp_app
{
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
            ControlBox = false;
        }
        private void Creation_account_button_Click(object sender, EventArgs e)//登録画面移動ボタン
        {
            creation_account ca = new creation_account();
            //creation_accountをcaと定義

            ca.Show();
            //creation_accountを呼び出す

            this.Visible = false;
            //main_menuを非表示
        }
        private void Exit_button_Click(object sender, EventArgs e)//終了ボタン
        {
            DialogResult result = MessageBox.Show("本当に終了しますか？","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Question); 
            //ダイアログの選択結果をresultに入れる

            if(result == System.Windows.Forms.DialogResult.Yes)//ダイアログでYesを入力したら
            {
                Application.Exit();
                //アプリケーションの終了
            }
        }
        private void Search_button_Click(object sender, EventArgs e)//検索ボタン
        {
            this.Visible = false;
            //画面非表示

            search_menu_mk2 sm = new search_menu_mk2();
            //search_menu_mk2をsmと定義

            sm.Show();
            //search_menu_mk2を呼び出す
        }
        private void DB_button_Click(object sender, EventArgs e)//DB画面ボタン
        {
            this.Visible = false;
            //画面非表示

            Form1 f1 = new Form1();
            //Form1をf1と定義

            f1.Show();
            //Form1を呼び出す
        }
    }
}