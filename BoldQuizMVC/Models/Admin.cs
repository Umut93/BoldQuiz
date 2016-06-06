using Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This model is not used at all. The idea was to the admin could make some CRUD operations on the quiz.
    /// </summary>
    public class Admin_ : ApplicationUser
    {
        public Admin_(int ID, string UserName, string PassWord)
        {
            this.Id = ID;
            this.UserName = UserName;
            this.PasswordHash = PassWord;

        }
    }
    
}