using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Player : User_
    {

        public Player(String ID, string userName, string passWord, string gender, Game game) : base(ID, userName, passWord)
        {
            this.gender = gender;
            this.game = game;
        }
        public string gender { get; set; }
        public Game game { get; set; }
    }
}
