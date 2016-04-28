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

        //Inserting a player in the Player-Table. @user and @gender is the values - we assign them with help of player's objects propeties!
        public void addPlayer(Player player) {
        con.Execute("INSERT INTO Player(userId, gender) VALUES (@userID, @gender)", new {userID = player.Id, gender = player.Gender}); 


        }

        //Finding ONE player by searching the ID in the table. Note that we are using AspNetUsers which from microsoft entity framwork which maps the users.
        public Player findOnePlayer(int id)
        {
            string sql = "Select * from AspNetUsers JOIN Player on Id = userID where Id = @id";
            return  con.Query<Player>(sql, new { id = id }).Single(); 

        }

        //Finding a player by searchinng the Username.
        public Player findOnePlayer(string UserName)
        {
            string sql = "Select * from AspNetUsers JOIN Player on Id = userID where UserName = @userName";
            return con.Query<Player>(sql, new { userName = UserName }).Single();

        }

        //Updating a player by searching the player.
        public void updatePlayer(Player player) {

            string sql = "Update Player set gender = @gender, room_id = @room_id WHERE userID = @userID";
            con.Execute(sql, new { gender = player.Gender, room_id = player.Room.ID, userID = player.Id });


        }

        //public void deletePlayer(Player player)
        //{

        //    string sql = "DELETE FROM Player WHERE userID = @userID";
        //    con.Execute(sql, new { userID = player.Id });


        //}

        }
}
