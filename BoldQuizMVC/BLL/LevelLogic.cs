using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
  public  class LevelLogic
    {
        LevelRepository LevelRepository;

        public LevelLogic()
        {
            LevelRepository = new LevelRepository("DefaultConnection");

        }

        public List<Level> getLevelsForASection(int sectionID)
        {
           return LevelRepository.getLevelsForASection(sectionID);
        }

    }
}
