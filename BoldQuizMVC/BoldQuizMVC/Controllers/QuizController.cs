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

        public QuizController ()
        {
            questionLogic = new QuestionLogic();

        }

        // GET: Quiz
        public ActionResult Index(int levelID)
        {
          List<Question> question =  questionLogic.Get10Questions(levelID);

            return View(question);
        }
    }
}