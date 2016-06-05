using BLL;
using BoldQuizMVC.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace BoldQuizMVC.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private RoomLogic roomLogic;
        private UserLogic userLogic;
        private Player_StatusLogic playerStatusLogic;
        // GET: Room

        //instantiating the roomLogic
        public RoomController()
        {
            roomLogic = new RoomLogic();
            playerStatusLogic = new Player_StatusLogic();
            userLogic = new UserLogic();


        }

        //Room view
        public ActionResult Details(int id)

        {

            int userID = int.Parse(User.Identity.GetUserId());
            RoomDetailsViewModel room = new RoomDetailsViewModel();
            room.roomID = id;
            room.SectionName = roomLogic.getRoom(id).Section.Name;
            room.playerstatus = playerStatusLogic.GetAllPlayerStatusForOnePLayer(userLogic.findPLayer(userID));
            foreach(Player_Status status in room.playerstatus)
            {
                if(status.Warnings == 2)
                {
                    return RedirectToAction("ChooseSection", "User");
                }
            }

            return View(room);
        }
    }
}