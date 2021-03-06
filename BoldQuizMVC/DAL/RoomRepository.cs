﻿using System;
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


        //Creating a room based on the section you choose.
        //Creating a room by taking a room as argument. The point property is not used and we assign the section when creating a room.
        //Scope_identity takes the last generated identiy/row int the table.
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

        //Deleing a room object in the database by passing the id.
        public void deleteRoom(Room room)
        {
            string sql = "DELETE FROM Room where ID = @Id ";
            con.Execute(sql, new { Id= room.ID });

        }

        //Finding a list of players based on that room they are on
        public List<Player> FindAllPlayerOneRoom(int roomID)
        {
            string sql = "SELECT * FROM AspNetUsers JOIN Player on Id = userID where room_id = @room_id";
            return con.Query<Player>(sql, new { room_id = roomID}).ToList();
        }





    }
}
