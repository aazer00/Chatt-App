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
    public partial class Form6 : Form
    {
        string pin = "";
        string pass = "";
        string email = "";
        public Form6(string pin,string pass,string email)
        {
            this.pin = pin;
            this.pass = pass;
            this.email = email;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == pin)
            {
                DataBaseConnection db = new DataBaseConnection();
                string query = "UPDATE users SET password='"+pass+"' WHERE email='"+email+"'";
                db.Update(query);
                Form1 f1 = new Form1();
                f1.Show();
                this.Close();
                
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private void TextBox2_Enter(object sender, EventArgs e)
        {

            if (textBox4.Text == " PIN - CODE")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
                
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = " PIN - CODE";
                textBox4.ForeColor = Color.Silver;
                
            }
        }
    }
}
