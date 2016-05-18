using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Invite
    {
        public int SenderID { get; set; }
        public int RecipientID { get; set; }
        public int RoomID { get; set; }



        public Invite(int SenderID, int RecipientID, int RoomID)
        {
            this.SenderID = SenderID;
            this.RecipientID = RecipientID;
            this.RoomID = RoomID;
        }

        public Invite() { }

    }
}
