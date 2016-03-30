using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class Answer
    {
        public Question quetion;
        public string answerText;
        public Boolean isCorrect;
    }
}