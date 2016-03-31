using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public abstract class User_
    {
      

        protected User_(string ID, string userName, string passWord)
        {
            this.ID = ID;
            this.userName = userName;
            this.passWord_ = passWord;
        }
        public string ID { get; private set;}
        public string userName { get; set; }
        public string passWord_ { get; set; }
    }
}