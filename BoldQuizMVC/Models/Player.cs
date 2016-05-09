using Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : ApplicationUser
    {   public string Gender { get; set; }
        public Room Room { get; set; }


        

        public Player(int ID, string UserName, string PassWord, string Gender, Room Room) 
        {
            this.Id = ID;
            this.UserName = UserName;
            this.Gender = Gender;
            this.Room = Room;
        }
       public Player() { }
       
    }
}
