using System;
using BullsAndCows.GameProperties.Colors;

namespace BullsAndCows.GameBoard
{
    using GProperties = BullsAndCows.GameProperties.Properties;


    public class Turn
    {

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
        private readonly Pin[] m_GuessedPins = new Pin[GProperties.PinsSequenceLength];
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