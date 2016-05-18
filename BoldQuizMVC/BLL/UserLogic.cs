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
        private PlayerRepository playerRepository;
        private SectionLogic sectionLogic;
        private RoomLogic roomLogic;


        //Instantiating classes and repository classes.
        public UserLogic ()
        {
            playerRepository = new PlayerRepository("DefaultConnection");
            sectionLogic = new SectionLogic();
            roomLogic = new RoomLogic();

    }

        //After finding the section - creating the room and assigning the player in a room. 
        public Room chooseSection(int id, string userName)
        {
            Section section = sectionLogic.findOneSection(id);

            Room room = new Room(0, section);

            roomLogic.createRoom(room);
            Player player = playerRepository.findOnePlayer(userName);

            player.Room = room;
            playerRepository.updatePlayer(player);

            return room;
        }

        //Finding one player by its username
        public Player findPLayer (String userName)
        {
          return playerRepository.findOnePlayer(userName);

        }
    }
}
