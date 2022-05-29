using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace jpddoocp.models
{
     abstract class AbstractDbModel
    {
        protected String cnnString;
        protected MySqlConnection connection = new MySqlConnection();
        protected MySqlDataAdapter ad;
        protected DataTable dt;
        protected MySqlCommand cmd;
       
        
        protected AbstractDbModel()
        {
            //Extracting the Connection Details from the App.Config
            cnnString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            //Convert the string to a key-value paired string.
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(cnnString);
            connection.ConnectionString = builder.ConnectionString;
        }
        protected DataTable Select(string sqlQuery)
        {
            dt = new DataTable();
            ad = new MySqlDataAdapter(sqlQuery, connection);
            new MySqlCommandBuilder(ad);
            connection.Open();
            ad.Fill(dt);
            connection.Close();
            return dt;
        }

        protected void CUquery(string sqlQuery)
        {
            cmd = new MySqlCommand(sqlQuery, connection);
            cmd.CommandType = CommandType.Text;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        protected int GetInteger(string sqlQuery)
        {
            Int32 returnValue;
            cmd = new MySqlCommand(sqlQuery, connection);
            cmd.CommandType = CommandType.Text;
            connection.Open();
            returnValue = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return returnValue;
        }
    }
}
