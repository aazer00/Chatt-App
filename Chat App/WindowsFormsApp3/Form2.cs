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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string email = textBox3.Text;
            string password = textBox2.Text;
            string repass = textBox4.Text;
            DataBaseConnection db = new DataBaseConnection();
            string query_count = "SELECT Count(*) FROM users WHERE username='"+username+"'";
            if (db.Count(query_count) == 1)
            {
                MessageBox.Show("Username Already Taken!!!");
            }
            else
            if (password == repass && username != "" && email != "" && password != "")
            {
                string query = "INSERT INTO users (username, email, password) VALUES('" + username + "', '" + email + "', '" + password + "')";
                db.Insert(query);
                Form1 f1 = new Form1();
                this.Close();
                f1.Show();
            }
            else
            {
                MessageBox.Show("Invalid Registration!!!");
            }
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {

            if (textBox1.Text == " Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = " Username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {

            if (textBox2.Text == " Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = " Password";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = '\0';
            }
        }

        private void TextBox3_Enter(object sender, EventArgs e)
        {

            if (textBox3.Text == " Email")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = " Email";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void TextBox4_Enter(object sender, EventArgs e)
        {

            if (textBox4.Text == " Re - Password")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
                textBox4.PasswordChar = '*';
            }
        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = " Re - Password";
                textBox4.ForeColor = Color.Silver;
                textBox4.PasswordChar = '\0';
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
