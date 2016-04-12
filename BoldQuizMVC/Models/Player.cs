using Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : ApplicationUser
    {
        public Player() { }

        public Player(int ID, string userName, string passWord, string gender, Room room) 
        {
            this.Id = ID;
            this.UserName = UserName;
            this.gender = gender;
            this.room = room;

            
            
            
            
        }
        public string gender { get; set; }
        public Room room { get; set; }
       
    }
}
