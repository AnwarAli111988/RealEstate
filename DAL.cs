using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace doc.DAL
{
    class DAL
    {
       
        private string connectionString = "";
     
     public string cs = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Admin\\Documents\\Visual Studio 2010\\Projects\\doc\\doc\\App_Data\\RealEstate.mdf;Integrated Security=True;User Instance=True";
        
        public DAL()
        {
            this.connectionString = cs;
        }

        public DAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DAL(string server, string database)
        {
            this.connectionString = string.Format("Server={0};Database={1};Trusted_Connection=True;", server, database);
        }

        public DAL(string server, string database, string user, string pass)
        {
            this.connectionString = string.Format("Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False", server, database, user, pass);
        }

        public virtual string ConnectionString
        {
            get
            {
                return this.connectionString;
            }
            set
            {
                this.connectionString = value;
            }
        }

        public System.Data.DataSet EXECUTE_FOR_REPORT(string CMD)
        {
            System.Data.SqlClient.SqlConnection con;
            con = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter(CMD, con);
            DataSet DS = new DataSet();

            adp.Fill(DS);
            con.Close();
            return DS;
        }
        //public int Getdata(int i)
        //{
        //    return 1;
        //}
        //public Boolean CHECK_USER(string _username, string _password)
        //{

        //    System.Data.SqlClient.SqlConnection con;
        //    con = new System.Data.SqlClient.SqlConnection(this.ConnectionString);
        //    System.Data.SqlClient.SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    Boolean RES;
        //    try
        //    {
        //        con.Open();
        //        cmd = new SqlCommand("SP_CHECK_LOGIN", con);
        //        cmd.Parameters.Add("@RESULT", SqlDbType.Int).Value = 0;
        //        cmd.Parameters["@RESULT"].Direction = ParameterDirection.Output;
        //        cmd.Parameters.AddWithValue("@USER_NAME", _username);
        //        cmd.Parameters.AddWithValue("@PASSWORD", _password);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.ExecuteNonQuery();
        //        int ID = (int)cmd.Parameters["@RESULT"].Value;
        //        RES = Convert.ToBoolean(ID);

        //    }
        //    catch (Exception EE)
        //    {
        //        //System.Windows.Forms.MessageBox.Show("Connection Error !!!");
        //        throw;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return RES;
        //}

    }
}
