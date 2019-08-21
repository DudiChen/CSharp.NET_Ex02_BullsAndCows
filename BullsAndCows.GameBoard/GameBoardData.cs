using System;
using System.Collections.Generic;
using BullsAndCows.GameProperties.Colors;

namespace BullsAndCows.GameBoard
{
    using GProperties = BullsAndCows.GameProperties.Properties;

    public class GameBoardData
    {
        private List<Turn> m_Turns;
        private Pin[] m_GoalSequence;
        private ushort m_TotalNumberOfTurns;

        public GameBoardData(ushort i_NumberOfGuesses)
        {
            m_TotalNumberOfTurns = i_NumberOfGuesses;
            m_Turns = new List<Turn>(i_NumberOfGuesses);
            this.GoalSequence = GeneratePinGoalSequence();
        }

        public int TotalNumberOfTurns
        {
            get
            {
                return m_TotalNumberOfTurns;
            }
        }

        public int TurnsPlayed
        {
            get
            {
                return m_Turns.Count;
            }
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
            Turn requestedTurn = null;
            if (i_TurnIndex >= 0 && m_Turns.Count >= i_TurnIndex)
            {
                requestedTurn = m_Turns[i_TurnIndex];
            }

            return requestedTurn;
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
            Pin[] goalPinsSequence = new Pin[GProperties.PinsSequenceLength];
            Random randomizer = new Random();

            for (int i = 0; i < goalPinsSequence.Length; i++)
            {
                int colorNumber = randomizer.Next(GProperties.NumberOfPinColors);
                eColors color = (eColors)colorNumber;
                if (i > 0)
                {
                    while (!IsUniquePinColor(goalPinsSequence, color, i))
                    {
                        colorNumber = randomizer.Next(GProperties.NumberOfPinColors);
                        color = (eColors)colorNumber;
                    }
                }

                goalPinsSequence[i] = new Pin(color);
            }

            return goalPinsSequence;
        }

        private bool IsUniquePinColor(Pin[] i_GoalPinSequence, eColors i_Color, int i_MaxIterator)
        {
            bool result = true;
            int iterator = 0;

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

        public Turn CompareUserGuess(Pin[] i_UserGuessedPins)
        {
            Turn.Result resultOfGuess = new Turn.Result();

            for (int j = 0; j < m_GoalSequence.Length; j++)
            {
                for (int i = 0; i < i_UserGuessedPins.Length; i++)
                {
                    if (m_GoalSequence[j].Color == i_UserGuessedPins[i].Color)
                    {
                        if (i == j)
                        {
                            resultOfGuess.CorrectInPlacePins++;
                        }
                        else
                        {
                            resultOfGuess.m_CorrectMisplacedPins++;
                        }
                    }
                }
            }

            return new Turn(i_UserGuessedPins, resultOfGuess);
        }
    }
}
