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

        public List<Question> GetQuetionsForLevel(int levelID)
        {
         string sql = "SELECT * FROM Level_Question JOIN Question ON question_id = ID JOIN Answer on question.ID = Answer.question_id where  level_id = @levelID; ";
         return  con.Query<Question, Answer, Question>(sql, (question, answer) => { question.Answers.Add(answer); return question; }, new { levelD = levelID }).ToList();

        }
        

        }
    }

