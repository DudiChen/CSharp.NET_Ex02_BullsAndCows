using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using BullsAndCows.GameBoard;
using BullsAndCows.GameProperties.Colors;
////using GameProperties = BullsAndCows.GameProperties.Properties;

namespace UI.IOHandler
{
    using GameProperties = BullsAndCows.GameProperties.Properties;

    public class InputValidationUtils
    {
        // public const ushort k_NumberOfPinTypes = 8;
        public static bool ValidateUserInput(string i_UserInputString)
        {
            bool isInputCounterValid = true;
            int[] choiceCounter = new int[GameProperties.NumberOfPinColors];

            for (int i = 0; i < i_UserInputString.Length && isInputCounterValid; i++)
            {
                char pinColor = i_UserInputString[i];

                if (i % 2 != 0)
                {
                    isInputCounterValid = (pinColor == ' ');
                }
                else
                {
                    if (pinColor >= 'A' && pinColor <= 'H')
                    {
                        if (choiceCounter[pinColor - 'A'] == 1)
                        {
                            isInputCounterValid = false;
                            break;
                        }
                        choiceCounter[pinColor - 'A']++;
                    }
                    else
                    {
                        isInputCounterValid = false;
                        break;
                    }
                }
            }

            return isInputCounterValid;
        }

        ////public static Turn CompareUserGuess(Pin[] i_UserGuessedPins, Pin[] i_GoalSequence)
        ////{
        ////    Turn.Result resultOfGuess = new Turn.Result();

        ////    for (int j = 0; j < i_GoalSequence.Length; j++)
        ////    {
        ////        for (int i = 0; i < i_UserGuessedPins.Length; i++)
        ////        {
        ////            if (i_GoalSequence[j].Color == i_UserGuessedPins[i].Color)
        ////            {
        ////                if (i == j)
        ////                {
        ////                    resultOfGuess.CorrectInPlacePins++;
        ////                }
        ////                else
        ////                {
        ////                    resultOfGuess.m_CorrectMisplacedPins++;
        ////                }
        ////            }
        ////        }
        ////    }


        ////    return new Turn(i_UserGuessedPins,resultOfGuess);
        ////}
    }
       
}
