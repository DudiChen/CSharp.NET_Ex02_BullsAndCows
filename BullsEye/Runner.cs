using System;

//using BullsAndCows;
using BullsAndCows.GameBoard;
using GProperties = BullsAndCows.GameProperties.Properties;

namespace BullsAndCows
{
    

    public class Runner
    {
        
        public static void Run()
        {
            bool isSuccessfulGuess = false;
            bool quitGame = false;
            ushort numberOfGuesses = UI.UIManager.GetNumberOfGuesses();
            GameBoardData gameBoard = new GameBoardData(numberOfGuesses);

            //// while (!isSuccessfulGuess && guessNumber <= numberOfGuesses)
            while (!quitGame && !isSuccessfulGuess && gameBoard.TurnsPlayed <= numberOfGuesses)
            {
                UI.UIManager.DisplayBoard(gameBoard);
                UI.IOHandler.UserReply userReply = UI.UIManager.GetUserGuess();
                quitGame = userReply.QuitGame;
                if (!quitGame)
                {
                    Pin[] userPinsSequence = userReply.UserPinsSequence;
                    Turn newTurn = gameBoard.CompareUserGuess(userPinsSequence);
                    gameBoard.AddTurn(newTurn);
                    isSuccessfulGuess = newTurn.Results.CorrectInPlacePins == GProperties.PinsSequenceLength;
                }
            }

            if (!quitGame)
            {
                if(isSuccessfulGuess)
                {
                    UI.UIManager.NotifySuccess(gameBoard.TurnsPlayed);
                }
                else
                {
                    UI.UIManager.NotifyFailure(gameBoard.GoalSequence);
                }
            }
        }

    }
}

