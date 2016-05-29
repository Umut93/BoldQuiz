using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class InviteLogic
    {
        private InviteRepository inviteRepository;
        private UserLogic userLogic;
        private RoomLogic roomLogic;


    public InviteLogic()
    {

            inviteRepository = new InviteRepository("DefaultConnection");
            userLogic = new UserLogic();
            roomLogic = new RoomLogic();
            
        }

        //Adding a invite object into the table. The invite contains the sender/reciepent and finally what room the sender has sent the invite. 
        public void invitePLayer(Invite invite)
    {
            inviteRepository.addInvite(invite);
    }
        //Finding invites for one person (for a reciepent). 
        public List<Invite> findInviteForOnePerson(int user_id)
        {
          return  inviteRepository.findInvitesForOnePerson(user_id);
        }

        //Finding the player (RecipientID) and giving the player a new room as well. Its roomid is assigned to the requested roomid and then we are updating the player's room to that which it has accepted.
        //After accepting, we remove the recent generated invite.
        public void acceptInvite(Invite invite)
        {
            Player recipient = userLogic.findPLayer(invite.RecipientID);
            recipient.Room = new Room();
            recipient.Room.ID = invite.Room_id;
            userLogic.updatePlayer(recipient);
            inviteRepository.removeInvite(invite.SenderID, invite.RecipientID);

        }

        //Finding a specific invite by a composite key.
        public Invite findOneInvite (int senderID, int recipientID)
        {
         return inviteRepository.findInviteForOne(senderID, recipientID);

        }

        //    //Decline a invite and perserve the room you are allocated to.
        //    public void declineInvite (Invite invite)
        //    {
        //       inviteRepository.removeInvite(invite.SenderID, invite.RecipientID);
        //    }
        //
    }

    

   
}
