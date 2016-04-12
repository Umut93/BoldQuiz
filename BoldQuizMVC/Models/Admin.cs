using Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Admin_ : ApplicationUser
    {
        public Admin_(int ID, string userName, string passWord)
        {
            this.Id = ID;
            this.UserName = UserName;
            this.PasswordHash = passWord;

        }
    }
    
}