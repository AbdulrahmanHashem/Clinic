using System;
using System.Windows.Forms;

namespace Clinic
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            var z = usersTableAdapter.GetAllUsers();
            if (z.Count == 0)
            {
                usersTableAdapter.InsertUser(1, "Admin", "Admin", "", true);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var x = this.usersTableAdapter.GetUserByName(textBox1.Text, textBox2.Text);

            if (x.Count == 0)
            {
                MessageBox.Show("You Aren't Registered. ", "Info");
            }
            else
            {
                Patient patient = new Patient();
                patient.Show();
                this.Hide();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var z = this.usersTableAdapter.GetAllUsers();
            if (z.Count == 0)
            {
                Sign_up sign_Up = new Sign_up();
                sign_Up.Show();
                this.Hide();
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter Your UserName and Password.", "Error");
                }
                else
                {
                    var x = this.usersTableAdapter.GetUserByName(textBox1.Text, textBox2.Text);
                    if (x.Count == 1)
                    {
                        Sign_up sign_Up = new Sign_up();
                        sign_Up.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You Aren't registered or Your Username and Password are Incorrect.", "Error");
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var z = this.usersTableAdapter.GetAllUsers();
            if (z.Count == 0)
            {
                Admin_Control admin_Control = new Admin_Control();
                admin_Control.Show();
                this.Hide();
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter Your UserName and Password.", "Error");
                }
                else
                {
                    var x = this.usersTableAdapter.GetUserByName(textBox1.Text, textBox2.Text);
                    if (x.Count == 1)
                    {
                        Admin_Control admin_Control = new Admin_Control();
                        admin_Control.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("You Aren't registered or Your Username and Password are Incorrect.", "Error");
                    }
                }
            }
        }
    }
}
