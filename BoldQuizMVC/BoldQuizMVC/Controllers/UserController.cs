using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Identity;

namespace BoldQuizMVC.Controllers
{
    public class UserController : Controller
    {
        private UserRepository users;
        private PlayerRepository players;
        private SectionRepository sections;
        private RoomRepository rooms;

        public UserController()
        {
            users = new UserRepository("DefaultConnection");
            sections = new SectionRepository("DefaultConnection");
            rooms = new RoomRepository("DefaultConnection");
            players = new PlayerRepository("DefaultConnection");


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
            Section section = sections.findOneSection(sectionTeam);
            
            Room room = new Room(0, section);

            rooms.createRoom(room);
            Player player = players.findOnePlayer(User.Identity.Name);

            player.room = room;
            players.updatePlayer(player);
            return RedirectToAction("Index", "Home");

        }

        
        
    }
}