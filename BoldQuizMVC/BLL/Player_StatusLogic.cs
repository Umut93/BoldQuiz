using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class Player_StatusLogic
    {
        private Player_statusRepository player_statusRepository;

        public Player_StatusLogic()
        {
            player_statusRepository = new Player_statusRepository("DefaultConnection");
        }


        public Player_Status findPlayerStatus(int playerID, int room_levels_id)

        {
           return player_statusRepository.findPlayerStatus(playerID, room_levels_id);
        }


        public void addPlayerStatus(Player_Status player_status)
        {
            player_statusRepository.addPlayerStatus(player_status);

        }

        public void updatePlayerStatus(Player_Status player_status)
        {
            player_statusRepository.updatePlayerStatus(player_status);
        }



    }
}
