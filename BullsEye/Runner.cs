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
            int guessNumber = 1;
            bool isSuccessfulGuess = false;

            ushort numberOfGuesses = UI.UIManager.GetNumberOfGuesses();
            GameBoardData gameBoard = new GameBoardData(numberOfGuesses);

            //// while (!isSuccessfulGuess && guessNumber <= numberOfGuesses)
            while (!isSuccessfulGuess && gameBoard.TurnsPlayed <= numberOfGuesses)
            {
                UI.UIManager.DisplayBoard(gameBoard);
                Pin[] userPinsSequence = UI.UIManager.GetUserGuess();
                Turn newTurn = gameBoard.CompareUserGuess(userPinsSequence);
                gameBoard.AddTurn(newTurn);
                isSuccessfulGuess = newTurn.Results.CorrectInPlacePins == GProperties.PinsSequenceLength;
            }

            if (isSuccessfulGuess)
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

