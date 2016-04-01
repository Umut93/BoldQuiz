using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
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
