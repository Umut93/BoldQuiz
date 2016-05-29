using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
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


        //Finding one person by searching the ID
        public ApplicationUser findOneUser(int ID)
        {
            string sql = "Select * from AspNetUsers where Id = @ID";
            return  con.Query<ApplicationUser>(sql, new { ID = ID}).First();
        }

        //Finding one person by searching the Username
        public ApplicationUser findOneUser(string userName)
        {
            string sql = "Select * from AspNetUsers where UserName = @userName";
            return con.Query<ApplicationUser>(sql, new { userName = userName }).First();
        }




    }
    }

