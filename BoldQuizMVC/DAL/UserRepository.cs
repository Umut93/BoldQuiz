using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using IDAL;
using System.Configuration;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private SqlConnection con;

       // public UserRepository()
        //{
         //   string connectString = ConfigurationManager.
           // this.con = new SqlConnection();

        }
    }
//}
