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
    //Using is used for the sake of Database timeout which caused the connections when several wants to connect.
    public class Player_StatusLogic
    {
       
        private Room_LevelsLogic Room_LevelsLogic;
        

        public Player_StatusLogic()
        {
            
            Room_LevelsLogic = new Room_LevelsLogic();
          
        }

        //Finding a player_status based on the player ID and the room_levels id.
        //If the player_status is not null, the playerStatus is set to the specific room with its specific level and the player is also assigned as well.
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
        //Finding a player_status by searching the player and player's room_levels. If the player is not already in the table, we add it.
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

        //Getting all the Room_level based on roomID. Iterating over 5 times and the the room_level index is passed in the objects and the first element (level) for a player is set to true because of the starting point.
        //Finally we pass the player and room information in the player_status. Adding the playerStatus (external call)
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
        //Getting all player_staus for ONE player.
        public List<Player_Status> GetAllPlayerStatusForOnePLayer(Player player)
        {
            using (Player_statusRepository player_statusRepository = new Player_statusRepository("DefaultConnection"))
            {
                return player_statusRepository.GetAllPlayerStatusForOnePLayer(player);
            }
        }

    }
}
