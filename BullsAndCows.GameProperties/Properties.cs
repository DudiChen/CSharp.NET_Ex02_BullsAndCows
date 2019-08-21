using System;

namespace BullsAndCows.GameProperties
{
    public class Properties
    {
        public enum eColors
        {
            Green, Red, Blue, Yellow, Orange, Grey, Pink, Brown
        }

        private const uint k_MinimumNumberOfTries = 4;
        private const uint k_MaximumNumberOfTries = 10;
        private const uint k_PinsSequenceLength = 4;
        private static readonly int m_NumberOfPinColors = Enum.GetNames(typeof(eColors)).Length;


        public static int NumberOfPinColors
        {
            get
            {
                return m_NumberOfPinColors;
            }
        }

        public static uint MinimumNumberOfTries
        {
            get
            {
                return k_MinimumNumberOfTries;
            }
        }

        public static uint MaximumNumberOfTries
        {
            get
            {
                return k_MaximumNumberOfTries;
            }
        }
        public static uint PinsSequenceLength
        {
            get
            {
                return k_PinsSequenceLength;
            }
        }
    }
}
