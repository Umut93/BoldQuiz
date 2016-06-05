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


        public Room_LevelsLogic()
        {
            

        }

        //Getting one room_level based on the room and level you are on.
        public Room_levels getRoom_level(int room_id, int level_id)

        {
            using (Room_LevelsRepository room_LevelsRepository = new Room_LevelsRepository("DefaultConnection"))
            {
                return room_LevelsRepository.getRoom_level(room_id, level_id); 
            }
        }


        public List<Room_levels> getRoomLevels(int roomID)
        {
            using (Room_LevelsRepository room_LevelsRepository = new Room_LevelsRepository("DefaultConnection"))
            {
                return room_LevelsRepository.getRoom_Levels(roomID);
            }

        }

        //Updating a room_level's properties based on the room and level you are on.
        public void updateRoomLevel(Room_levels room_level)
        {
            using (Room_LevelsRepository room_LevelsRepository = new Room_LevelsRepository("DefaultConnection"))
            {
                room_LevelsRepository.updateRoomLevel(room_level);
            }
        }

        //Adding a room_level's properties in the database.
        public void addRoomLevel(Room_levels room_level)
        {
            using (Room_LevelsRepository room_LevelsRepository = new Room_LevelsRepository("DefaultConnection"))
            {
                room_LevelsRepository.addRoomLevel(room_level);
            }

        }

        //Getting a specific room based on its levelid.
        public Room_levels getRoom_level(int room_level_id)
        {
            using (Room_LevelsRepository room_LevelsRepository = new Room_LevelsRepository("DefaultConnection"))
            {
                return room_LevelsRepository.getRoom_level(room_level_id);
            }
        }

    }

    



}
