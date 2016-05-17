using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class Room_LevelsLogic
    {
        private Room_LevelsRepository room_LevelsRepository;


        public Room_LevelsLogic()
        {

            room_LevelsRepository = new Room_LevelsRepository("DefaultConnection");

        }

        //Getting the specific room with its level.
        public Room_levels getRoom_level(int room_id, int level_id)

        {
           return room_LevelsRepository.getRoom_level(room_id, level_id);
        }

        //Updating the room_level's property. Whether is open or not, score..
        public void updateRoomLevel(Room_levels room_level)
        {
           room_LevelsRepository.updateRoomLevel(room_level);
        }

        //Inserting values into Room_levels (table). 
        public void addRoomLevel(Room_levels room_level)
        {
            room_LevelsRepository.addRoomLevel(room_level);

        }
    }

    



}
