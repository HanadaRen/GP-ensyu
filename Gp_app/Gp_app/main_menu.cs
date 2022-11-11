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
            creation_account f2 = new creation_account();//Form2をf2と定義
            f2.Show();//Form2を呼び出す
            this.Visible = false;//Form1を非表示
        }
        private void button3_Click(object sender, EventArgs e)//終了ボタン
        {
            dialog f4 = new dialog();//Foem4をf4と定義
            f4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search_menu sm = new search_menu();

            sm.Show();

            this.Visible = false;
        }
    }
}
