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
        // Creating a room based on the section, players, room_levels.
        //34: Levels = 5. Level 1-5 pass to room_levels.level. + room
        //55 Each level is passed into a room_level
        //For Each level we assign them in a room_level and the room we create is also passed in.
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
