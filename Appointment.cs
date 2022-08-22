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
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void Clear()
        {
            if (checkBoxClear.Checked == true)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var z = this.patientsTableAdapter.GetPatientByID(textBox2.Text); 
            var f = appointmentsTableAdapter.GetAppointmentByID(textBox2.Text);
            string x, y;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Patient ID.", "Error!");
            }
            else if (z.Count == 0)
            {
                MessageBox.Show("Patient Isn't Registered.", "Error!");
            }
            else if (f.Count == 1)
            {
                MessageBox.Show("This Patient Already Has an Appointment.\nPlease Edit or Delete it to Add a New One", "Error!");
            }
            else if (checkBox1.Checked == false)
            {
                MessageBox.Show("This Must Be The First Visitation.", "Error!");
                x = "no";
                y = "no";
            }
            else
            {
                x = "yes";
                if (checkBox2.Checked == true)
                {
                    MessageBox.Show("You Need To Bill The First Visitaion First Before Adding The Second.", "Warning");
                    y = "no";
                }
                else
                {
                    y = "no";
                }

                int s;
                var a = this.appointmentsTableAdapter.GetAllAppointments();
                if (a.Count == 0)
                {
                    s = 1;
                }
                else
                {
                    s = Convert.ToInt32(a.Last().AppointmentNumber) + 1;
                }

                this.appointmentsTableAdapter.InsertAppointment(Convert.ToString(s), textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text, x, y);
                MessageBox.Show($"Appointment Set Under The Number {s}.", "Success");
                Clear();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var x = this.appointmentsTableAdapter.GetAppointmentByNumber(textBox1.Text);
            if (x.Count == 1)
            {
                textBox1.Text = x.First().AppointmentNumber;
                textBox2.Text = x.First().PatientID;
                dateTimePicker1.Text = x.First().AppointmentDate;
                dateTimePicker1.Text = x.First().VisitationDate;
                if (x.First().FirstVisitation == "yes")
                {
                    checkBox1.Checked = true;
                    if (x.First().SecondVisitation == "yes")
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("There Is No Appointment With This Number.", "Error!");
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var x = this.appointmentsTableAdapter.GetAppointmentByID(textBox2.Text);
            var z = this.patientsTableAdapter.GetPatientByID(textBox2.Text);
            if (x.Count == 1)
            {
                textBox1.Text = x.First().AppointmentNumber;
                textBox2.Text = x.First().PatientID;
                dateTimePicker1.Text = x.First().AppointmentDate;
                dateTimePicker1.Text = x.First().VisitationDate;
                if (x.First().FirstVisitation == "yes")
                {
                    checkBox1.Checked = true;
                    if (x.First().SecondVisitation == "yes")
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            else if (x.Count == 0 && z.Count == 1)
            {
                MessageBox.Show("Patient Doesn't Have An Appoinment.", "Error!");
            }
            else if (z.Count == 0)
            {
                MessageBox.Show("Patient Isn't Registered.", "Error!");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var z = this.appointmentsTableAdapter.GetAppointmentByID(textBox2.Text);
            string x, y;
            if (z.Count == 0)
            {
                MessageBox.Show("This Appointment Doesn't Exist.", "Error!");
            }
            else if (checkBox1.Checked == false)
            {
                MessageBox.Show("This Must Be The First Visitation.", "Error!");
                x = "no";
                y = "no";
            }
            else
            {
                x = "yes";
                var o = this.billingTableAdapter.GetBillByAppointmentNumber(textBox1.Text);
                if (o.Count == 1)
                {
                    if (checkBox2.Checked == true)
                    {
                        y = "yes";
                    }
                    else
                    {
                        y = "no";
                    }
                }
                else
                {
                    y = "no";
                    MessageBox.Show("The Second Visitaion Wasn't Saved Because The First Isn't Billed Yet", "Error!");
                }

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Enter Appointment Number And PatientID.", "Error!");
                }
                else
                {
                    this.appointmentsTableAdapter.UpdateAppointment(dateTimePicker1.Text, dateTimePicker2.Text, x, y, textBox1.Text, textBox2.Text);
                    MessageBox.Show("Edit Saved.", "Success");
                    Clear();
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if ((this.appointmentsTableAdapter.GetAppointmentByID(textBox2.Text)).Count == 0)
            {
                MessageBox.Show("Appointment Doesn't Exist.", "Error!");
            }
            else if (this.billingTableAdapter.GetBillByAppointmentNumber(textBox1.Text).Count == 1)
            {
                MessageBox.Show("You Can't Delete This Appointment As It Has A Bill Registered For It.", "Error!");
            }
            else
            {
                this.appointmentsTableAdapter.DeleteAppointment(textBox1.Text, textBox2.Text);
                MessageBox.Show("Appointment Canceled.", "Done.");
                Clear();
            }
        }
        private void checkBoxClear_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
        }
    }
}

