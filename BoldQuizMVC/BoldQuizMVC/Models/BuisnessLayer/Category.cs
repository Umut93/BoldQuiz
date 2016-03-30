using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class Category
    {
        public List<Game> games { get; set; }
        public Quiz quiz { get; set; }
        public List<Question> quetions { get; set; }

    }
}