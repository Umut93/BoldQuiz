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
       
        private Room_LevelsLogic Room_LevelsLogic;
        

        public Player_StatusLogic()
        {
            
            Room_LevelsLogic = new Room_LevelsLogic();
          
        }

        //Finding a specific room with its level_id. This looks into how a player has cope with it. (savedscore,playerid,room_levels_id). You get a Player_status.
        //A way of securing that a player_status is in the table before retrievning from the table.
        public Player_Status findPlayerStatus(Player player, Room_levels room_levels)

        {

            using (Player_statusRepository player_statusRepository = new Player_statusRepository("DefaultConnection"))
            {
                Player_Status playerStatus = player_statusRepository.findPlayerStatus(player.Id, room_levels.ID);


                if (playerStatus != null)
                {

                    playerStatus.Room_levels = room_levels;
                    playerStatus.Player = player;
                }

                return playerStatus;
            }


        }

        //Adding a player_status if it is not already in the table.
        //50: Use a external method!
        public void addPlayerStatus(Player_Status player_status)
        {
            using (Player_statusRepository player_statusRepository = new Player_statusRepository("DefaultConnection"))
            {
                if (findPlayerStatus(player_status.Player, player_status.Room_levels) == null)
                {
                    player_statusRepository.addPlayerStatus(player_status);
                }
            }
           
        }
        //Updating a player_status after processing a level.
        public void updatePlayerStatus(Player_Status player_status)
        {
            using (Player_statusRepository player_statusRepository = new Player_statusRepository("DefaultConnection"))
            {
                player_statusRepository.updatePlayerStatus(player_status);
            }
        }


        public void CreatePlayerStatusForARoom(Player player, Room room)
        {
            using (Player_statusRepository player_statusRepository = new Player_statusRepository("DefaultConnection"))
            {
                List<Room_levels> room_levels = Room_LevelsLogic.getRoomLevels(room.ID);

                for (int i = 0; i < room_levels.Count(); i++)

                {
                    Room_levels room_level = room_levels[i];

                    Player_Status player_status = new Player_Status();

                    if (i == 0)
                    {
                        player_status.IsUnlocked = true;
                    }


                    player_status.Player = player;
                    player_status.Room_levels = room_level;

                    addPlayerStatus(player_status);

                }
            }
            
        }
        public List<Player_Status> GetAllPlayerStatusForOnePLayer(Player player)
        {
            using (Player_statusRepository player_statusRepository = new Player_statusRepository("DefaultConnection"))
            {
                return player_statusRepository.GetAllPlayerStatusForOnePLayer(player);
            }
        }

    }
}
