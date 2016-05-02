﻿using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuestionLogic
    {
        private QuestionRepository questionRepository;

        public QuestionLogic ()
        {
            questionRepository = new QuestionRepository("DefaultConnection");
        }

        //Getting the 10 questions based on level. Guid the random generator which takes 10!
        public List<Question> Get10Questions(int levelID)
        {
        List<Question> questions =  questionRepository.GetQuetionsForLevel(levelID);
        return questions = questions.OrderBy(x=>Guid.NewGuid()).Take(10).ToList();
           
        }
    }

}