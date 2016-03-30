using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string Levels { get; set; }
        public string Score { get; set; }
        public List<Game> Games { get; set; }
        public Quiz Quiz { get; set; }
        public List<Question> Quetions { get; set; }

    }
}