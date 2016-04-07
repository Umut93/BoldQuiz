using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;
namespace DAL
{
   public class SectionRepository : BaseRepository
    {
        public SectionRepository(string connectionstring) : base(connectionstring)
        {
        }
    }
}
