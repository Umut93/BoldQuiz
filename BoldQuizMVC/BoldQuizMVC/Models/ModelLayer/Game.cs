using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class Game
    {
        public string name { get; set; }
        public Player Player { get; set; }
        public List<Category> categories { get; set; }
    }
}