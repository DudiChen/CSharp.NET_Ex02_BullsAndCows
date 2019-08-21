using BullsAndCows.GameBoard;
using GProperties = BullsAndCows.GameProperties.Properties;
using BullsAndCows.GameProperties.Colors;
using System.Text;

namespace BullsAndCows.IO
{
    public class IOConvertors
    {
        public static Pin[] GuessStringToPinArrayConvertor(string i_GuessString)
        {
            Pin[] guessedPins = new Pin[GProperties.PinsSequenceLength];
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
            {
                if (i > 0)
                {
                    guessedString.Append(' ');
                }
                guessedString.Append(ConvertColorToChar(i_GuessedPins[i].Color));
            }

            return guessedString.ToString();
        }

        private static char ConvertColorToChar(eColors i_Color)
        {
            return (char)((int)'A' + (int)i_Color);
        }

        public static string resultStringBuilder(Turn.Result i_GuessResultArray)
        {
            StringBuilder resultString = new StringBuilder();
            ushort numberOfPinsApended = 0;
            for (int i = 0; i < i_GuessResultArray.CorrectInPlacePins; i++, numberOfPinsApended++)
            {
                resultString.Append("V ");
            }

            for (int i = 0; i < i_GuessResultArray.CorrectMisplacedPins; i++, numberOfPinsApended++)
            {
                resultString.Append("X ");
            }

            for (int i = numberOfPinsApended; i < GProperties.PinsSequenceLength; i++)
            {
                resultString.Append("  ");
            }
            resultString.Remove(resultString.Length - 1, 1);
            return resultString.ToString();
        }
    }
}

