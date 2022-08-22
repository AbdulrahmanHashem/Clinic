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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            New_Patient new_patient = new New_Patient();
            new_patient.Show();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Show();
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();
            billing.Show();
            this.Close();
        }
    }
}
