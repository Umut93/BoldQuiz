using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace DAL
{
    public class QuestionRepository : BaseRepository
    {
        public QuestionRepository(string connectionstring) : base(connectionstring)
        {
        }

        //public List<Question> getBarcaQuetions()
        //{
        //    string sql = "Select TOP 51 * from Question ";
        //    con.Query<Question>(sql, )
        //}
        

        }
    }

