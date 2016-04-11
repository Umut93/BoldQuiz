using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;
namespace DAL
{
    public class RoomRepository : BaseRepository
    {
        public RoomRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void createRoom(Room room) {
            string sql = "INSERT INTO Room(point, section_id) VALUES (0, @sectionid)";
            con.Execute(sql, new { sectionid = room.section.ID });
        }

    }
}
