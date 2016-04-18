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
    public abstract class BaseRepository
    {
        protected SqlConnection con;

        public BaseRepository(string connectionstringName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionstringName].ConnectionString;

            con = new SqlConnection(connectionString);
            con.Open();
        }
    }
}
