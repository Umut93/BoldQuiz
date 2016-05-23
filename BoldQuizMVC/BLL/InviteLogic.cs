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


    public InviteLogic()
    {

            inviteRepository = new InviteRepository("DefaultConnection");
            userLogic = new UserLogic();
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

        //
        public void acceptInvite(Invite invite)
        {
            Player recipient = userLogic.findPLayer(invite.RecipientID);
            recipient.Room = new Room();
            recipient.Room.ID = invite.Room_id;
            userLogic.updatePlayer(recipient);
            inviteRepository.removeInvite(invite.SenderID, invite.RecipientID);

        }

        public Invite findOneInvite (int senderID, int recipientID)
        {
         return inviteRepository.findInviteForOne(senderID, recipientID);


        }
    }

    

   
}
