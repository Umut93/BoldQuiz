using BLL;
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
          List<Question> question =  questionLogic.Get10Questions(levelID);

            return View(question);
        }
    }
}