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


        //Every level corresponds to a section. In that section they contain about 50 questions which points to the right levelID.
        //Eliminerer samme forekomst 2 gange
        //Tjek om spørgsmålet allerede findes på listen (linje 27-28) Linjen 33 så er den allerede på listen selvom det er samme kode osv.

        public List<Question> getQuetionsForLevel(int levelID)
        {

            List<Question> quetions = new List<Question>();

            string sql = "SELECT * FROM Level_Question JOIN Question ON question_id = ID JOIN Answer on question.ID = Answer.question_id where level_id = @levelID; ";
            con.Query<Question, Answer, Question>(sql, (question, answer) =>
           {
               if (quetions.FirstOrDefault(x => x.ID == question.ID) == null)

               {
                   quetions.Add(question);

               }
               quetions.FirstOrDefault(x => x.ID == question.ID).Answers.Add(answer);


               return question;
           }, new { levelID = levelID }).ToList();

            return quetions;
        }

        //Getting the PK from Answer
        public Answer getAnswer(int id)
        {
            string sql = "Select * FROM Answer where id = @id;";
            return con.Query<Answer>(sql, new { id = id }).Single();

        }

        //Every single player has a 10-question in a given level and he/she might not complete its quiz-progress. This method saves the questions in the database for re-create it --> cookies. It retrieves from the database
        public List<Question> playerQuestion(int playerID, int level_ID)
        {
            string sql = "SELECT * FROM Player_question JOIN Question on question_id = Question.ID JOIN Answer on Question.ID = Answer.question_id where player_id = @user_ID AND level_id = @level_id";

            List<Question> quetions = new List<Question>();

            con.Query<Question, Answer, Question>(sql, (question, answer) =>
            {

                if (quetions.FirstOrDefault(x => x.ID == question.ID) == null)

                {
                    quetions.Add(question);

                }
                quetions.FirstOrDefault(x => x.ID == question.ID).Answers.Add(answer);


                return question;

            }, new { user_ID = playerID, level_id = level_ID });
            return quetions;
        }

        //When the user clicks in a given level, then the upcoming questions is inserted in the Player_question tabel for the sake of resuming.
        public void savePlayerUnfinishedQuiz(List<Question> quetions, int levelID, int playerID)
        {

            string sql = "INSERT INTO Player_question values (@player_id, @level_id, @question_id)";

            foreach (Question question in quetions)
            {
                con.Execute(sql, new { player_id = playerID, level_id = levelID, question_id = question.ID });
            }

        }
        //After finishing in a given level, the database deletes the player_quetions (data), because you dig into next level. 
        // The database shows overall the levels a person have been thorugh.

        public void deletePlayerQuestions(int levelID, int playerID)
        {
            string sql = "DELETE FROM Player_question where player_id = @player_id AND level_id = @level_id";
            con.Execute(sql, new { player_id = playerID, level_id = levelID });
        }

    }
}


