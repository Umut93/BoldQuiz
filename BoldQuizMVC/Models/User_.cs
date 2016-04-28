//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Models
//{
//    public abstract class User_
//    {
//        protected User_(string ID, string UserName, string PassWord)
//        {
//            this.ID = ID;
//            this.UserName = UserName;
//            this.PassWord_ = PassWord;
//        }

//        public string ID { get; private set; }
//        [Required]
//        [RegularExpression(@"\d{6,10}", ErrorMessage = "Username must be between 6 and 10 characters.")]
//        [Display(Name = "Username")]
//        //[Column =]
//        public string UserName { get; set; }
//        [Required]
//        [StringLength(10, MinimumLength = 8)]
//        [Display (Name ="Password")]
//        public string PassWord_ { get; set; }
//    }
//}
