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


        //Instantiating the logic classes
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


        //The view when you choose the section.
        [HttpGet]
        public ActionResult chooseSection()
        {
            List<Section> sections = sectionLogic.getSections();

            return View(sections);
        }

        //After choosing the section you redirect to a specific room(id).
        //Linje 54: action/controller/routevalues (room number)

        [HttpPost]
        public ActionResult chooseSection(int sectionTeam)
        {

            Room room = userLogic.chooseSection(sectionTeam, User.Identity.Name);

            return RedirectToAction("Details", "Room", new { id = room.ID });

        }

        
        
    }
}