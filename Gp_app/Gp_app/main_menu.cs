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
    public partial class main_menu : Form
    {
        public main_menu()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//登録画面移動ボタン
        {
            creation_account ca = new creation_account();
            //creation_accountをcaと定義

            ca.Show();
            //creation_accountを呼び出す

            this.Visible = false;
            //main_menuを非表示
        }
        private void button3_Click(object sender, EventArgs e)//終了ボタン
        {
            DialogResult result = MessageBox.Show("本当に終了しますか？","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Question); 
            //ダイアログの選択結果をresultに入れる

            if(result == System.Windows.Forms.DialogResult.Yes)//ダイアログでYesを入力したら
            {
                Application.Exit();
                //アプリケーションの終了
            }
        }

        private void button2_Click(object sender, EventArgs e)//検索ボタン
        {
            this.Visible = false;
            //画面非表示

            search_menu_mk2 sm = new search_menu_mk2();
            //search_menu_mk2をsmと定義

            sm.Show();
            //search_menu_mk2を呼び出す
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //画面非表示

            Form1 f1 = new Form1();

            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)//変更ボタン
        {
            this.Visible = false;
            //画面非表示

            fix_menu fix_Menu = new fix_menu();

            fix_Menu.Show();
        }

        private void button6_Click(object sender, EventArgs e)//削除ボタン
        {
            this.Visible = false;
            //画面非表示

            delete_menu delete_Menu = new delete_menu();

            delete_Menu.Show();
        }
    }
}