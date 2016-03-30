using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class Player : User
    {
        public string gender;
        public Game game;
    }
}