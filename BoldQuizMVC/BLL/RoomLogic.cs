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
        private Room_LevelsLogic room_LevelsLogic;
        private LevelLogic levelLogic;

        //Instantiating the classes and repository classes
        public RoomLogic()
        {
            room_LevelsLogic = new Room_LevelsLogic();
            sectionLogic = new SectionLogic();
            levelLogic = new LevelLogic();
        }


        //Getting the levels for a specific Section by the room's sectionid.
        //
        //Assigning a room_level in a specific room
        //For each level in a section we a room_level and assinging its properties with list of levels.
        //The first room_level (level 1) is by default true, becuase it is starting point of the game.
        //Finally we create a room
        
        //For each room_level in the list we add a room_level in the table.
        public void createRoom(Room room)
        {
            var levels = levelLogic.getLevelsForASection(room.SectionID);

            List<Room_levels> Room_levels = new List<Room_levels>();

            foreach (var level in levels)
            {
                Room_levels room_Levels = new Room_levels();
                room_Levels.Level = level;
                room_Levels.Room = room;
                Room_levels.Add(room_Levels);
            }


            using (RoomRepository roomRepository = new RoomRepository("DefaultConnection"))
            {
                roomRepository.createRoom(room);
            }

            foreach (var room_level in Room_levels)
            {
                room_LevelsLogic.addRoomLevel(room_level);
            }

            
        }

        //Getting the room by searching the ID
        public Room getRoom(int id)
        {
            using (RoomRepository roomRepository = new RoomRepository("DefaultConnection"))
            {
                Room room = roomRepository.findOneRoom(id);

                room.Section = sectionLogic.findOneSection(room.SectionID);

                room.Levels = room_LevelsLogic.getRoomLevels(id);
                return room;
            }

        }


        //Finding all players on the same room.
        public List<Player> FindAllPlayerOneRoom(int roomID)
        {
            using (RoomRepository roomRepository = new RoomRepository("DefaultConnection"))
            {
                return roomRepository.FindAllPlayerOneRoom(roomID);
            }

        }

     

    }
}
