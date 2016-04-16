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

        public UserLogic ()
        {
            playerRepository = new PlayerRepository("DefaultConnection");
            sectionLogic = new SectionLogic();
            roomLogic = new RoomLogic();

    }


        public Room chooseSection(int id, string userName)
        {
            Section section = sectionLogic.findOneSection(id);

            Room room = new Room(0, section);

            roomLogic.createroom(room);
            Player player = playerRepository.findOnePlayer(userName);

            player.Room = room;
            playerRepository.updatePlayer(player);

            return room;
        }
    }
}
