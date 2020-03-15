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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            
            if (textBox1.Text == " Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor=Color.Black;
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

        private void Button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            DataBaseConnection db = new DataBaseConnection();
            string query_count = "SELECT Count(*) FROM users WHERE username='" + username + "' " +
                                 "AND password ='"+password+"'";
            if (db.Count(query_count) == 1)
            {
                Form3 f3 = new Form3(username);
                f3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
