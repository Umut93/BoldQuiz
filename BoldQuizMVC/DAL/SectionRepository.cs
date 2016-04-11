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
        public List<Section> getSections()
        {
            string sql = "Select * from Section";
            return con.Query<Section>(sql).ToList();

        }
        public Section findOneSection(int id) {

            string sql = "Select * FROM Section where id = @id";
            return  con.Query<Section>(sql, new { id = id }).First();

        }


    }
}
