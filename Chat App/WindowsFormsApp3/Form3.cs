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
    public partial class Form3 : Form
    {
        string username="";
        string opp = "";
        string room="";
        bool timer_status = true;
        public Form3(string name)
        {
            username = name;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string mess = textBox1.Text;
            listBox1.Items.Add(username+" : "+mess);
            DataBaseConnection db = new DataBaseConnection();
            string query = "INSERT INTO "+room+" (message, yazan, status) " +
                           "VALUES('" + mess + "', '" + username + "', '" + "0" + "')";
            db.Insert(query);
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = username;
            DataBaseConnection db = new DataBaseConnection();
            List<string>[] list;  

            string query1 = "SELECT Count(*) FROM chats WHERE p1 = '" + username + "'";
            string query2 = "SELECT Count(*) FROM chats WHERE p2 = '" + username + "'";

            string query11 = "SELECT * FROM chats WHERE p1 = '" + username + "'";
            string query21 = "SELECT * FROM chats WHERE p2 = '" + username + "'";
            int y = 0;
            if (db.Count(query1) >= 1)
            {
               // MessageBox.Show("s34d");
                string[] columns = { "id", "p2"};
                list = new List<string>[columns.Length];
                list = db.Select(columns, query11);
                for (int i = 0; i < list[0].Count; i++)
                {
                    Button btn = new Button();
                   // MessageBox.Show(list[1][i]);
                    btn.Text = list[1][i];
                    btn.Location = new Point(btn.Location.X, y);
                    btn.Size = new Size(264, 37);
                    btn.Font = new Font(btn.Font.FontFamily, 14);
                    btn.Name = list[0][i];
                    btn.Click += select_user;
                    y += 37;
                    groupBox3.Controls.Add(btn);
                }
            }
            if (db.Count(query2) >= 1)
            {
               // MessageBox.Show("sd");
                string[] columns = { "id", "p1" };
                list = new List<string>[columns.Length];
                list = db.Select(columns, query21);
                for (int i = 0; i < list[0].Count; i++)
                {
                    Button btn = new Button();
                    //MessageBox.Show(list[1][i]);
                    btn.Text = list[1][i];
                    btn.Location = new Point(btn.Location.X, y);
                    btn.Size = new Size(264, 37);
                    btn.Font = new Font(btn.Font.FontFamily, 14);
                    btn.Name = list[0][i];
                    btn.Click += select_user;
                    y += 37;
                    groupBox3.Controls.Add(btn);
                }
            }


        }

        private void Btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(username);
            f4.Show();
            this.Close();
        }
        private void select_user(object sender, EventArgs e)
        {
            timer_status = false;
            label1.Text = (sender as Button).Text;
            opp = label1.Text;
            room = "c"+(sender as Button).Name;
           // MessageBox.Show(room);

            DataBaseConnection db = new DataBaseConnection();
            List<string>[] list;
            string query1 = "SELECT Count(*) FROM "+room;
            string query11 = "SELECT * FROM "+room;

            if (db.Count(query1) >= 1)
            {
                string[] columns = {"id", "message", "yazan" };
                list = new List<string>[columns.Length];
                list = db.Select(columns, query11);
                for (int i = 0; i < list[0].Count; i++)
                {
                    Button btn = new Button();
                    // MessageBox.Show(list[1][i]);
                    string text = list[2][i] + " : " + list[1][i];
                    listBox1.Items.Add(text);
                    string query = "UPDATE " + room + " SET status='1' WHERE id='" + list[0][i] + "'";
                    db_select.Update(query);
                }
            }
            timer_status = true;

        }
        DataBaseConnection db_select = new DataBaseConnection();
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (username != ""&&opp!=""&&timer_status==true)
            {
                List<string>[] list;
                string query1 = "SELECT Count(*) FROM " + room + " WHERE status=0 AND yazan= '" + opp + "'";
                string query11 = "SELECT * FROM " + room + " WHERE status=0 AND yazan= '" + opp + "'";

                if (db_select.Count(query1) >= 1)
                {
                    string[] columns = { "id", "message", "yazan" };
                    list = new List<string>[columns.Length];
                    list = db_select.Select(columns, query11);
                    for (int i = 0; i < list[0].Count; i++)
                    {
                        Button btn = new Button();
                        string text = list[2][i] + " : " + list[1][i];
                        listBox1.Items.Add(text);

                        string query = "UPDATE " + room + " SET status='1' WHERE id='" + list[0][i] + "'";
                        db_select.Update(query);
                    }


                }
            }
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
