using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BoldQuizMVC.Models
{
    
    public class Answer
    {
        public Question question { get; set; }
        public string answerText { get; set; }
        public Boolean isCorrect { get; set; }


        public Answer (Question question, string answerText, Boolean iscorrect)
        {
            this.question = question;
            this.answerText = answerText;
            this.isCorrect = false;

        }
        
    }
    
}