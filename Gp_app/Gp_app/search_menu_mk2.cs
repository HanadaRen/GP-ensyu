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
    public partial class search_menu_mk2 : Form
    {
        public search_menu_mk2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//検索ボタン
        {

        }

        private void button1_Click(object sender, EventArgs e)//終了ボタン
        {
            DialogResult result = MessageBox.Show("入力したデータがすべて消えます。本当に戻りますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //ダイアログの選択結果をresultに入れる

            if (result == System.Windows.Forms.DialogResult.Yes)//ダイアログでYesを入力したら
            {
                this.Close();//画面を閉じる
                main_menu mm = new main_menu();//main_menuをmmと定義
                mm.Visible = true;//main_menuを表示
            }
        }
    }
}
