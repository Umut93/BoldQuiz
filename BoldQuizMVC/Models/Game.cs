using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Game
    {
        public string Name { get; set; }
        public Player Player { get; set; }
        public List<Category> categories { get; set; }
    }
}
