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


        // Instantiating the questionLogic
        public QuizController ()
        {
            questionLogic = new QuestionLogic();

        }

        // GET: Quiz
        //Getting the 10 questions by giving a levelID. Afterwards populating the data in the viewModels!
        public ActionResult Index(int levelID)
        {
            List<Question> question = questionLogic.Get10Questions(levelID);
            QuizViewModel viewModel = new QuizViewModel();
            viewModel.LevelID = levelID;


            viewModel.questions = new List<QuestionViewModels>();

            foreach (var item in question) {

                QuestionViewModels questionViewModel = new QuestionViewModels();
                questionViewModel.QuestionID = item.ID;
                questionViewModel.QuestionTitle = item.Title;
                questionViewModel.Answers = new List<AnswerViewModel>();

                foreach(var answers in item.Answers)
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

        //Couting the right answers
    [HttpPost]
    public string submitQuiz(List<QuestionViewModels> questions)
        {
            int correctedAnswers = 0;
            foreach (var question in questions)
            {
                
                var isCorrect = questionLogic.isAnsweredCorrect(question.SelectedAnswerID);

                if (isCorrect)
                {
                    correctedAnswers++;

                }

            }


            return "Du har svaret rigtigt på " + correctedAnswers.ToString() + "/10";
        }
    }
}