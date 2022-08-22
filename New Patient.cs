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
    public partial class New_Patient : Form
    {
        public New_Patient()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void Clear()
        {
            if (checkBoxClear.Checked == true)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Show();
            this.Close();
        }
        private void patientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.patientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.patientDataSet);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Enter Name and Mobile.", "Error");
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Choose Gender.", "Error");
            }
            else
            {
                var z = this.patientsTableAdapter.GetAllPatients();
                int x;
                if (z.Count == 0)
                {
                    x = 1;
                }
                else
                {
                    x = Convert.ToInt32(z.Last().ID) + 1;
                }

                string Gender;
                if (radioButton1.Checked == true)
                {
                    Gender = "Female";
                }
                else
                {
                    Gender = "Male";
                }

                var s = this.patientsTableAdapter.GetPatientByName(textBox2.Text);
                if (s.Count == 0)
                {
                    this.patientsTableAdapter.InsertPatient(Convert.ToString(x), textBox2.Text, Gender, textBox3.Text);
                    MessageBox.Show($"Patient Added Under ID Number {x} .", "Success");
                }
                else
                {
                    MessageBox.Show("This Patient Is Already Registered.", "Error");
                }

            }
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            tabPage1.Text = "New";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Search For The Patient Before Editing");
            }
            else
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Enter Name And Mobile.", "Error");
                }
                else
                {
                    string Gender;
                    if (radioButton1.Checked == true)
                    {
                        Gender = "Female";
                    }
                    else
                    {
                        Gender = "Male";
                    }
                    this.patientsTableAdapter.UpdatePatient(textBox2.Text, Gender, textBox3.Text, textBox1.Text);
                    MessageBox.Show("Edit Done .", "Success.");
                }
            }                        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Search For The Patient You Want To Delete", "Error"); 
            }
            else
            {
                this.patientsTableAdapter.DeletePatient(textBox1.Text, textBox2.Text, textBox3.Text);
                MessageBox.Show("Patient Deleted.", "Done.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Patient ID", "Error");
            }
            else
            {
                var z = this.patientsTableAdapter.GetPatientByID(textBox1.Text);
                if (z.Count == 1)
                {
                    textBox2.Text = z.First().Name;
                    textBox3.Text = z.First().Mobile;
                    if (z.First().Gender == "Male")
                    {
                        radioButton2.Checked = true;
                        radioButton1.Checked = false;
                    }
                    else
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Patient ID Isn't Registered", "Error");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Patient Name");
            }
            else
            {
                var z = this.patientsTableAdapter.GetPatientByName(textBox2.Text);
                if (z.Count == 1)
                {
                    textBox1.Text = z.First().ID;
                    textBox2.Text = z.First().Name;
                    textBox3.Text = z.First().Mobile;
                    if (z.First().Gender == "Male")
                    {
                        radioButton2.Checked = true;
                        radioButton1.Checked = false;
                    }
                    else
                    {
                        radioButton1.Checked = true;
                        radioButton2.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("Patient Name Isn't Registered", "Error");
                }
                
            }
        }

        private void checkBoxClear_CheckedChanged(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
