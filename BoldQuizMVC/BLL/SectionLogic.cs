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
        private SectionRepository sectionRepository;

        //Instantiating 
        public SectionLogic()
        {

            sectionRepository = new SectionRepository("DefaultConnection");

        }

        //Find one Section by the ID
        public Section findOneSection (int id)
        {
         return sectionRepository.findOneSection(id);
        }


        //Getting a list of sections.
        public List<Section> getSections() {

          return sectionRepository.getSections();

        }

          
    }
}
