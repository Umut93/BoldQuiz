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
    [Authorize]
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
        
        //After logging in, the user gets its invites.
        //JSonrequestBehaviour = den skal gør det den endelig skal gøre = nemlig hente = sikkerhed
        //Data=SenderID, receipentid, roomID = object (in array)
        //MVC doenst allow you to responds to an HTTP get request with a JSON payload. 
        //If you need to send JSON in response to a GET, you'll need to explicitly allow the behaviour (security reasons).
        public ActionResult findInvitesForOnePerson()
        {
            int userID = int.Parse(User.Identity.GetUserId());
            List<Invite> invites = inviteLogic.findInviteForOnePerson(userID);

            return Json(invites, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //Finding one invite by senderID and recipientID.
        //Finding the player (Recipient) and giving the player a new room as well. Its roomid is assigned to the requested roomid and then we are updating the player's room to that which it has accepted.
        //After accepting, we remove the recent generated invite.
        //Fortæller status om serveren (http header for en succeful request). Validering efter accept!
        public ActionResult acceptInvite (int senderID, int recipientID)
        {
          Invite invite =  inviteLogic.findOneInvite(senderID, recipientID);
          inviteLogic.acceptInvite(invite);

          return new HttpStatusCodeResult(200);




        }
    }

   
}