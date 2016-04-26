﻿using System;
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


        //Tjek om spørgsmålet allerede findes på listen (linje 27-28) Linjen 33 så er den allerede på listen selvom det er samme kode osv.
        public List<Question> GetQuetionsForLevel(int levelID)
        {

            List<Question> quetions = new List<Question>();

            string sql = "SELECT * FROM Level_Question JOIN Question ON question_id = ID JOIN Answer on question.ID = Answer.question_id where  level_id = @levelID; ";
            con.Query<Question, Answer, Question>(sql, (question, answer) =>
           {
               if (quetions.FirstOrDefault(x => x.ID == question.ID) == null)

               {
                   quetions.Add(question);

               }
               quetions.FirstOrDefault(x => x.ID == question.ID).Answers.Add(answer);
             //question.Answers.Add(answer);

             return question;
           }, new { levelID = levelID }).ToList();

            return quetions;
        }


    }
}

