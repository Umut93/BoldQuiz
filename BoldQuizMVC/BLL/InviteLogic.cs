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


    public InviteLogic()
    {

            inviteRepository = new InviteRepository("DefaultConnection");
    }

        //Adding a invite object into the table. The invite contains the sender/reciepent and finally what room the sender has sent the invite. 
        public void invitePLayer(Invite invite)
    {
            inviteRepository.addInvite(invite);
    }
        //Finding invites for one person (for a reciepent). 
        public List<Invite> findInviteForOnePerson(int user_id)
        {
          return  inviteRepository.findInviteForOnePerson(user_id);
        }
    }

    

   
}
