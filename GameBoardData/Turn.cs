using System;
using System.ComponentModel;
////using BullsAndCows.GameBoard.Colors;
using BullsAndCows.GameProperties.Colors;
////using GameProperties = BullsAndCows.GameProperties.Properties;

namespace BullsAndCows.GameBoard
{
    using GameProperties = BullsAndCows.GameProperties.Properties;
    ////public enum eResultFlags
    ////{
    ////    None, Bull, Cow
    ////}
    ////namespace Colors
    ////{
    ////    public enum eColors
    ////    {
    ////        Green, Red, Blue, Yellow, Orange, Grey, Pink, Brown
    ////    }
    ////}

    public class Turn
    {

        ////public struct Pin
        ////{
        ////    private eColors m_Color;

        ////    public Pin(eColors i_Color)
        ////    {
        ////        m_Color = i_Color;
        ////    }

        ////    public eColors Color
        ////    {
        ////        get
        ////        {
        ////            return m_Color;
        ////        }
        ////    }
        ////}

        public struct Result
        {
            public ushort m_CorrectInPlacePins;
            public ushort m_CorrectMisplacedPins;

            public Result(ushort i_CorrectInPlacePins, ushort i_CorrectMisplacedPins)
            {
                m_CorrectInPlacePins = i_CorrectInPlacePins;
                m_CorrectMisplacedPins = i_CorrectMisplacedPins;
            }

            public ushort CorrectInPlacePins
            {
                get
                {
                    return m_CorrectInPlacePins;
                }
                set
                {
                    m_CorrectInPlacePins = value;
                }
            }

            public ushort CorrectMisplacedPins
            {
                get
                {
                    return m_CorrectMisplacedPins;
                }
                set
                {
                    m_CorrectMisplacedPins = value;
                }
            }
        }

        //private string m_guess;
        private readonly Pin[] m_GuessedPins = new Pin[GameProperties.PinsSequenceLength];
        private readonly Result m_Result;

        public Turn(Pin[] i_GuessedPins, Result i_Result)
        {
            m_GuessedPins = i_GuessedPins;
            m_Result = i_Result;
        }

        public Result Results
        {
            get
            {
                return m_Result;
            }
        }

        public Pin[] Guess
        {
            get
            {
                return m_GuessedPins;
            }
        }
    }
}