using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoldQuizMVC.Controllers
{
    public class UserController : Controller
    {
        private SectionRepository sections;

        public UserController()
        {
            sections = new SectionRepository("DefaultConnection");

        }
        

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult chooseSection()
        {
           List<Section> section = sections.getSections();


            return View(section);
        }

        [HttpPost]
        public ActionResult chooseSection(int sectionTeam)
        {


            return RedirectToAction("Index", "Home");

        }
        
    }
}