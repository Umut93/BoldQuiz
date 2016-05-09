using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Answer
    {
        public int ID { get; set; }
        public Question Question { get; set; }
        public string AnswerText { get; set; }
        public Boolean IsCorrect { get; set; }


        public Answer(int ID, Question Question, string AnswerText)
        {
            this.ID = ID;
            this.Question = Question;
            this.AnswerText = AnswerText;


        }

       public Answer()
        {
            

        }
        
    }
}
