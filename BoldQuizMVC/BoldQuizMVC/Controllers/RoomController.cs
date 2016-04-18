using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BoldQuizMVC.Controllers
{
    public class RoomController : Controller
    {
        private RoomLogic roomLogic;
        // GET: Room

public RoomController()
        {
            roomLogic = new RoomLogic();

        }

        public ActionResult Details(int id)

        {
          Room room =  roomLogic.getRoom(id);

            return View(room);
        }
    }
}