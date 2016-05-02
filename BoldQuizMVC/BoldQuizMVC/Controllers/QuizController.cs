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
        //Getting the 10 questions by giving a levelID.
        public ActionResult Index(int levelID)
        {
            List<Question> question = questionLogic.Get10Questions(levelID);
            List<QuestionViewModels> viewModel = new List<QuestionViewModels>();
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
                    answerViewModel.IsSelected = false;

                    questionViewModel.Answers.Add(answerViewModel);

                }

                viewModel.Add(questionViewModel);

            } 
            return View(viewModel);
        }

    [HttpPost]
    public ActionResult submitQuiz(List<QuestionViewModels> questions)
        {


            return null;
        }
    }
}