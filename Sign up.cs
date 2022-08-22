using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Enter Your Name. ");
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    int x;
                    var z = this.usersTableAdapter.GetAllUsers();
                    if (z.Count == 0)
                    {
                        x = 1;
                    }
                    else
                    {
                        x = (z.Last().userID) + 1;
                    }

                    this.usersTableAdapter.InsertUser(x, textBox1.Text, textBox2.Text, textBox4.Text, false);

                    MessageBox.Show($"Done\nUser ID {x}.", "Info");
                }
                else
                {
                    MessageBox.Show("Make Sure You have the Same Password in both Boxes.", "Something Is Worng");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Login home = new Login();
            home.Show();
            this.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (label5.Text == "")
            {
                MessageBox.Show("Search For User First", "Error");
            }
            else
            {
                this.usersTableAdapter.UpdateUser(textBox1.Text, textBox2.Text, textBox4.Text, false, Convert.ToInt32(label5.Text));
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter Info. ", "Error");
            }
            else
            {
                var x = this.usersTableAdapter.GetUserByName(textBox1.Text, textBox2.Text);
                if (x.Count == 0)
                {
                    MessageBox.Show("You Aren't Registered. ", "Info");
                }
                else
                {
                    label5.Text = Convert.ToString(x.First().userID);
                    textBox1.Text = x.First().userName;
                    textBox2.Text = x.First().userPassword;
                    textBox4.Text = x.First().userMail;
                }
            }
        }
    }
}
