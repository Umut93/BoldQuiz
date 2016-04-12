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
            //string sql = "INSERT INTO Room(point, section_id) VALUES (0, @sectionid)";
            //con.Execute(sql, new { sectionid = room.section.ID });

            // Finder det ID som er blevet generet i Databasen som er ovenstående.
            string findID = "INSERT INTO Room(point, section_id) VALUES (0, @sectionid); select scope_identity()";
            room.ID =  con.ExecuteScalar<int>(findID, new { sectionid = room.section.ID});
        }


        //public void deleteRoom(Room room)
        //{
        //    string sql = "DELETE FROM Room where ID = @Id ";
        //    con.Execute(sql, new { ID = room.ID });


        //}
      

    }
}
