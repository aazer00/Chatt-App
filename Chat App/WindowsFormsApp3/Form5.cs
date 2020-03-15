using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form5 : Form
    {
        string pin = "";
        public Form5()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string email = textBox3.Text;
            string pass = textBox2.Text;
            string re_pass = textBox4.Text;

            if (pass == re_pass&&email!="")
            {
                try
                {
                    Random r = new Random();
                    pin = (r.Next(700) + 100).ToString();

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("aslanli.azer@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Pin Code";
                    mail.Body = pin;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("aslanli.azer", "0506700680aa");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);

                    Form6 f6 = new Form6(pin,pass,email);
                    f6.Show();
                    this.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

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
    }
}
