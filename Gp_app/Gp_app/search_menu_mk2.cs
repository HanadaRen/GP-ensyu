using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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
            string serch_no = textBox1.Text;//テキストボックスの内容をserch_noに入れる
            using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
            {   //DataTableを作成します。
                var dataTable = new DataTable();
                //SQLの実行
                var adapter = new SQLiteDataAdapter("SELECT * FROM t_product WHERE t_product.no LIKE " + serch_no,con);
                adapter.Fill(dataTable);//行を取得
                dataGridView1.DataSource = dataTable;//グリッドビューに表示
            }
        }

        private void button1_Click(object sender, EventArgs e)//終了ボタン
        {
            DialogResult result = MessageBox.Show("入力したデータがすべて消えます。本当に戻りますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //ダイアログの選択結果をresultに入れる

            if (result == DialogResult.Yes)//ダイアログでYesを入力したら
            {
                this.Close();//画面を閉じる
                main_menu mm = new main_menu();//main_menuをmmと定義
                mm.Visible = true;//main_menuを表示
            }
        }
    }
}
