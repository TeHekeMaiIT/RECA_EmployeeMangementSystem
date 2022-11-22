using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;       // Added
using MySql.Data.MySqlClient; 


namespace loginsec
{
    class Connection
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;
        static string host = "localhost";
        static string database = "human_resources";
        static string userDB = "root";
        static string password = "Dbms@2022";
        public static string strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password + ";persistsecurityinfo=True";
        public bool Open()
        {
            try
            {
                //strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password;
                MySqlConnection mySqlConnection = new MySqlConnection(strProvider);
                mySqlConnection.Open();
                conn = new MySqlConnection(strProvider);
                conn.Open();
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show("Connection Error ! " + er.Message, "Information");
            }
            return false;
        }
        public void Close()
        {
            conn.Close();
            conn.Dispose();
        }
        public string connectionString()
        {
            return strProvider;
        }
        
        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                MySqlTransaction mytransaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
    }


}

