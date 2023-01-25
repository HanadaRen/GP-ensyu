using System;
using System.Windows.Forms;
using System.IO;

namespace Gp_app
{
    public partial class Login : Form
    {
        MainMenu MainMenu = null;
        public Login()
        {
            InitializeComponent();
            ControlBox = false;
        }

        /// <summary>
        /// ログインボタン
        /// </summary>
        private void LoginButtton_Click(object sender, EventArgs e)
        {
            //テキストボックスが空欄だったら
            if(UserNameBox.Text == "" || PasswordBox.Text == "")
            {
                MessageBox.Show("空欄です", "残念",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            //テキストボックスが空欄じゃなかったら
            else
            {
                //アカウント名とパスワードが合ってるか判定
                bool fault = false;

                //accounts.csvをstreamReaderに入れる
                StreamReader streamReader = new StreamReader(@"K:\科目\10_GP演習\最終提出物フォルダ\システム\G2A130花田琉\Gp_app\" + "accounts.csv");
              
                //accounts.csvを上から下まで確認する
                while (streamReader.Peek() > -1)
                {
                    //CsvInsideにcsvの中身を入れる
                    string CsvInside = streamReader.ReadLine();

                    //,で区切る
                    string[] s_array = CsvInside.Split(',');

                    //ユーザー名とパスワードが一致しているか確認
                    if(s_array[0] == UserNameBox.Text && s_array[1] == PasswordBox.Text)
                    {
                        //ユーザー名とパスワードが一致していたらtrue
                        fault = true;
                    }
                }
                //csvファイルを閉じる
                streamReader.Close();

                //ユーザー名とパスワードが一致していなかったら
                if (fault == false)
                {
                    MessageBox.Show("パスワードが一致しませんでした","お知らせ",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    //テキストボックスを空にする
                    UserNameBox.Text = "";
                    PasswordBox.Text = "";
                }
                //ユーザー名とパスワードが一致していたら
                else
                {
                    //メインメニュを開いてログイン画面を閉じる
                    if (MainMenu == null || MainMenu.IsDisposed)
                    {
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Show();
                    }
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        private void EndButton_Click(object sender, EventArgs e)
        {
            //ログイン画面を閉じる
            this.Close();

            StartMenu startMenu = new StartMenu();

            //スタートメニューを表示
            startMenu.Visible = true;
        }

        /// <summary>
        /// パスワードの表示非表示切り替え
        /// </summary>
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            //パスワードの表示非表示切り替え
            PasswordBox.UseSystemPasswordChar = !PasswordBox.UseSystemPasswordChar;
        }
    }
}