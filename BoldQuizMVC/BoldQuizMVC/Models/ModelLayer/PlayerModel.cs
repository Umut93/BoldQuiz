using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class PlayerModel : UserModel
    {
        
        public PlayerModel(String ID, string userName, string passWord, string gender, GameModel game ):base (ID, userName, passWord)
        {
            this.gender = gender;
            this.game = game;
        }
        public string gender { get; set; }
        public GameModel game { get; set; }
    }
}