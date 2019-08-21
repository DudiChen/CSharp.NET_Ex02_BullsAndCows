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

            ////int[] choiceCounter = new int[GameBoardData.k_NumberOfPinTypes];
            //// ADDED A WORKAROUND:
            int[] choiceCounter = new int[GameProperties.NumberOfPinColors];

            for (int i = 0; i < i_UserInputString.Length && isInputCounterValid; i++)
            {
                char pin = i_UserInputString[i];

                if (i % 2 != 0)
                {
                    isInputCounterValid = (pin == ' ');
                }
                else
                {
                    if (pin <= 'A' && pin >= 'H')
                    {
                        if (choiceCounter[pin - 'A'] == 1)
                        {
                            isInputCounterValid = false;
                            break;
                        }
                        choiceCounter[pin - 'A']++;
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

        public static Turn CompareUserGuess(Pin[] i_UserGuessedPins, Pin[] i_GoalSequence)
        {
            Turn.Result resultOfGuess = new Turn.Result();

            for (int j = 0; j < i_GoalSequence.Length; j++)
            {
                for (int i = 0; i < i_UserGuessedPins.Length; i++)
                {
                    if (i_GoalSequence[j].Color == i_UserGuessedPins[i].Color)
                    {
                        if (i == j)
                        {
                            resultOfGuess.CorrectInPlacePins++;
                        }
                        else
                        {
                            resultOfGuess.m_CorrectMisplacedPins++;
                        }
                    }
                }
            }


            return new Turn(i_UserGuessedPins,resultOfGuess);
        }

        private static Pin[] GuessStringToPinArrayConvertor(string i_GuessString)
        {
            Pin[] guessedPins = new Pin[GameProperties.PinsSequenceLength];
            
            string[] guessedStringArray = i_GuessString.Split(' ');

            for (int i = 0; i < guessedPins.Length; i++)
            {
                guessedPins[i] = new Pin(ConvertLetterToColor(guessedStringArray[i][0]));
            }

            return guessedPins;
        }

        private static eColors ConvertLetterToColor(char i_Letter)
        {
            return (eColors)((int)i_Letter - (int)'A');
        }

        public static string PinArrayToStringConvertor(Pin[] i_GuessedPins)
        {
            StringBuilder guessedString = new StringBuilder();
            for (int i = 0; i < i_GuessedPins.Length; i++)
            ////foreach (Pin currentPin in i_GuessedPins)
            {
                if (i > 0)
                {
                    guessedString.Append(' ');
                } 
                ////guessedString.Append(ConvertColorToChar(currentPin.Color));
                guessedString.Append(ConvertColorToChar(i_GuessedPins[i].Color));
            }

            return guessedString.ToString();
        }

        private static char ConvertColorToChar(eColors i_Color)
        {
            return (char)((int)'A' + (int)i_Color);
        }
    }
}
