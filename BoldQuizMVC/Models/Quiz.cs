using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Quiz
    {
        public string Name { get; set; }
        public string Description_ { get; set; }
        public List<Category> Categories { get; set; }
    }
}
