using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace BoldQuizMVC.Models
{
    public class RoomDetailsViewModel
    {
        public int roomID { get; set; }
        public List<Player_Status> playerstatus { get; set; }
        public string SectionName { get; set; }
    }
}