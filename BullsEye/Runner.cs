using System;

//using BullsAndCows;
using BullsAndCows.GameBoard;
using GProperties = BullsAndCows.GameProperties.Properties;

namespace BullsAndCows
{
    

    public class Runner
    {
        
        public static void PlayGame()
        {
            ////int guessNumber = 1;
            bool isSuccessfulGuess = false;

            ushort numberOfGuesses = UI.UIManager.GetNumberOfGuesses();
            GameBoardData gameBoard = new GameBoardData(numberOfGuesses);
            // debug!!!!!

            //// while (!isSuccessfulGuess && guessNumber <= numberOfGuesses)
            while (!isSuccessfulGuess && gameBoard.TurnsPlayed < numberOfGuesses)
            {
                UI.UIManager.DisplayBoard(gameBoard);
                // debug!!!!!
                Console.WriteLine("goal sequence {0}", UI.IOHandler.IOConvertors.PinArrayToStringConvertor(gameBoard.GoalSequence));
                Console.WriteLine("Turn number {0}", gameBoard.TurnsPlayed + 1);
                Pin[] userPinsSequence = UI.UIManager.GetUserGuess();
                Turn newTurn = gameBoard.CompareUserGuess(userPinsSequence);
                gameBoard.AddTurn(newTurn);
                isSuccessfulGuess = newTurn.Results.CorrectInPlacePins == GProperties.PinsSequenceLength;
            }

            if (isSuccessfulGuess)
            {
                UI.UIManager.NotifySuccess();
            }
            else
            {
                UI.UIManager.NotifyFailure(gameBoard.GoalSequence);
            }
        }

    }
}

