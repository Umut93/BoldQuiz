using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public abstract class User_
    {
        protected User_(string ID, string userName, string passWord)
        {
            this.ID = ID;
            this.userName = userName;
            this.passWord_ = passWord;
        }

        public string ID { get; private set; }
        [Required]
        [RegularExpression(@"\d{6,10}", ErrorMessage = "Username must be between 6 and 10 characters.")]
        [Display(Name = "Username")]
        //[Column =]
        public string userName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 8)]
        [Display (Name ="Password")]
        public string passWord_ { get; set; }
    }
}
