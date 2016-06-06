using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;
namespace DAL
{
   public class SectionRepository : BaseRepository
    {
        public SectionRepository(string connectionstring) : base(connectionstring)
        {
        }

        //Retriving all the sections(categories).
        public List<Section> getSections()
        {
            string sql = "SELECT * FROM Section";
            return con.Query<Section>(sql).ToList();

        }
        //Retrieving one Section
        public Section findOneSection(int id) {

            string sql = "SELECT * FROM Section where ID = @id";
            return  con.Query<Section>(sql, new { id = id }).First();

        }


    }
}
