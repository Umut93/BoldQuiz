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
        private RoomRepository roomRepository;
        private Room_LevelsRepository room_LevelsRepository;


        public RoomLogic()
        {
            roomRepository = new RoomRepository("DefaultConnection");
            room_LevelsRepository = new Room_LevelsRepository("DefaultConnection");

        }


        public void createroom(Room room)
        {
            roomRepository.createRoom(room);

            }

        public Room getRoom(int id)
        {
            Room room = roomRepository.findOneRoom(id);

            room.levels = room_LevelsRepository.getRoom_Levels(id);

            return room;
        }

     

    }
}
