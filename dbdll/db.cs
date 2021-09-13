using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Security.Authentication;

namespace dbdll
{
    public class db
    {

        public SqlConnection conn()
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;//open
            SqlConnection cnn = new SqlConnection(con);
            return cnn;
        }
        public SqlConnection openconn()
        {
            SqlConnection cnn = conn();
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Can not open connection ! " + ex.ToString());
                //MessageBox.Show("Can not open connection ! " + ex.ToString());
            }
            return cnn;
        }

        public void closeconn()
        {
            SqlConnection cnn = conn();
            try
            {
                cnn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Can not close connection ! " + ex.ToString());
            }

        }
    }
}
