﻿using System;


namespace BullsAndCows.GameProperties
{
    namespace Colors
    {
        public enum eColors
        {
            Green, Red, Blue, Yellow, Orange, Grey, Pink, Brown
        }
    }
    public class Properties
    {
        private const uint k_MinimumNumberOfTries = 4;
        private const uint k_MaximumNumberOfTries = 10;
        private const uint k_PinsSequenceLength = 4;
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
