using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room
    {
        public int point { get; private set; }
        public Section section { get; private set; }
        public List<Player> players { get; private set; }
        public List<Level> levels { get; private set; }



    }
}
