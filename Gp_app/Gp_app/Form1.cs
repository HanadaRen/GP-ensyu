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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        private void Form1_Load(object sender, EventArgs e)//フォーム画面
        {

        }

        private void button1_Click(object sender, EventArgs e)//登録画面移動ボタン
        {
            Form2 f2 = new Form2();//Form2をf2と定義
            f2.Show();//Form2を呼び出す
            this.Visible = false;//Form1を非表示
        }

        private void button2_Click(object sender, EventArgs e)//検索画面ボタン
        {

        }

        private void button3_Click(object sender, EventArgs e)//終了ボタン
        {
            Application.Exit();//終了
        }
    }
}
