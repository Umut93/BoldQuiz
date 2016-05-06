using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{

    // Creating viewModels for representing the needed data when the user is interacting with view. These propeties are needed when the user faces the website.
    
        
        // Question: ID, Title, list of answers, and the selectedID (represent the selected possible answer from the radio buttons)
    public class QuestionViewModels
    {
        public int QuestionID { get; set; }
        public String QuestionTitle { get; set;}
        public List<AnswerViewModel> Answers{get; set;}
        public int SelectedAnswerID { get; set; }
        
}

    //Answer: ID and the Answertext
    public class AnswerViewModel 
    {
        public int ID { get; set; }
        public string AnswerText { get; set; }


    }

    //Quiz: The ID of the Level and the QuizViewmodel along with its properties
    public class QuizViewModel
    {
        public int LevelID { get; set; }
        public List<QuestionViewModels> questions { get; set; }
        public int RoomID { get; set; }

    }

  
}