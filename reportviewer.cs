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
using dbdll;
using System.Transactions;

namespace p1
{
    public partial class reportviewerc : Form
    {
        dbdll.db d=new dbdll.db();
            public reportviewerc()
        {
            InitializeComponent();
        }

        private void reportviewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string ename, did, sal;

            using (var scope = new TransactionScope())
            {
                using (SqlConnection cnn = d.openconn())
                {
                    string query = "report";
                    SqlTransaction tr = cnn.BeginTransaction();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    reportviewerc rv = new reportviewerc();
                    while (rdr.Read())
                    {
                        rv.empdatatableBindingSource.DataSource = rdr;
                    }


                    rv.reportViewer1.Refresh();
                    cnn.Close();


                }
                scope.Complete();
            }
        }






               
     }
           
}
