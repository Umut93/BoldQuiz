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


        //Inserting one player in the Player-Table. 

        public void addPlayer(Player player)
        {
        con.Execute("INSERT INTO Player(userId, gender) VALUES (@userID, @gender)", new {userID = player.Id, gender = player.Gender}); 

        }

        //Finding ONE player by searching the ID in the table. Note that we are using AspNetUsers which from microsoft entity framwork which maps the users.
        public Player findOnePlayer(int id)
        {
            string sql = "SELECT * FROM AspNetUsers JOIN Player on Id = userID where Id = @id";
            return  con.Query<Player>(sql, new { id = id }).Single(); 

        }

        //Finding a player by searchinng the Username.
        public Player findOnePlayer(string UserName)
        {
            string sql = "SELECT * FROM AspNetUsers JOIN Player on Id = userID where UserName = @userName";
            return con.Query<Player>(sql, new { userName = UserName }).Single();

        }

        //Updating a player when we take a player as argument.
        public void updatePlayer(Player player)
        {

            string sql = "Update Player SET gender = @gender, room_id = @room_id WHERE userID = @userID";
            con.Execute(sql, new { gender = player.Gender, room_id = player.Room.ID, userID = player.Id });

        }

     

        }
}
