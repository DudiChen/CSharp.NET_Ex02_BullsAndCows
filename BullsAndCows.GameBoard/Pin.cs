using System;
using BullsAndCows.GameProperties.Colors;

namespace BullsAndCows.GameBoard
{

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
