using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{

    //Using is used in the methods for the sake of Database timeout which caused the connections when several wants to connect.
    public class InviteLogic
    {
        private UserLogic userLogic;
        private RoomLogic roomLogic;
        private Player_StatusLogic Player_statusLogic;


        public InviteLogic()
        {
            userLogic = new UserLogic();
            roomLogic = new RoomLogic();
            Player_statusLogic = new Player_StatusLogic();

        }

        //Adding a invite into the table. The invite contains the sender/reciepent and finally what room the sender has sent the invite. 
        public void invitePLayer(Invite invite)
        {
            using (InviteRepository inviteRepository = new InviteRepository("DefaultConnection"))
            {
                inviteRepository.addInvite(invite);
            }
        }
        //Finding a list of invites for one person (for a reciepent). 
        public List<Invite> findInviteForOnePerson(int user_id)
        {
            using (InviteRepository inviteRepository = new InviteRepository("DefaultConnection"))
            {
                return inviteRepository.findInvitesForOnePerson(user_id);
            }
        }



        //Finding the player (RecipientID) by the invite and giving the player a new room as well.
        //Its roomid is assigned to the requested roomid and then we are updating the player's room to that which it has accepted.
        //After accepting, we remove the recent generated invite.
        public void acceptInvite(Invite invite)
        {
            using (InviteRepository inviteRepository = new InviteRepository("DefaultConnection"))
            {
                Player recipient = userLogic.findPLayer(invite.RecipientID);
                recipient.Room = new Room();
                recipient.Room.ID = invite.Room_id;
                userLogic.updatePlayer(recipient);
                Player_statusLogic.CreatePlayerStatusForARoom(recipient, recipient.Room);
                inviteRepository.removeInvite(invite.SenderID, invite.RecipientID);
            }

        }

        //Finding a specific invite by a composite key.
        public Invite findOneInvite(int senderID, int recipientID)
        {
            using (InviteRepository inviteRepository = new InviteRepository("DefaultConnection"))
            {
                return inviteRepository.findInviteForOne(senderID, recipientID);
            }

        }

        //Decline a invite and perserve the room you are allocated to.
        public void declineInvite(Invite invite)
        {
            using (InviteRepository inviteRepository = new InviteRepository("DefaultConnection"))
            {
                Player recipient = userLogic.findPLayer(invite.RecipientID);

                inviteRepository.removeInvite(invite.SenderID, invite.RecipientID);
            }
        }

    }




}
