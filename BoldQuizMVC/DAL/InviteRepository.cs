﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace DAL
{
    public class InviteRepository : BaseRepository
    {

        public InviteRepository(string connectionstring) : base(connectionstring)
        {

        }

        //Adding a invite object into the table. The invite contains the sender/reciepent and finally what room the sender has sent the invite. 
        public void addInvite (Invite invite)
        {
            string sql = "INSERT INTO Invite VALUES (@SenderID, @RecipientID, @RoomID)";
            con.Execute(sql, invite);

        }

        //Finding invites for one person (for a reciepent). 
        public List<Invite> findInviteForOnePerson(int user_id)
        {

          string sql = "SELECT * FROM INVITE where RecipientID  = @recipientID";
          return con.Query<Invite>(sql, new { recipientID = user_id }).ToList();

        }


    }
}
