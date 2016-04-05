using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Section
    {
        public Section(string name)
        {
            this.name = name;
            List<Level> levels = new List<Level>();
            List<Room> rooms = new List<Room>();
            List<Question> quetions = new List<Question>();


        }
        public string name { get; private set; }
        public List<Level> levels{ get; set; }
        public List<Room> rooms { get; set; }
        public List<Question> quetions { get; set; }
    }
}
