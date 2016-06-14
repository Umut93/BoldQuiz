using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
namespace BLL
{
    public class UserLogic
    {
        private SectionLogic sectionLogic;
        private RoomLogic roomLogic;
        private Player_StatusLogic player_status;


        //Instantiating classes and repository classes.
        public UserLogic()
        {
            sectionLogic = new SectionLogic();
            roomLogic = new RoomLogic();
            player_status = new Player_StatusLogic();

        }

        //After registering, you direct to categories. 
        //Finding the section by the id, and creating a room for that section. 
        //Finding a player by its username and then assigning that player in a room .
        //After finding the section - creating the room and assigning the player in a room (updating the player's room). 
        //For creating a room we need to know the sectionID and the userName who has chosen that.
        //We create a section and a room.
        public Room chooseSection(int id, string userName)
        {
            using (PlayerRepository playerRepository = new PlayerRepository("DefaultConnection"))
            {
                Section section = sectionLogic.findOneSection(id);

                Room room = new Room(0, section);

                roomLogic.createRoom(room);
                Player player = playerRepository.findOnePlayer(userName);

                player.Room = room;
                playerRepository.updatePlayer(player);
                player_status.CreatePlayerStatusForARoom(player, room);

                return room; 
            }
        }

        //Finding one player by its username
        public Player findPLayer(String userName)
        {
            using (PlayerRepository playerRepository = new PlayerRepository("DefaultConnection"))
            {
                return playerRepository.findOnePlayer(userName);
            }

        }

        //Finding a player by ID
        public Player findPLayer(int userID)
        {
            using (PlayerRepository playerRepository = new PlayerRepository("DefaultConnection"))
            {
                return playerRepository.findOnePlayer(userID);
            }

        }

        //Updating player's room_id and gender (not gonna channge at all).
        public void updatePlayer (Player player)
        {
            using (PlayerRepository playerRepository = new PlayerRepository("DefaultConnection"))
            {
                playerRepository.updatePlayer(player);
            }

        }
    }
    }
