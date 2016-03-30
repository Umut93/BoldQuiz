using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BoldQuizMVC.Models
{
    
    public class AnswerModel
    {
        public QuestionModel Question { get; set; }
        public string AnswerText { get; set; }
        public Boolean IsCorrect { get; set; }


        public AnswerModel(QuestionModel Question, string AnswerText)
        {
            this.Question = Question;
            this.AnswerText = AnswerText;
            

        }
        
    }
    
}