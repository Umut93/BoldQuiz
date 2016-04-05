using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : User_
    {

        public Player(String ID, string userName, string passWord, string gender, Room room) : base(ID, userName, passWord)
        {
            this.gender = gender;
            this.room = room;
            
        }
        public string gender { get; set; }
        public Room room { get; private set; }
        //public int Levels { get; set; }
    }
}
