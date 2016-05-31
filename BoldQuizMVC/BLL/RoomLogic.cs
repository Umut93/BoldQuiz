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
        private LevelLogic levelLogic;

        //Instantiating the classes and repository classes
        public RoomLogic()
        {
            roomRepository = new RoomRepository("DefaultConnection");
            room_LevelsRepository = new Room_LevelsRepository("DefaultConnection");
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

            Room_levels.FirstOrDefault().IsUnlocked = true;

            roomRepository.createRoom(room);

            foreach (var room_level in Room_levels)
            {
                room_LevelsRepository.addRoomLevel(room_level);
            }


        }

        //Getting the room by searching the ID
        public Room getRoom(int id)
        {
            Room room = roomRepository.findOneRoom(id);

            room.Section = sectionLogic.findOneSection(room.SectionID);

            room.Levels = room_LevelsRepository.getRoom_Levels(id);

            return room;
        }

     

    }
}
