using System;
////using BullsAndCows.GameBoard.Colors;
using BullsAndCows.GameProperties.Colors;

namespace BullsAndCows.GameBoard
{
    ////namespace Colors
    ////{
    ////    public enum eColors
    ////    {
    ////        Green, Red, Blue, Yellow, Orange, Grey, Pink, Brown
    ////    }
    ////}


    public struct Pin
    {
        private eColors m_Color;

        public Pin(eColors i_Color)
        {
            m_Color = i_Color;
        }

        public eColors Color
        {
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }
    }
}
