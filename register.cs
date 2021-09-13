using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Memcached;
using System.Security.Authentication;
using fnbll;


namespace p1
{
   public partial class register : Form
    {
        
        fnbll.ftn f = new fnbll.ftn();
       
        public register()
        {
            InitializeComponent();
            timer1.Start();
            this.ActiveControl = EID;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isvalid() {


            
            if (string.IsNullOrEmpty(dob.Text.Trim())) {
                dob.Text = "1999-01-01";
            }
            if (string.IsNullOrEmpty(joind.Text.Trim()))
            {
                DateTime dt = DateTime.Now;
                joind.Text = dt.ToShortDateString();
            }
            

            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                return true;
            }
            else { return false; }


        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                    int aa = f.addemplyee( EID.Text.Trim(), password.Text.Trim(), DID.Text.Trim(), CID.Text.Trim(),Ename.Text,mobile.Text.Trim(), dob.Text.Trim(), joind.Text.Trim(), salary.Text.Trim(), state.Text, city.Text, reportingto.Text, desig.Text);
                    if (aa == 1)

                    {
                        MessageBox.Show("employee added");
                    }
                

            }
        }

        private void dobp_ValueChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.date.Text = dt.ToShortDateString();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            login l = new login();
            l.Show();
        }

        private void eidvalidation(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(EID.Text)| EID.Text.Length < 5)
            {
                e.Cancel = true;
                EID.Focus();
                errorProvider1.SetError(EID, "Please enter your EID min of length 5!");
            }
            else if (f.eexists(EID.Text.Trim()))
            {
                e.Cancel = true;
                EID.Focus();
                errorProvider1.SetError(EID, "EmployeeID already exist !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(EID, null);
            }
        }

        private void pwdval(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(password.Text) | password.Text.Length < 5)
            {
                e.Cancel = true;
                password.Focus();
                errorProvider1.SetError(password, "Please enter your password or of min length 5 !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(password, null);
            }
        }

        private void cidval(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(CID.Text))
            {
                e.Cancel = true;
                CID.Focus();
                errorProvider1.SetError(CID, "Please enter CID");
            }
            else if (!f.cexists(CID.Text)) { errorProvider1.SetError(CID, "company id donot exist"); }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(CID, null);
            }
        }

        private void didval(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(DID.Text))
            {
                e.Cancel = true;
                DID.Focus();
                errorProvider1.SetError(DID, "Please enter DID");
            }
            else if (!f.didcidval(DID.Text, CID.Text)) { 
                errorProvider1.SetError(DID, "department id donot exist"); }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(DID, null);
            }
        }

       

        private void vsdvsvsvsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            comreg dashbd = new comreg();
            dashbd.Show();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            register dashbd = new register();
            dashbd.Show();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        
    }
}
