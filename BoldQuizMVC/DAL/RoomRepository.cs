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
            
         //Creating a room by passing the properties in the database.  
         // Scope_identity tager den sidste generede identiy i tabellen.
         public void createRoom(Room room)
        {
            string findID = "INSERT INTO Room(point, section_id) VALUES (0, @sectionid); select scope_identity()";
            room.ID =  con.ExecuteScalar<int>(findID, new { sectionid = room.Section.ID});
        }

        //Finding one room by searching the ID.
        public Room findOneRoom (int id)
        {
            string sql = "Select * FROM Room where ID = @Id ";
            return con.Query<Room>(sql, new { Id = id }).Single();
        }

        //Deleing a specific piece of a room.
        public void deleteRoom(Room room)
        {
            string sql = "DELETE FROM Room where ID = @Id ";
            con.Execute(sql, new { Id= room.ID });

        }

        


      

    }
}
