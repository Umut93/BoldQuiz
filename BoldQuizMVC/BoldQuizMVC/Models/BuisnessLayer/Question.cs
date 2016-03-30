using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class Question
    {
        public Category category;
        public List<Answer> answers;
    }
}