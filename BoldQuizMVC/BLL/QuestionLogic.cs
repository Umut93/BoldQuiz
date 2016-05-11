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
        List<Question> questions =  questionRepository.getQuetionsForLevel(levelID);
        return questions = questions.OrderBy(x=>Guid.NewGuid()).Take(10).ToList();
           
        }

        // Getting the answer id and seeing if it is true
        public bool isAnsweredCorrect (int id)
        {
            var answer = questionRepository.getAnswer(id);

            return answer.IsCorrect;


        }

        // Every single player has a 10-question in a given level and he/she might not complete its quiz-progress. This method saves the questions in the database for re-create it. For loading the questions again, so the user can resume!
        public List<Question> playerQuestion(int playerID, int level_ID)
        {
          return  questionRepository.playerQuestion(playerID, level_ID);
        }
        
    }

    
    

}
