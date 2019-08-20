using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using GameBoardDataManager;

namespace InputHandler
{
    public class InputValidationUtils
    {
        public static bool ValidateUserInput(string i_UserInputString)
        {
            bool isInputCounterValid = true;
            int[] choiceCounter = new int[GameBoardData.k_NumberOfPinTypes];
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

        public static Turn CompareUserGuess(string i_UserInputString, string i_Guess)
        {
            Turn currentTurn = new Turn();
            Turn.Result resultOfGuess = new Turn.Result();
            for (int j = 0; j < i_Guess.Length; j++)
            {
                for (int i = 0; i < i_UserInputString.Length; i++)
                {
                    if (i_Guess[j] == i_UserInputString[i])
                    {
                        if (i == j)
                        {
                            resultOfGuess.m_CorrectInPlaceUshort++;
                        }
                        else
                        {
                            resultOfGuess.m_CorrectMisplaceUshort++;
                        }
                    }
                }
            }

            currentTurn.PinResult = resultOfGuess;
            return currentTurn;
        }
    }
}
