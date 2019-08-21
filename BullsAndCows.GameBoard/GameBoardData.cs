
using System;
using System.Collections.Generic;
using BullsAndCows.GameBoard;
////using BullsAndCows.GameBoard.Colors;
using BullsAndCows.GameProperties.Colors;
////using GameProperties = BullsAndCows.GameProperties.Properties;

namespace BullsAndCows.GameBoard
{
    using GameProperties = BullsAndCows.GameProperties.Properties;
    public class GameBoardData
    {
        ////public const int k_MinimumNumberOfTries = 4;
        ////public const int k_MaximumNumberOfTries = 10;

        ////public const uint k_NumberOfPinsToGuess = 4;
        
        ////private Turn[] m_Turns = new Turn[k_MaximumNumberOfTries];
        //private Turn[] m_Turns;
        private List<Turn> m_Turns;
        private Pin[] m_GoalSequence;

        public GameBoardData(ushort i_NumberOfGuesses)
        {
            //m_Turns = new Turn[i_NumberOfGuesses];
            m_Turns = new List<Turn>(i_NumberOfGuesses);
            this.GoalSequence = GeneratePinGoalSequence();
            ////m_NumberOfPinColors = 
            
        }

        public void AddTurn(Turn i_NewTurn)
        {
            if (m_Turns.Count < m_Turns.Capacity)
            {
                m_Turns.Add(i_NewTurn);
            }
        }

        public Turn GetTurn(int i_TurnIndex)
        {
            Turn turnResult = null;
            if (0 <= i_TurnIndex && m_Turns.Count >= i_TurnIndex)
            {
                turnResult = m_Turns[i_TurnIndex];
            }

            return turnResult;
        }

        public Pin[] GoalSequence
        {
            get
            {
                return m_GoalSequence;
            }
            private set
            {
                m_GoalSequence = value;
            }
        }

       


        private Pin[] GeneratePinGoalSequence()
        {
            Pin[] goalPinsSequence = new Pin[GameProperties.PinsSequenceLength];

            for (int i = 0; i < goalPinsSequence.Length; i++)
            {
                Random randomizer = new Random();
                int colorNumber = randomizer.Next(GameProperties.NumberOfPinColors);
                eColors color = (eColors)colorNumber;
                if (i > 0)
                {
                    while (!IsUniquePinColor(goalPinsSequence, color, i - 1))
                    {
                        colorNumber = randomizer.Next(GameProperties.NumberOfPinColors);
                        color = (eColors)colorNumber;
                    }
                }

                goalPinsSequence[i] = new Pin(color);
                ////m_GoalSequence[i].Color = color;
            }

            return goalPinsSequence;
        }

        private bool IsUniquePinColor(Pin[] i_GoalPinSequence, eColors i_Color, int i_MaxIterator)
        {
            bool result = true;
            int iterator = 0;

            //// IN ORDER NOT TO USE i_MaxIterator:
            ////foreach (Pin currentPin in m_GoalSequence)
            ////{
            ////    if (!currentPin.Equals(null))
            ////    {
            ////        if (i_Color == currentPin.Color)
            ////        {
            ////            result = false;
            ////            break;
            ////        }
            ////    }
            ////    else
            ////    {
            ////        break;
            ////    }
            ////}


            foreach (Pin currentPin in i_GoalPinSequence)
            {
                if (iterator < i_MaxIterator)
                {
                    if (i_Color == currentPin.Color)
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        iterator++;
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public Turn this[int i_TurnIndex]
        {
            get
            {
                return m_Turns[i_TurnIndex];
            }
        }
    }
}
