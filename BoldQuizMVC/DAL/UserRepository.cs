using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using IDAL;
using System.Configuration;
using Models;


namespace DAL
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(string connectionstring) : base(connectionstring)
        {
        }

    }
    }

