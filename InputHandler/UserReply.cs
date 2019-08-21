using System;
using System.Collections.Generic;
using System.Text;
using BullsAndCows.GameBoard;
namespace UI.IOHandler
{
    public class UserReply
    {
        private readonly Pin[] m_UserPinsSequence;
        private readonly bool m_QuitGame;

        public UserReply(bool i_QuitGame, Pin[] i_UserPinsSequence)
        {
            m_UserPinsSequence = i_UserPinsSequence;
            m_QuitGame = i_QuitGame;
        }

        public Pin[] UserPinsSequence
        {
            get
            {
                return m_UserPinsSequence;
            }
        }

        public bool QuitGame
        {
            get
            {
                return m_QuitGame;
            }
        }
    }
}
