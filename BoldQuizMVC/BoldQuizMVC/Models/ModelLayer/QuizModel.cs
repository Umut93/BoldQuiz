using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoldQuizMVC.Models
{
    public class QuizModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}