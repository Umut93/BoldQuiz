using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class SectionLogic
    {

        //Instantiating 
        public SectionLogic()
        {

            

        }

        //Find one Section by the ID
        public Section findOneSection (int id)
        {
            using (SectionRepository sectionRepository = new SectionRepository("DefaultConnection"))
            {
                return sectionRepository.findOneSection(id); 
            }
        }


        //Getting a list of sections.
        public List<Section> getSections() {
            using (SectionRepository sectionRepository = new SectionRepository("DefaultConnection"))
            {
                return sectionRepository.getSections();
            }

        }

          
    }
}
