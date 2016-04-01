using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;
using System.Configuration;

namespace DAL
{
   public class AnswerRepository
    {
        private SqlConnection con;

        public AnswerRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
            
    }
}
