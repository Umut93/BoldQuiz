using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace DAL
{
    public class PlayerRepository : BaseRepository
    {
        public PlayerRepository(string connectionstring) : base(connectionstring)
        {
        }


        public void addPlayer(Player player) {
            con.Execute("INSERT INTO Player(userId, gender) VALUES (@userID, @gender)", new {userID = player.ID, gender = player.gender}); 


        }

    }
}
