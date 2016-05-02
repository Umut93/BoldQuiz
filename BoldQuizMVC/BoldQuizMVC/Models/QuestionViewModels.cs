using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class QuestionViewModels
    {
        public int QuestionID { get; set; }
        public String QuestionTitle { get; set;}
        public List<AnswerViewModel> Answers{get; set;}
}


    public class AnswerViewModel 
    {
        public int ID { get; set; }
        public string AnswerText { get; set; }
        public bool IsSelected {get; set; }

    }

}