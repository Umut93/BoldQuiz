using BLL;
using BoldQuizMVC.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BoldQuizMVC.Controllers
{
    
    public class QuizController : Controller
    {
        private UserLogic UserLogic;
        private QuestionLogic questionLogic;
        private Room_LevelsLogic room_LevelsLogic;
        private Player_StatusLogic player_StatusLogic;
        private RoomLogic RoomLogic;


        // Instantiating the questionLogic
        public QuizController()
        {
            questionLogic = new QuestionLogic();
            room_LevelsLogic = new Room_LevelsLogic();
            player_StatusLogic = new Player_StatusLogic();
            UserLogic = new UserLogic();
            RoomLogic = new RoomLogic();

        }

        // GET: Quiz
        //PlayArena: In that momemnt you click a level in a specific room.
        //UserID = ID number in AspnetUser
        //x (models.Question). It is main question (question.id) and its possible answers. Loops 10 times. It orders the id of the questions!
        //The player_status is based on the specifik room on a specific level. Afterwards finding that player and adding it in the table!
        //57: For each questions (10) populating them and its answers in the viewmodel.
        //Getting the 10 questions by giving a levelID. Afterwards populating the data in the viewModels! If questions is empty, then generate 10 random questions. 
        //Linie 43 if 10 keep going or empty generate!
        //Creating a player_status. Populating level,room as objects and get a specific room_level_id (info).
        //If the list of questions are empty then it should generate random-questions (loading the page for first time), if not then we keep the questions until the user is finished (loading for second time). 
        // Linie 48: It retrieves the already generated questions which are not finished yet and then ordering the questions by their ID's. We save them as well for resuming the game.
        public ActionResult Index(int levelID, int roomID)
        {
            int userID = int.Parse(User.Identity.GetUserId());
            List<Question> question;

      
            question = questionLogic.playerQuestion(roomID, levelID);
            if (question.Count == 0)
            {
                question = questionLogic.Get10Questions(levelID);
                questionLogic.savePlayerUnfinishedQuiz(question, levelID, roomID);

            }
            question = question.OrderBy(x => x.ID).ToList();

            QuizViewModel viewModel = new QuizViewModel();
            viewModel.LevelID = levelID;
            viewModel.RoomID = roomID;

            viewModel.questions = new List<QuestionViewModels>();

            foreach (var item in question)
            {

                QuestionViewModels questionViewModel = new QuestionViewModels();
                questionViewModel.QuestionID = item.ID;
                questionViewModel.QuestionTitle = item.Title;
                questionViewModel.Answers = new List<AnswerViewModel>();

                foreach (var answers in item.Answers)
                {
                    AnswerViewModel answerViewModel = new AnswerViewModel();
                    answerViewModel.AnswerText = answers.AnswerText;
                    answerViewModel.ID = answers.ID;


                    questionViewModel.Answers.Add(answerViewModel);

                }

                viewModel.questions.Add(questionViewModel);

            }
            return View(viewModel);
        }

        //Couting the right answers x/x in a specifik Room_level.
        // The logic finds the right RoomID and levelID as well.
        //SelectedAnswerdID --> QuestionViewModel
        [HttpPost]
        public string submitQuiz(QuizViewModel model)

        {
           int userid = int.Parse(User.Identity.GetUserId());
           var room_level = room_LevelsLogic.getRoom_level(model.RoomID, model.LevelID);

            int correctedAnswers = 0;
            foreach (var question in model.questions)
            {

                var isCorrect = questionLogic.isAnsweredCorrect(question.SelectedAnswerID);

                if (isCorrect)
                {
                    correctedAnswers++;

                }

                
            }
            Player player = UserLogic.findPLayer(userid);
            Player_Status playerStatus = player_StatusLogic.findPlayerStatus(player, room_level);
            playerStatus.SavedScore = correctedAnswers;
            if(playerStatus.SavedScore < room_level.Level.Score)
            {
                playerStatus.Warnings++;
            }
            player_StatusLogic.updatePlayerStatus(playerStatus);




            //Getting all the players in the room. The first room_level is open.

            List<Player> players =  RoomLogic.FindAllPlayerOneRoom(model.RoomID);

            bool isCompleted = true;

            foreach (Player roomPlayer in players)
            {
                Player_Status player_status =   player_StatusLogic.findPlayerStatus(roomPlayer, room_level);
                
                if(player_status == null || player_status.SavedScore < room_level.Level.Score )
                {
                    isCompleted = false;
                }
                
            }

            if (isCompleted)
            {

                foreach (Player roomPlayer in players)
                {

                    Room_levels nextRoomLevel = room_LevelsLogic.getRoom_level(model.RoomID, room_level.Level.Next_level);
                    Player_Status nextPlayerStatus = player_StatusLogic.findPlayerStatus(roomPlayer, nextRoomLevel);
                    nextPlayerStatus.IsUnlocked = true;
                    player_StatusLogic.updatePlayerStatus(nextPlayerStatus);

                }

            }
            room_LevelsLogic.updateRoomLevel(room_level);
       
            questionLogic.deletePlayerQuestions(model.LevelID, model.RoomID);

            if(playerStatus.Warnings == 1)
            {
                //gult kort
                return "Du har svaret rigtigt på " + correctedAnswers.ToString() + "/10. Det er ikke nok. Du har fået et gult kort!";
            }
            else if(playerStatus.Warnings == 2)
            {
                //rødt kort
                
                return "Du har svaret rigtigt på " + correctedAnswers.ToString() + "/10. Det er ikke nok. Du har fået rødt kort og er blevet sparket af holdet!!";
            }

            return "Du har svaret rigtigt på " + correctedAnswers.ToString() + "/10";
        }

    }
    
}