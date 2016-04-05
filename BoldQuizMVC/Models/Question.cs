using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Question
    {
        public Question(string title, int point, Level level, Section sectiom) {

            this.title = title;
            this.point = point;
            List<Answer> answers = new List<Answer>();
            this.level = level;
            this.section = section;
            
        }

        public string title { get; set; }
        public int point { get; set; }
        public List<Answer> Answers { get; set; }
        public Level level { get; set; }
        public Section section { get; set; }
    }
}
