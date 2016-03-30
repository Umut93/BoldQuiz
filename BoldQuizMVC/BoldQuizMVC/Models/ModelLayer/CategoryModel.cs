using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public string Levels { get; set; }
        public string Score { get; set; }
        public List<GameModel> Games { get; set; }
        public QuizModel Quiz { get; set; }
        public List<QuestionModel> Quetions { get; set; }

    }
}