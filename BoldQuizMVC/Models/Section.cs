using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Every section has a ID, Name, list of levels, rooms and questions as well.
    /// </summary>
    public class Section
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Level> Levels{ get; set; }
        public List<Room> Rooms { get; set; }
        public List<Question> Quetions { get; set; }

        public Section() { }

        public Section(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
            Levels = new List<Level>();
            Rooms = new List<Room>();
            Quetions = new List<Question>();
      
            

        }

      
    }
}
