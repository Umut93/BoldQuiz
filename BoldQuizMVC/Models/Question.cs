using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Question
    {
        public string Title { get; set; }
        public int point;
        public List<Answer> Answers { get; set; }
        public Level level { get; set; }
        public Section section { get; set; }
    }
}
