using System;
using System.Data;
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

            if (!String.IsNullOrEmpty(textBox1.Text))//空白じゃなかったらtrue
            {
                using (SQLiteConnection con = new SQLiteConnection("Data Source=students.db"))
                {
                    var dataTable = new DataTable();//DataTableを作成
                    var adapter = new SQLiteDataAdapter("SELECT * FROM t_product WHERE t_product.no LIKE " + serch_no, con);//SQLの実行
                    adapter.Fill(dataTable);//行を取得
                    dataGridView1.DataSource = dataTable;//グリッドビューに表示
                }
            }
            else//空白だとfalse
            {
                DialogResult result = MessageBox.Show("数字を入力してください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ダイアログの選択結果をresultに入れる
            }

        }

        private void button1_Click(object sender, EventArgs e)//終了ボタン
        {
                this.Close();//画面を閉じる
                main_menu mm = new main_menu();//main_menuをmmと定義
                mm.Visible = true;//main_menuを表示
        }
    }
}