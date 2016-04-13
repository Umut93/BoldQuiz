using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Identity;
using BLL;

namespace BoldQuizMVC.Controllers
{
    public class UserController : Controller

    {
        private UserLogic userLogic;
        private SectionLogic sectionLogic;

        public UserController()
        {
            userLogic = new UserLogic();
            sectionLogic = new SectionLogic();

        }
        

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult chooseSection()
        {
            List<Section> sections = sectionLogic.getSections();


            return View(sections);
        }

        [HttpPost]
        public ActionResult chooseSection(int sectionTeam)
        {

            userLogic.chooseSection(sectionTeam, User.Identity.Name);
            
            return RedirectToAction("Index", "Home");

        }

        
        
    }
}