using System;
using BullsAndCows.GameBoard;
using BullsAndCows.GameProperties.Colors;

namespace BullsAndCows.IO
{
    using GProperties = BullsAndCows.GameProperties.Properties;

    public class InputValidationUtils
    {
        private enum ePinUIDisplay
        {
            A, B, C, D, E, F, G, H
        }

        public static bool ValidateUserInput(string i_UserInputString)
        {
            bool isInputCounterValid = true;
            int[] choiceCounter = new int[GProperties.NumberOfPinColors];
            string[] pinsInGuess = i_UserInputString.Split(' ');
            foreach (string pin in pinsInGuess)
            {
                if (!isInputCounterValid)
                {
                    break;
                }

                if (!Enum.IsDefined(typeof(ePinUIDisplay), pin))
                {
                    isInputCounterValid = false;
                }
            }

            return isInputCounterValid;
        }

        public static bool IsOutOfBound(ushort i_InputUshort)
        {
            return i_InputUshort > GProperties.MaximumNumberOfTries || i_InputUshort < GProperties.MinimumNumberOfTries;
        }

        public static bool YesNoValidator(string i_UserInput)
        {
            return "Y".Equals(i_UserInput) || "N".Equals(i_UserInput);
        }

        public static bool QuitValidator(string i_UserInput)
        {
            return "Q".Equals(i_UserInput);
        }
    }
}
