﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// One invite contains the sender and recipient id and as well the roomID which the sender has sent on.
    /// </summary>
   public class Invite
    {
        public int SenderID {get; set;}
        public int RecipientID {get; set;}
        public int Room_id {get; set;}

        public Invite() { }


        public Invite(int SenderID, int RecipientID, int Room_id)
        {
            this.SenderID = SenderID;
            this.RecipientID = RecipientID;
            this.Room_id = Room_id;
        }

       

    }
}
