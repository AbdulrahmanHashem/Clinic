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
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            if (checkBoxClear.Checked == true)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                label7.Text = "";
                label8.Text = "";
                dateTimePicker1.Value = DateTime.Today;
            }
        }
        public void Insert()
        {
            int x;
            var z = this.billingTableAdapter.GetAllBills();
            if (z.Count == 0)
            {
                x = 1;
            }
            else
            {
                x = Convert.ToInt32(z.Last().BillingID) + 1;
            }

            this.billingTableAdapter.InsertBill(Convert.ToString(x), label7.Text, textBox2.Text, label8.Text, dateTimePicker1.Text, textBox3.Text);
            MessageBox.Show($"Bill Added Under ID {x} .", "Success");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || label7.Text == "" || label8.Text == "" )
            {
                MessageBox.Show("Make Sure The Bill Info Is Complete.", "Error");
            }
            else
            {
                var t = this.appointmentsTableAdapter.GetAppointmentByID(label7.Text);
                var i = billingTableAdapter.GetBillByAppointmentNumber(textBox2.Text);
                if (t.First().SecondVisitation == "yes" && t.First().FirstVisitation == "yes" && i.Count > 1)
                {
                        MessageBox.Show("This Appointment Is Already Billed For Both Visitations", "Error");
                }
                else if (t.First().SecondVisitation == "no" && t.First().FirstVisitation == "yes" && i.Count == 1)
                {
                    MessageBox.Show("The First Visitation of This Appointment is Already Billed", "Error");
                }
                else if (t.First().SecondVisitation == "yes" && t.First().FirstVisitation == "yes" && i.Count == 1)
                {
                    Insert();
                    MessageBox.Show("This is The Bill Of The Second and Last Visitation for this Appointment.", "Warning");
                }
                else
                {
                    Insert();
                    MessageBox.Show("This is The Bill Of The First Visitation for this Appointment.", "Warning");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Make Sure The Bill Info Is Complete ... !", "Error");
            }
            else
            {
                var z = this.billingTableAdapter.GetBillByBillAndPatientID(textBox1.Text, label7.Text);
                if (z.Count == 1)
                {
                    this.billingTableAdapter.UpdateBill(label7.Text, textBox2.Text, label8.Text, dateTimePicker1.Text, textBox3.Text, textBox1.Text);
                    MessageBox.Show("Bill Edited.", "Success");
                }
                else
                {
                    MessageBox.Show("Search For The Bill Before Editing", "Error");
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || label7.Text == "" || label8.Text == "")
            {
                MessageBox.Show("Search For The Bill You Want To Delete ... !", "Error");
            }
            else
            {
                var z = this.billingTableAdapter.GetBillByBillAndPatientID(textBox1.Text, label7.Text);
                if (z.Count == 1)
                {
                    var Bills = billingTableAdapter.GetBillByAppointmentNumber(textBox2.Text);
                    if (Bills.Count > 1)
                    {

                    }
                    this.billingTableAdapter.DeleteBill(textBox1.Text);
                    MessageBox.Show("Bill Deleted.", "Success");
                }
                else
                {
                    MessageBox.Show("Search For The Bill Before Editing", "Error");
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Bill ID","Error");
            }
            else
            {
                var x = this.billingTableAdapter.GetBillByID(textBox1.Text);
                if (x.Count == 1)
                {
                    textBox1.Text = x.First().BillingID;
                    textBox2.Text = x.First().AppointmentNumber;
                    label7.Text = x.First().PatientID;
                    label8.Text = x.First().PatientName;
                    dateTimePicker1.Text = x.First().BillingDate;
                    textBox3.Text = x.First().TotalBill;
                }
                else
                {
                    MessageBox.Show("This Bill Number isn't Registered. ","Not Found!");
                }
                
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Appointment Number .", "Error");
            }
            else
            {
                var x = this.appointmentsTableAdapter.GetAppointmentByNumber(textBox2.Text);
                if (x.Count == 1)
                {
                    label7.Text = x.First().PatientID;
                    var z = this.patientsTableAdapter.GetPatientByID(x.First().PatientID);
                    label8.Text = z.First().Name;
                }
                else
                {
                    MessageBox.Show("There's No Appointment With This Number. ", "Not Found!");
                }

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void checkBoxClear_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
