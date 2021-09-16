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

namespace p1
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportviewerc dashbd = new reportviewerc();
            this.Hide();
            dashbd.Show();



        }

        private void logout_Click(object sender, EventArgs e)
        {
            this.Close();
            login l = new login();
            l.Show();
        }
    }
}
