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

        public SectionRepository sectionRepository;


        public UserRepository(string connectionstring) : base(connectionstring)
        {
        }


        //public void createSection()
        //{

        // SectionRepository section= new SectionRepository("DefaultConnection");
        // section.getSections();
        //}

      

       
        
        
    }
    }

