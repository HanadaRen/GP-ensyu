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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var con = new SQLiteConnection("Data Source=test.db"))
            {
                con.Open();
                using (SQLiteCommand command = con.CreateCommand())
                {
                    command.CommandText =
                        "create table t_product(CD INTEGER PRYMARY KEY AUTOINCREMENT, productname TEXT,price INTEGER)";
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection("Data Source=test.db"))
            {
                con.Open();
                using(SQLiteTransaction trans = con.BeginTransaction())
                {
                    SQLiteCommand cmd = con.CreateCommand();

                    cmd.CommandText = "INCERT INTO t_product (productname, price) VALUES (@Product, @Price)";

                    cmd.Parameters.Add("Product", System.Data.DbType.String);
                    cmd.Parameters.Add("Price",  System.Data.DbType.Int64);

                    cmd.Parameters["Product"].Value = textBox1.Text;
                    cmd.Parameters["Price"].Value = int.Parse(textBox2.Text);
                    cmd.ExecuteNonQuery();

                    trans.Commit();
                }
            }
        }
    }
}
