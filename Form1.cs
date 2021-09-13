using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dbdll;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Authentication;


namespace p1
{
    public partial class Form1 : Form
    {
        dbdll.db d = new dbdll.db();
        public Form1()
        {
            InitializeComponent();
        }

        


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.Employee' table. You can move, or remove it, as needed.
            this.EmployeeTableAdapter.Fill(this.DataSet2.Employee);

            this.reportViewer1.RefreshReport();
        }
    }
    }

