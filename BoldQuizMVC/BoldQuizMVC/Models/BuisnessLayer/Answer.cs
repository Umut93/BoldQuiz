using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class Answer
    {
        public Question quetion {get; set;}
        public string answerText { get; set; }
        public Boolean isCorrect { get; set; }
    }
}