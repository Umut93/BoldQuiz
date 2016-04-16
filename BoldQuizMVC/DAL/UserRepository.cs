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
using Models.Identity;

namespace DAL
{
    public class UserRepository : BaseRepository
    {

        public SectionRepository sectionRepository;


        public UserRepository(string connectionstring) : base(connectionstring)
        {
        }


        public ApplicationUser findOneUser(int ID)
        {
            string sql = "Select * from AspNetUsers where Id = @ID";
            return  con.Query<ApplicationUser>(sql, new { ID = ID}).First();
        }


        public ApplicationUser findOneUser(string userName)
        {
            string sql = "Select * from AspNetUsers where UserName = @userName";
            return con.Query<ApplicationUser>(sql, new { userName = userName }).First();
        }




    }
    }

