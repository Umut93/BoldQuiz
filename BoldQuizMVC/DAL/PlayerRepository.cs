using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;
using Models.Identity;

namespace DAL
{
    public class PlayerRepository : BaseRepository
    {
        public PlayerRepository(string connectionstring) : base(connectionstring)
        {
        }


        public void addPlayer(Player player) {
        con.Execute("INSERT INTO Player(userId, gender) VALUES (@userID, @gender)", new {userID = player.Id, gender = player.gender}); 


        }

        public Player findOnePlayer(int id)
        {
            string sql = "Select* from AspNetUsers join Player on Id = userID where Id = @id";
            return  con.Query<Player>(sql, new { id = id }).Single(); 

        }

        public Player findOnePlayer(string UserName)
        {
            string sql = "Select* from AspNetUsers join Player on Id = userID where UserName = @userName";
            return con.Query<Player>(sql, new { userName = UserName }).Single();

        }

        public void updatePlayer(Player player) {

            string sql = "Update Player set gender = @gender, room_id = @room_id WHERE userID = @userID";
            con.Execute(sql, new { gender = player.gender, room_id = player.room.ID, userID = player.Id });


        }


    }
}
