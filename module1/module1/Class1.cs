using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace module1
{
    class Class1
    {

        string constr = @"Data Source=TAYYAB;Initial Catalog=newdatabase;Integrated Security=True";

        public DataTable GetDataTable(string SQL, out string msg)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(SQL, con);
                da.Fill(dt);
                con.Close();
                con.Dispose();
                msg = "";
            }
            catch (Exception e)
            {
                msg = e.Message;
            }

            return dt;
        }
        public void ExecuteCommand(string SQL, out string msg)
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand comm = new SqlCommand(SQL, con);
                comm.ExecuteNonQuery();
                msg = "";
                con.Close();
                con.Dispose();
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
        }
        public int ExecuteCommandScallar(string SQL, out string msg)
        {
            int i = 0;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand comm = new SqlCommand(SQL, con);
                i = Convert.ToInt32(comm.ExecuteScalar());
                msg = "";
                con.Close();
                con.Dispose();
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return i;
        }

        public string ExecuteCommandString(string SQL, out string msg)
        {
            string s = "";
            try
            {
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand comm = new SqlCommand(SQL, con);
                s = comm.ExecuteScalar().ToString();
                msg = "";
                con.Close();
                con.Dispose();
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return s;
        }



    }
}
