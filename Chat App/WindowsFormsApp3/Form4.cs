using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
   
    public partial class Form4 : Form
    {
        string username = "";
        string opp = "";
        public Form4(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void TextBox2_Enter(object sender, EventArgs e)
        {

            if (textBox2.Text == " Write Username Here")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;

            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = " Write Username Here";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            opp = textBox2.Text;
            DataBaseConnection db_select = new DataBaseConnection();
            string query1 = "SELECT Count(*) FROM users WHERE username= '" + opp + "'";

            if (db_select.Count(query1) >= 1)
            {
                string query = "INSERT INTO chats (p1, p2) VALUES('"+username+"','" + opp + "')";
                db_select.Insert(query);

                query1 = "SELECT Count(*) FROM chats";
                int number = db_select.Count(query1);
                string room = "c" + number.ToString();
                db_select.create_table(room);

                this.Close();
                Form3 f3 = new Form3(username);
                f3.Show();

            }
            else
            {
                MessageBox.Show("No User Found!!!");
            }

        }
        

       
    }
}
