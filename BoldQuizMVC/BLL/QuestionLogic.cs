using DAL;
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

        public QuestionLogic ()
        {
            
        }

        //25: The list gets all 52 questions based on the levelID. Aftwards randonmly take 10.
       //  Guid the random generator generates 10 question of 52 questions!
        public List<Question> Get10Questions(int levelID)
        {

            using (QuestionRepository questionRepository = new QuestionRepository("DefaultConnection"))
            {
                List<Question> questions = questionRepository.getQuetionsForLevel(levelID);
                return questions = questions.OrderBy(x => Guid.NewGuid()).Take(10).ToList(); 
            }
           
        }

        // This method gives the result if a given answer is correct or not.
        public bool isAnsweredCorrect (int id)
        {
            using (QuestionRepository questionRepository = new QuestionRepository("DefaultConnection"))
            {
                var answer = questionRepository.getAnswer(id);

                return answer.IsCorrect;
            }


        }

        // Every single player has a 10-question in a given level and he/she might not complete its quiz-progress. This method retrieves the questions in the database for re-create it. For loading the questions again, so the user can resume!
        //Room_id --> team as whole in the same room
        public List<Question> playerQuestion(int room_id, int level_ID)
        {
            using (QuestionRepository questionRepository = new QuestionRepository("DefaultConnection"))
            {
                return questionRepository.playerQuestion(room_id, level_ID);
            }
        }

        //When the user clicks in a given level, then the upcoming questions is inserted in the Player_question tabel for the sake of resuming.
        // The 10 questions are saved based on the level_id and room_id.
        public void savePlayerUnfinishedQuiz(List<Question> quetions, int levelID, int room_id)
        {
            using (QuestionRepository questionRepository = new QuestionRepository("DefaultConnection"))
            {
                questionRepository.savePlayerUnfinishedQuiz(quetions, levelID, room_id);
            }
        }


        //After finishing in a given level, the database deletes the player_quetions (data), because you dig into next level. 
        // The players questions are deleted based on the level and room he is on.
        public void deletePlayerQuestions(int levelID, int room_id)
        {
            using (QuestionRepository questionRepository = new QuestionRepository("DefaultConnection"))
            {
                questionRepository.deletePlayerQuestions(levelID, room_id);
            }
        }
    }

    
    

}
