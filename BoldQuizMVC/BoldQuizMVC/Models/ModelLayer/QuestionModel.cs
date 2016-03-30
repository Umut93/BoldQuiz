using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class QuestionModel
    {
        public string Title { get; set; }
        public int Point { get; set; }
        public CategoryModel Category { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}