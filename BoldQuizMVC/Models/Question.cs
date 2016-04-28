using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Question
    {
        public Question(int ID, string Title, int Point, Section Section) {

            this.ID = ID;
            this.Title = Title;
            this.Point = Point;
            this.Section = Section;
            Answers = new List<Answer>();
            Levels = new List<Level>();
           
            
        }

        public Question() {
          Answers = new List<Answer>();
          Levels = new List<Level>();

        }

        public int ID { get; set; }
        public string Title { get; set; }
        public int Point { get; set; }
        public List<Answer> Answers { get; set; }
        public List<Level> Levels { get; set; }
        public Section Section { get; set; }
    }
}
