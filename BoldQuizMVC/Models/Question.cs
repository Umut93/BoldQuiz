﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Question
    {
        public Question(string title, int point, Section sectiom) {

            this.title = title;
            this.point = point;
            this.section = section;
            List<Answer> answers = new List<Answer>();
            List<Level> levels = new List<Level>();
           
            
        }

        public string title { get; set; }
        public int point { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Level> levels { get; set; }
        public Section section { get; set; }
    }
}
