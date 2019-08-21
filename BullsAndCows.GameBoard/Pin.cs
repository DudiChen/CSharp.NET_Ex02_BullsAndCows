using System;
using eColors = BullsAndCows.GameProperties.Properties.eColors;

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
