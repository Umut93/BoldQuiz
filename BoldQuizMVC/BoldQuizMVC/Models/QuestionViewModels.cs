using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{

    // Creating viewModels for representing the needed data when the user is interacting with view. These propeties are needed when the user faces the website.
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