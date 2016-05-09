using BLL;
using BoldQuizMVC.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BoldQuizMVC.Controllers
{
    public class QuizController : Controller
    {
        private QuestionLogic questionLogic;
        private Room_LevelsLogic room_LevelsLogic;


        // Instantiating the questionLogic
        public QuizController()
        {
            questionLogic = new QuestionLogic();
            room_LevelsLogic = new Room_LevelsLogic();

        }

        // GET: Quiz
        //Getting the 10 questions by giving a levelID. Afterwards populating the data in the viewModels!
        public ActionResult Index(int levelID, int roomID)
        {
            List<Question> question = questionLogic.Get10Questions(levelID);
            QuizViewModel viewModel = new QuizViewModel();
            viewModel.LevelID = levelID;
            viewModel.RoomID = roomID;

            viewModel.questions = new List<QuestionViewModels>();

            foreach (var item in question)
            {

                QuestionViewModels questionViewModel = new QuestionViewModels();
                questionViewModel.QuestionID = item.ID;
                questionViewModel.QuestionTitle = item.Title;
                questionViewModel.Answers = new List<AnswerViewModel>();

                foreach (var answers in item.Answers)
                {
                    AnswerViewModel answerViewModel = new AnswerViewModel();
                    answerViewModel.AnswerText = answers.AnswerText;
                    answerViewModel.ID = answers.ID;


                    questionViewModel.Answers.Add(answerViewModel);

                }

                viewModel.questions.Add(questionViewModel);

            }
            return View(viewModel);
        }

        //Couting the right answers x/x
        // The logic finds the right RoomID and levelID as well.
        [HttpPost]
        public string submitQuiz(QuizViewModel model)
        {
           var room_level = room_LevelsLogic.getRoom_level(model.RoomID, model.LevelID);

            int correctedAnswers = 0;
            foreach (var question in model.questions)
            {

                var isCorrect = questionLogic.isAnsweredCorrect(question.SelectedAnswerID);

                if (isCorrect)
                {
                    correctedAnswers++;

                }

                
            }
            room_level.SavedScore = correctedAnswers;
            room_LevelsLogic.updateRoomLevel(room_level);

            // The requirements for opening the next level. NextroomLevel opens the nezt level IF you have achieved the earned points.
            if (correctedAnswers >= room_level.Level.Score)
            {
                Room_levels nextRoomLevel = room_LevelsLogic.getRoom_level(model.RoomID, room_level.Level.Next_level);

                nextRoomLevel.IsUnlocked = true;

                room_LevelsLogic.updateRoomLevel(nextRoomLevel);
          
            }
 
            return "Du har svaret rigtigt på " + correctedAnswers.ToString() + "/10";
        }
    }
}