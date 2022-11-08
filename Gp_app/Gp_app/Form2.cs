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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)//フォーム画面
        {

        }
        private void button1_Click(object sender, EventArgs e)//戻るボタン
        {
            Form1 f1 = new Form1();//Form1をf1と定義
            f1.Visible = true;//Form1を表示
            this.Close();//Form2を閉じる
        }
        private void textBox1_TextChanged(object sender, EventArgs e)//学籍番号
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)//メルアド
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)//名前
        {

        }
    }
}
