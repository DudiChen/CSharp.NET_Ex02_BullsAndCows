
namespace GameBoardDataManager
{

    public class GameBoardData
    {
        public const int k_MinimumNumberOfTries = 4;
        public const int k_MaximumNumberOfTries = 10;
        public const int k_NumberOfPinsToGuess = 4;
        public Turn[] m_Turns = new Turn[k_MaximumNumberOfTries];
        private string m_GoalSequence;
        public string GoalSequence
        {
            get
            {
                return m_GoalSequence;
            }
            set
            {
                m_GoalSequence = value;
            }
        }


    }
}
