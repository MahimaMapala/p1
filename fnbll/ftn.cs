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
using dbdll;

namespace fnbll
{
    public class ftn
    {
        dbdll.db d = new dbdll.db(); 
        
        public bool isempty()
        {

            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            string query1 = "isempty";
            SqlCommand cmd1 = new SqlCommand(query1, cnn);//table empty?
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Transaction = tr;
            Int32 count1 = Convert.ToInt32(cmd1.ExecuteScalar());
            cmd1.Dispose();
            d.closeconn();
            if (count1 >= 1) return true;
            return false;
        }

        public bool isexist(string a, string b)
        {
            string query2 = "isexist";
            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            SqlCommand cmd2 = new SqlCommand(query2, cnn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(
                new SqlParameter("@eid", a));
            cmd2.Parameters.Add(
                new SqlParameter("@password", b));
            cmd2.Transaction = tr;
            Int32 count2 = Convert.ToInt32(cmd2.ExecuteScalar());
            cmd2.Dispose();
            d.closeconn();
            if (count2 == 1) return true;
            return false;

        }

        public bool eexists(string a)
        {
            string query2 = "eexists";
            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            SqlCommand cmd2 = new SqlCommand(query2, cnn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(
                new SqlParameter("@eid", a));
            cmd2.Transaction = tr;
            Int32 count2 = Convert.ToInt32(cmd2.ExecuteScalar());
            cmd2.Dispose();
            d.closeconn();
            if (count2 == 1) return true;
            return false;

        }

        public bool isadmin(string a, string b)
        {
            string query3 = "isadmin";
            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            SqlCommand cmd3 = new SqlCommand(query3, cnn);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add(
                new SqlParameter("@eid", a));
            cmd3.Parameters.Add(
                new SqlParameter("@password", b));//
            cmd3.Transaction = tr;
            SqlDataReader dr = cmd3.ExecuteReader();//executereader
            string count3 = null;
            while (dr.Read())
            {
                count3 = dr["sno"].ToString();
            }
            cmd3.Dispose();
            d.closeconn();
            if (count3 == "1")
            { return true; }
            return false;
        }

        public int regasadmin(string a, string b)
        {
            int aa = 0;

            string query3 = "regasadmin";
            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            SqlCommand cmd4 = new SqlCommand(query3, cnn);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.Add(
                new SqlParameter("@eid", a));
            cmd4.Parameters.Add(
                new SqlParameter("@password", b));//
            cmd4.Transaction = tr;

                aa = cmd4.ExecuteNonQuery();
                tr.Commit();
                d.closeconn();
            return aa;
        }

        public int addemplyee(string eid, string password, string did, string cid, string ename, string mobile, string dob, string joins, string salary, string state, string city, string reportingto, string designation)
        {

            string query6 = "addemployee";
            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            SqlCommand cmd5 = new SqlCommand(query6, cnn);
            cmd5.CommandType = CommandType.StoredProcedure;
            cmd5.Parameters.Add(
                new SqlParameter("@eid", eid));
            cmd5.Parameters.Add(
                new SqlParameter("@password", password));
            cmd5.Parameters.Add(
                new SqlParameter("@did", did));
            cmd5.Parameters.Add(
                new SqlParameter("@cid", cid));
            cmd5.Parameters.Add(
                new SqlParameter("@ename", ename));
            cmd5.Parameters.Add(
                new SqlParameter("@mobile",mobile));
            cmd5.Parameters.Add(
                new SqlParameter("@dob", dob));
            cmd5.Parameters.Add(
                new SqlParameter("@joins", joins));
            cmd5.Parameters.Add(
                new SqlParameter("@salary", salary));
            cmd5.Parameters.Add(
                new SqlParameter("@state", state));
            cmd5.Parameters.Add(
                new SqlParameter("@city", city));
            cmd5.Parameters.Add(
                new SqlParameter("@reportingto", reportingto));
            cmd5.Parameters.Add(
                new SqlParameter("@designation", designation));
            //
            cmd5.Transaction = tr;
            int aa = 0;
           
                aa = cmd5.ExecuteNonQuery();
                tr.Commit();
                d.closeconn();
            return aa;
        }


        public int regcomp(string cid, string gstn, string cname, string dirname, string mail, string state,string pincode, string mobile)
        {

            string query6 = "regcomp";
            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            SqlCommand cmd5 = new SqlCommand(query6, cnn);
            cmd5.CommandType = CommandType.StoredProcedure;
            cmd5.Parameters.Add(
                new SqlParameter("@cid", cid));
            cmd5.Parameters.Add(
                new SqlParameter("@gstn", gstn));
            cmd5.Parameters.Add(
                new SqlParameter("@cname", cname));
            cmd5.Parameters.Add(
                new SqlParameter("@dirname", dirname));
            cmd5.Parameters.Add(
                new SqlParameter("@mail", mail));
            cmd5.Parameters.Add(
                new SqlParameter("@state", state));
            cmd5.Parameters.Add(
                new SqlParameter("@pincode", pincode));
            cmd5.Parameters.Add(
                new SqlParameter("@mobile", mobile));
            cmd5.Transaction = tr;
            int aa = 0;

            aa = cmd5.ExecuteNonQuery();
            tr.Commit();
            d.closeconn();
            return aa;
        }

        public bool cexists(string a)
        {
            string query2 = "cexists";
            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            SqlCommand cmd2 = new SqlCommand(query2, cnn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(
                new SqlParameter("@cid", a));
            cmd2.Transaction = tr;
            Int32 count2 = Convert.ToInt32(cmd2.ExecuteScalar());
            cmd2.Dispose();
            d.closeconn();
            if (count2 == 1) return true;
            return false;

        }

        public bool didcidval(string a, string b)
        {
            

            string query3 = "didcidval";
            SqlConnection cnn = d.openconn();
            SqlTransaction tr = cnn.BeginTransaction();
            SqlCommand cmd4 = new SqlCommand(query3, cnn);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.Add(
                new SqlParameter("@did", a));
            cmd4.Parameters.Add(
                new SqlParameter("@cid", b));//
            cmd4.Transaction = tr;
            Int32 count2 = Convert.ToInt32(cmd4.ExecuteScalar());
            cmd4.Dispose();
            d.closeconn();
            if (count2 == 1) return true;
            return false;
        }






    }
}
