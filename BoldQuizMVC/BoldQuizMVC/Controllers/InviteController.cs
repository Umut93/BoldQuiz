using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Web.Mvc;
using BoldQuizMVC.Models;
using Models;
using Microsoft.AspNet.Identity;

namespace BoldQuizMVC.Controllers
{
    public class InviteController: Controller
    {
        private InviteLogic inviteLogic;
        private UserLogic UserLogic;

        public InviteController ()
    {
        inviteLogic = new InviteLogic();
        UserLogic = new UserLogic();
    }
        //This method takes InviteViewModel as a argument. The invite gets the id of the sender and the reciepten's id and the roomID as well (just like the table shows). 
        //We are getting the userName which is parsed in the input(viewmodel).
        //ActionName/Controller/id
        public ActionResult  InvitePlayer (InviteViewModel inviteViewModel)
        {
            int userID = int.Parse(User.Identity.GetUserId());
            Player player = UserLogic.findPLayer(inviteViewModel.UserName);
            Invite invite = new Invite(userID, player.Id, inviteViewModel.roomID);

            inviteLogic.invitePLayer(invite);

            return RedirectToAction("Details", "Room", new {id = inviteViewModel.roomID }); 

        }
    }

   
}