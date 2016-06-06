using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Every single answer has ID and linked on a question and a text. The selected answers tells wwhether is true or false based on the id.
    /// </summary>
    public class Answer
    {
        public int ID {get; set;}
        public Question Question {get; set;}
        public string AnswerText {get; set;}
        public bool IsCorrect {get; set;}

        public Answer() { }

        public Answer(int ID, Question Question, string AnswerText)
        {
            this.ID = ID;
            this.Question = Question;
            this.AnswerText = AnswerText;

        }

       
        
        
    }
}
