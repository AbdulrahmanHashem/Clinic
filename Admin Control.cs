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
    public partial class Admin_Control : Form
    {
        public Admin_Control()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Login home = new Login();
            home.Show();
            this.Close();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            var z = usersTableAdapter.GetAllUsers();
            if (z.Count == 1)
            {
                usersTableAdapter.UpdateUser(z.First().userName, z.First().userPassword, z.First().userMail, true, z.First().userID);
                MessageBox.Show("You Can't Edit The Table From Here You Need To Add More Users To Edit");
            }
            else
            {
                this.Validate();
                this.usersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.usersDataSet);
                var h = usersTableAdapter.GetAllUsers();
                if (h.Count == 1)
                {
                    h.First().Admin = true;
                    usersTableAdapter.UpdateUser(h.First().userName, h.First().userPassword, h.First().userMail, true, h.First().userID);
                }
            }
        }
        private void Admin_Control_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'usersDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.usersDataSet.Users);
        }
    }
}
