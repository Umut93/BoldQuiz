using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//The needed properties. Need to add the userName you invite your friend to and the roomID you belong to.
namespace BoldQuizMVC.Models
{
    public class InviteViewModel
    {
        public string UserName { get; set;}
        public int roomID { get; set;}


        public InviteViewModel(string Username, int roomID)
        {
            this.UserName = UserName;
            this.roomID = roomID;
        }

        public InviteViewModel() { }
    }

}