using System;
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
            string sql = "INSERT INTO Invite VALUES (@SenderID, @RecipientID, @room_id)";
            con.Execute(sql, invite);

        }

        //Finding a LIST of invites for one person (for a recipient). The invite contains the sender's ID og recipient's ID and which room the sender has invited on.
        public List<Invite> findInvitesForOnePerson(int user_id)
        {

          string sql = "SELECT * FROM INVITE where RecipientID  = @recipientID";
          return con.Query<Invite>(sql, new { recipientID = user_id }).ToList();

        }
        //Finding ONE invite for a specifik person (for a recipient). The invite contains the sender's ID og recipient's id and which room the sender has invited on.
        public Invite findInviteForOne(int senderID, int recipientID)
        {
            string sql = "SELECT * FROM invite WHERE senderID = @senderID AND RecipientID = @RecipientID";
            return con.Query<Invite>(sql, new { senderID = senderID, RecipientID = recipientID }).Single();

        }

        //Deleting one invite by senderID and recipientID  (as a composite key). I could actually make a ID as identier (0.1 - object-oriented).
        public void removeInvite(int senderID, int RecipientID)
        {
            string sql = "DELETE FROM Invite WHERE senderID = @senderID AND RecipientID = @RecipientID";
            con.Execute(sql, new { senderID = senderID, RecipientID = RecipientID });
        }

    }
}
