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


        public SectionLogic()
        {

            sectionRepository = new SectionRepository("DefaultConnection");

        }

        public Section findOneSection (int id)
        {
         return sectionRepository.findOneSection(id);
        }



        public List<Section> getSections() {

          return sectionRepository.getSections();

        }

          
    }
}
