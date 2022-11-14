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

namespace Gp_app.Properties
{
    public partial class db_test : Form
    {
        public db_test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var con = new SQLiteConnection("Data Souce = students_db"))
            {
                con.Open();
                using (SQLiteCommand command = con.CreateCommand())
                {
                    command.CommandText =
                        "create table t_product(CD INTEGER  PRIMARY KEY AUTOINCREMENT, price INTEGER)";
                    command.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
