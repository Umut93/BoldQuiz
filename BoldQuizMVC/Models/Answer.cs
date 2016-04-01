using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Answer
    {
        public Question Question { get; set; }
        public string AnswerText { get; set; }
        public Boolean IsCorrect { get; set; }


        public Answer(Question Question, string AnswerText)
        {
            this.Question = Question;
            this.AnswerText = AnswerText;


        }
    }
}
