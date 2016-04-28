﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Section
    {
        public Section(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
            Levels = new List<Level>();
            Rooms = new List<Room>();
            Quetions = new List<Question>();


        }

        public Section() { }
        public int ID { get; set; }
        public string Name { get; private set; }
        public List<Level> Levels{ get; set; }
        public List<Room> Rooms { get; set; }
        public List<Question> Quetions { get; set; }
    }
}
