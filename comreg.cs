using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using fnbll;

namespace p1
{
    public partial class comreg : Form
    {
        fnbll.ftn f = new fnbll.ftn();
        public comreg()
        {
            InitializeComponent();
            this.ActiveControl = cid;
            loaderpic.Hide();
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

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            register dashbd = new register();
            dashbd.Show();
        }

        public void isvalid() {
            
           
           


           // MessageBox.Show(responseString);

            //return true;
        }


        private bool val() {
             
             //var responseString = "{\"taxpayerInfo\": {  \"errorMsg\": null,   \"adadr\": [       {         \"ntr\": \"Supplier of Services, Recipient of Goods or Services\",         \"addr\": {           \"stcd\": \"Uttar Pradesh\",           \"flno\": \"\",           \"bno\": \".\",           \"st\": \"AKAJHA MOD URWA BAZAR\",           \"bnm\": \"C/O PRABHAWATI DEVI\",           \"pncd\": \"273407\",           \"loc\": \"GORAKHPUR\",           \"dst\": \"Gorakhpur\",           \"city\": \"\",           \"lt\": \"\",           \"lg\": \"\"         }       },       {         \"addr\": {           \"lt\": \"\",           \"pncd\": \"274402\",           \"loc\": \"KUSHINAGAR\",           \"lg\": \"\",           \"st\": \"WARD NO 8 CIVIL LINE, KASYA\",           \"bno\": \".\",           \"dst\": \"Kushinagar\",           \"city\": \"\",           \"flno\": \"\",           \"stcd\": \"Uttar Pradesh\",           \"bnm\": \"MS.GYATRI DEVI W/O RAM\"         },         \"ntr\": \"Supplier of Services, Recipient of Goods or Services\"       },       {         \"ntr\": \"Supplier of Services, Recipient of Goods or Services\",         \"addr\": {           \"city\": \"\",           \"stcd\": \"Uttar Pradesh\",           \"bnm\": \"DEVENDAR SINGH S/O- GULJESHWARI\",           \"flno\": \"\",           \"bno\": \".\",           \"lg\": \"\",           \"loc\": \"BHATPAR RANI\",           \"pncd\": \"274702\",           \"dst\": \"Deoria\",           \"st\": \"BELPAR PANDIT, POST BHATPAR RANI, TAHSIL  ROAD\",           \"lt\": \"\"         }       }     ],     \"tradeNam\": \"UTKARSH SMALL FINANCE BANK LIMITED\"   } } ";
            ///*
            var url = "https://appyflow.in/api/verifyGST";
            var r = (System.Net.HttpWebRequest)WebRequest.Create(url);

            var postdata = "gstNo=" + Uri.EscapeDataString(gstno.Text.Trim());
            postdata += "&key_secret=" + Uri.EscapeDataString("zYHi5BrNWhfIq3CY3Ck9UL9wUYR2");
            var data = Encoding.ASCII.GetBytes(postdata);

            r.Method = "POST";
            r.ContentType = "application/x-www-form-urlencoded";
            r.ContentLength = data.Length;

            using (var stream = r.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)r.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

           // */

            var jo = JObject.Parse(responseString);
            int ccc = 0;
            var er = jo["taxpayerInfo"]["errorMsg"];
            if (string.IsNullOrEmpty(er.ToString()))
            {
                ccc = 1;
                var stcds = jo["taxpayerInfo"]["adadr"];
                var stcd = jo["taxpayerInfo"]["adadr"][0]["addr"]["stcd"];
                var pncd = jo["taxpayerInfo"]["adadr"][0]["addr"]["pncd"];
                var tradeNam = jo["taxpayerInfo"]["tradeNam"];
                int n = 0;
                if (tradeNam.ToString() == cname.Text.Trim())
                {
                    ccc = 2;
                    while (stcds.HasValues)
                    {
                        stcd = jo["taxpayerInfo"]["adadr"][n]["addr"]["stcd"];
                        if (stcd.ToString() == state.Text.Trim())
                        {
                            ccc = 3;
                            pncd = jo["taxpayerInfo"]["adadr"][n]["addr"]["pncd"];
                            if (pncd.ToString() == pincode.Text.Trim())
                            {
                                ccc = 4;
                                break;
                            }
                        }
                        n++;

                    }
                    switch (ccc)
                    {
                        case 0: errorProvider1.SetError(gstno, "invalid gstno"); break;
                        case 1: errorProvider1.SetError(cname, "invalid company name"); break;
                        case 2: errorProvider1.SetError(gstno, "invalid state name"); break;
                        case 3: errorProvider1.SetError(gstno, "invalid pincode"); break;
                    }

                    if (ccc == 4)
                    { 
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("do not have value");
                        return false;
                        
                    }

                }
                }
            return false;


        }
        private void logout_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            this.Close();
            login l = new login();
            l.Show();
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            //isvalid();
            if (ValidateChildren(ValidationConstraints.Enabled))
                loaderpic.BringToFront();
                loaderpic.Show();
            loaderpic.Focus();
            if (val())
            {
                int aa = f.regcomp(cid.Text, gstno.Text, cname.Text, dname.Text, email.Text, state.Text, pincode.Text, mobile.Text);
                loaderpic.Hide();

                if (aa == 1)

                {
                    MessageBox.Show("company added");
                    cid.Clear();
                    cname.Clear();
                    gstno.Clear();
                    cname.Clear();
                    dname.Clear();
                    email.Clear();
                    state.Clear();
                    pincode.Clear();
                    mobile.Clear();
                }


            }


        }

        private void cidval(object sender, CancelEventArgs e)
        {
            bool xx;
            if (string.IsNullOrEmpty(cid.Text))
            {
                e.Cancel = true;
                cid.Focus();
                errorProvider1.SetError(cid, "Please enter cID");
            }
            else if (xx=f.cexists(cid.Text))
            {
                e.Cancel = true;
                cid.Focus();
                errorProvider1.SetError(cid, "CompanyID already exist !");
            }
            else { e.Cancel = false; }
        }

        private void cnval(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cname.Text))
            {
                e.Cancel = true;
                cname.Focus();
                errorProvider1.SetError(cname, "Please enter cname");
            }
            else { e.Cancel = false; }
        }

        private void stval(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(state.Text))
            {
                e.Cancel = true;
                state.Focus();
                errorProvider1.SetError(state, "Please enter state");
            }
            else { e.Cancel = false; }
        }

        

        private void pinval(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(pincode.Text))
            {
                e.Cancel = true;
                pincode.Focus();
                errorProvider1.SetError(pincode, "Please enter district");
            }
            else { e.Cancel = false; }
        }
    }
}
