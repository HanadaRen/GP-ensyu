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
    public partial class creation_account : Form
    {
        public creation_account()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//戻るボタン
        {
            main_menu f1 = new main_menu();//Form1をf1と定義
            f1.Visible = true;//Form1を表示
            this.Close();//Form2を閉じる
        }
    }
}
