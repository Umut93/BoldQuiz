using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Section
    {
        public List<Level> levels{ get; set; }
        public List<Room> rooms { get; set; }
        public List<Question> quetions { get; set; }
    }
}
