using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Models.Identity;

namespace BLL
{
    public class Player_StatusLogic
    {
        private Player_statusRepository player_statusRepository;
        private Room_LevelsLogic Room_LevelsLogic;
        private UserLogic UserLogic;

        public Player_StatusLogic()
        {
            player_statusRepository = new Player_statusRepository("DefaultConnection");
            Room_LevelsLogic = new Room_LevelsLogic();
            UserLogic = new UserLogic();
        }

        //Finding a specific room with its level_id. This looks into how a player has cope with it. (savedscore,playerid,room_levels_id). You get a Player_status.
        //A way of securing that a player_status is in the table before retrievning from the table.
        public Player_Status findPlayerStatus(int playerID, int room_level_id)

        {

           Player_Status playerStatus = player_statusRepository.findPlayerStatus(playerID, room_level_id);

            if(playerStatus != null)
            {
                
                playerStatus.Room_levels =  Room_LevelsLogic.getRoom_level(room_level_id);
                playerStatus.Player = UserLogic.findPLayer(playerID);
            }

            return playerStatus;



        }

        //Adding a player_status if it is not already in the table.
        //50: Use a external method!
        public void addPlayerStatus(Player_Status player_status)
        {
            if (findPlayerStatus(player_status.Player.Id, player_status.Room_levels.ID)==null)
            {
                player_statusRepository.addPlayerStatus(player_status) ;
            }
           
        }
        //Updating a player_status after processing a level.
        public void updatePlayerStatus(Player_Status player_status)
        {
            player_statusRepository.updatePlayerStatus(player_status);
        }



    }
}
