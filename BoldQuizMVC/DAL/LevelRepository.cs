using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace DAL
{
    public class LevelRepository: BaseRepository
    {
        public LevelRepository(string connectionstring) : base(connectionstring)
        {

        }

        public List<Level> getLevelsForASection(int sectionID)
        {
            string sql = "SELECT * FROM [Level] WHERE section_id = @section_ID";
            return con.Query<Level>(sql, new { section_ID = sectionID }).ToList();
        }
    }
}
