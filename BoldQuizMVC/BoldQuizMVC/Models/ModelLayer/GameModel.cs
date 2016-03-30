using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class GameModel
    {
        public string name { get; set; }
        public PlayerModel Player { get; set; }
        public List<CategoryModel> categories { get; set; }
    }
}