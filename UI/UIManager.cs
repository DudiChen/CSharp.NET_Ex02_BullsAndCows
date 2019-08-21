using System;
using System.Text;
using BullsAndCows;
using BullsAndCows.GameBoard;
using BullsAndCows.GameProperties.Colors;
using GameProperties = BullsAndCows.GameProperties.Properties;
using UI.IOHandler;
using Ex02.ConsoleUtils;

namespace UI
{
    public class UIManager
    {

        private const string k_EmptyResult = "       ";
        private const string k_EmptyGuess = "       ";
        private const string k_HiddenGuess = "# # # #";
        private const string k_Separator = "|=========|=======|";
        private const string k_TableHeader = "|Pins:    |Result:|";
        private const string k_MainHeader = "Current board statuse:";
        private const int k_ResultStringLength = 8;

        private UIManager()
        {

        }

        public static ushort GetNumberOfGuesses()
        {
            ushort inputUshortNumber;

            System.Console.WriteLine("Please insert how many guesses you want to have (between {0} and {1}) in this game: ", GameProperties.MinimumNumberOfTries, GameProperties.MaximumNumberOfTries);
            bool parseResult = ushort.TryParse(System.Console.ReadLine(), out inputUshortNumber);
            while (!parseResult || InputValidationUtils.IsOutOfBound(inputUshortNumber))
            {
                if (!parseResult)
                {
                    System.Console.WriteLine(@"The input that was entered was not the correct type!
Reenter a number:");
                }
                else
                {
                    System.Console.WriteLine(@"Input out of bound please reenter a number:");
                }
                parseResult = ushort.TryParse(System.Console.ReadLine(), out inputUshortNumber);

            }

            return inputUshortNumber;
        }

        public static UserReply GetUserGuess()
        {
            UserReply result;
            System.Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit:");
            string userInput = System.Console.ReadLine();
            bool quitGame = IOHandler.InputValidationUtils.QuitValidator(userInput);
            while (!quitGame && !UI.IOHandler.InputValidationUtils.ValidateUserInput(userInput))
            {
                System.Console.WriteLine("Input guess is incorrect. Please insert a new input:");
                userInput = System.Console.ReadLine();
                quitGame = IOHandler.InputValidationUtils.QuitValidator(userInput);
            }
            if (!quitGame)
            {
                result = new UserReply(quitGame, UI.IOHandler.IOConvertors.GuessStringToPinArrayConvertor(userInput));
            }
            else
            {
                result = new UserReply(quitGame, null);
            }

            return result;

        }

        public static void DisplayBoard(GameBoardData i_Data)
        {
            StringBuilder gameBoardString = new StringBuilder();
            Screen.Clear();
            gameBoardString.AppendFormat("{1}{0}", Environment.NewLine, k_MainHeader);
            gameBoardString.AppendFormat("{1}{0}{2}{0}", Environment.NewLine, k_TableHeader, k_Separator);
            gameBoardString.AppendFormat("| {1} |{2}|{0}{3}{0}", Environment.NewLine, k_HiddenGuess, k_EmptyResult, k_Separator);
            for (int i = 0; i < i_Data.TotalNumberOfTurns; i++)
            {

                if (i >= i_Data.TurnsPlayed)
                {
                    gameBoardString.AppendFormat("| {1} |{2}|{0}{3}{0}", Environment.NewLine, k_EmptyGuess, k_EmptyResult, k_Separator);
                }
                else
                {
                    gameBoardString.AppendFormat(
                        "| {1} |{2}|{0}{3}{0}",
                        Environment.NewLine,
                        IOConvertors.PinArrayToStringConvertor(i_Data.GetTurn(i).Guess),
                        IOConvertors.resultStringBuilder(i_Data.GetTurn(i).Results),
                        k_Separator);

                }
            }



            ////printBoardRow(k_HiddenGuess, k_EmptyResult);
            ////for (int i = 0; i < i_Data.TotalNumberOfTurns; i++)
            ////{

            ////    if (i <= i_Data.TurnsPlayed)
            ////    {
            ////        printBoardRow(k_EmptyGuess, k_EmptyResult);
            ////    }
            ////    else
            ////    {
            ////        printBoardRow(
            ////            IOConvertors.PinArrayToStringConvertor(i_Data.GetTurn(i).Guess),
            ////            IOConvertors.resultStringBuilder(i_Data.GetTurn(i).Results));
            ////    }
            ////}
            System.Console.WriteLine(gameBoardString);
        }

        public static void NotifyFailure(Pin[] i_Goalsequence)
        {
            System.Console.WriteLine(
                @"you have failed to guess the apponentes sequence <{0}> ",
                IOConvertors.PinArrayToStringConvertor(i_Goalsequence));

        }

        public static void NotifySuccess(int i_NumberOfTurns)
        {
            System.Console.WriteLine("Congratulations! you have guessed after {0} steps!", i_NumberOfTurns);
        }
        public static bool PromptNewGameQuery()
        {
            System.Console.WriteLine("Would you like to start a new game? <Y/N>");
            string userInput = System.Console.ReadLine();
            while (!IOHandler.InputValidationUtils.YesNoValidator(userInput))
            {
                System.Console.WriteLine("Input is incorrect. please reenter decision:");
                userInput = System.Console.ReadLine();

            }

            return "Y".Equals(userInput);
        }
    }
}
