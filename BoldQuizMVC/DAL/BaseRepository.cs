using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Models;
using Dapper;

namespace DAL
{
    //The base Repository class takes a DefaultConnection as a argument and the connectionstring gets from the web.config.
    public abstract class BaseRepository : IDisposable
    {
        protected SqlConnection con;

        public BaseRepository(string connectionstringName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionstringName].ConnectionString;

            con = new SqlConnection(connectionString);
            con.Open();
            
        }

        public void Dispose()
        {
            con.Close();
            con.Dispose();
        }
    }

    public class DBConnection
    {
        private static DBConnection instance;

        public SqlConnection Con
        {
            get;
            private set;
        }

        private DBConnection() {
            Con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            Con.Open();
        }

        public static DBConnection GetInstance()
        {
            if(instance == null)
            {
                instance = new DBConnection();
            }
            return instance;
        }
        
        
    }
}
