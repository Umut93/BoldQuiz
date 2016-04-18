using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
   public class RoomLogic
    {
        private SectionLogic sectionLogic;
        private RoomRepository roomRepository;
        private Room_LevelsRepository room_LevelsRepository;


        public RoomLogic()
        {
            roomRepository = new RoomRepository("DefaultConnection");
            room_LevelsRepository = new Room_LevelsRepository("DefaultConnection");
            sectionLogic = new SectionLogic();
        }


        public void createroom(Room room)
        {
            roomRepository.createRoom(room);

            }

        public Room getRoom(int id)
        {
            Room room = roomRepository.findOneRoom(id);

            room.Section = sectionLogic.findOneSection(room.SectionID);

            room.Levels = room_LevelsRepository.getRoom_Levels(id);

            return room;
        }

     

    }
}
