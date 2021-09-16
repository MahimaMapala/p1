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
using System.Security.Authentication;
using fnbll;
using dbdll;

namespace p1
{
    public partial class login : Form
    {
        fnbll.ftn f = new fnbll.ftn();
        // functn f = new functn();
        public login()
        {            InitializeComponent();
            timer1.Start();
            this.ActiveControl = userid;
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.date.Text = dt.ToShortDateString();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isValid()
        {
            if (ValidateChildren(ValidationConstraints.Enabled)) 
            { 
             return true; 
            }
            else { return false; }
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            
            //functnbll.Class1 f = new functnbll.Class1();
            if (isValid())
            {

                if (f.isempty())
                {
                    if (f.isexist(userid.Text.Trim(), password.Text.Trim()))
                    {

                        if (f.isadmin(userid.Text.Trim(), password.Text.Trim()))
                        {

                            //open admin page
                            register dashbd = new register();
                            this.Hide();
                            dashbd.Show();
                        }
                        //if not admin
                        else
                        {    //user page
                            dashboard dashbd = new dashboard();
                            this.Hide();
                            dashbd.Show();
                        }
                    }
                    //if not existing user
                    else
                    {
                        //MessageBox.Show("incorrect password");
                        errorProvider1.SetError(password, "incorrect password");

                    }
                }

                //if table empty
                else
                {//when user table empty
                    int ax = f.regasadmin(userid.Text.Trim(), password.Text.Trim());

                    if (ax==1)
                    {
                        MessageBox.Show(ax+ " :Data Inserted");
                        register dashbd = new register();
                        this.Hide();
                        dashbd.Show();
                    }

                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtisvalid(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(userid.Text)| userid.Text.Length < 5)
            {
                e.Cancel = true;
                userid.Focus();
                errorProvider1.SetError(userid, "Please enter your EID or of length min 5!");
            }
            else if (!f.eexists(userid.Text.Trim())) {
                e.Cancel = true;
                userid.Focus();
                errorProvider1.SetError(userid, "user dosent exist !");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(userid, null);
            }
        }

        private void pswdvalidation(object sender, CancelEventArgs e)
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
    }
    }
