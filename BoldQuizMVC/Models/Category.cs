using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Game> Games { get; set; }
        public List<Question> Quetions { get; set; }

    }
}
