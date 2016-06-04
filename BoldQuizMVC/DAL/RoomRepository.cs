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
            
         //Creating a room by passing the properties in the database. Every room is assigned to a section.
         // Scope_identity tager den sidste generede identiy i tabellen.
         //ExcuScalar used when the query returns a single value (the total rows). 
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

        //Deleing a room.
        public void deleteRoom(Room room)
        {
            string sql = "DELETE FROM Room where ID = @Id ";
            con.Execute(sql, new { Id= room.ID });

        }

        public List<Player> FindAllPlayerOneRoom(int roomID)
        {
            string sql = "SELECT * FROM AspNetUsers JOIN Player on Id = userID where room_id = @room_id";
            return con.Query<Player>(sql, new { room_id = roomID}).ToList();
        }





    }
}
