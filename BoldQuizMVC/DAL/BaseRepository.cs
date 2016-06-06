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
    //IDispoable is used because in the past my timeout is over and several things use the connection. It couldnt stand it.
    //This is the base class where all Repository inherts from.
    //Every connection go into the Dispose method where it close it after realising the resource.
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

    //The database connection.
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
        //The singleton.
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
