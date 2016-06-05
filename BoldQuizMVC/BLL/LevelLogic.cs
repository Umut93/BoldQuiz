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

        public LevelLogic()
        {

        }


        //Getting all levels from a specific section.
        public List<Level> getLevelsForASection(int sectionID)
        {
          
            using (LevelRepository LevelRepository = new LevelRepository("DefaultConnection"))
            {
                return LevelRepository.getLevelsForASection(sectionID); 
            }
        }

    }
}
