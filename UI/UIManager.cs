﻿using System;
using System.Text;
using BullsAndCows;
using BullsAndCows.GameBoard;
////using BullsAndCows.GameBoard.Colors;
using BullsAndCows.GameProperties.Colors;
using GameProperties = BullsAndCows.GameProperties.Properties;
using UI.IOHandler;
namespace UI
{
    public class UIManager
    {
        
        private const string k_EmptyResult = "       ";
        private const string k_EmptyGuess  = "       ";
        private const string k_HiddenGuess = "# # # #";
        private const int k_ResultStringLength = 8;

        private UIManager()
        {

        }

        public static ushort GetNumberOfGuesses()
        {
            ushort inputUshortNumber;

            System.Console.WriteLine("Please insert how many guesses you want to have (between {0} and {1}) in this game: ",GameProperties.MaximumNumberOfTries, GameProperties.MaximumNumberOfTries);
            while (!ushort.TryParse(System.Console.ReadLine(), out inputUshortNumber))
            {
                System.Console.WriteLine(@"The input that was entered was not the correct type!
Reenter a number:");
            }

            return inputUshortNumber;
        }

        public static Pin[] GetUserGuess()
        {
            System.Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit:");
          
            return System.Console.ReadLine();
            
        }

        public static void DisplayBoard(GameBoardData i_Data)
        {
            System.Console.WriteLine(
                @"|Pins:    |Result:|
|=========|=======|");
            printBoardRow(k_HiddenGuess, k_EmptyResult);
            //////
            //////
            foreach (Turn turn in i_Data.m_Turns)
            {
                if (turn.Guess.Equals(string.Empty))
                {
                    printBoardRow(k_EmptyGuess, k_EmptyResult);
                }
                else
                {
                    printBoardRow(turn.Guess, resultStringBuilder(turn.PinResult));
                }
            }
        }

        private static void printBoardRow(string i_PinsToPrint, string i_PinResult)
        {
            System.Console.WriteLine(
                @"| {0} |{1}|
|=========|=======|",
                i_PinsToPrint,
                i_PinResult);
        }

        private static string resultStringBuilder(Turn.Result i_GuessResultArray)
        {
            StringBuilder resultString = new StringBuilder(k_ResultStringLength);
            ushort numberOfPinsApended = 0;
            for (int i = 0; i < i_GuessResultArray.CorrectInPlacePins; i++, numberOfPinsApended++)
            {
                resultString.Append("V ");
            }

            for (int i = 0; i < i_GuessResultArray.CorrectMisplacedPins; i++, numberOfPinsApended++)
            {
                resultString.Append("X ");
            }

            for (int i = numberOfPinsApended; i < GameProperties.PinsSequenceLength; i++)
            {
                resultString.Append("  ");
            }
            resultString.Remove(k_ResultStringLength-1, 1);
            return resultString.ToString();
        }
    }
}
