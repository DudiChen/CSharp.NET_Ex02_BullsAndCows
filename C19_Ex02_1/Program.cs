using System;
using System.Collections.Generic;
using BullsAndCows;


namespace BullsAndCows
{
    public class Program
    {

        public static void Main()
        {
            bool playGame = true;
            while (playGame)
            {
                BullsAndCows.Runner.Run();
                playGame = UI.UIManager.PromptNewGameQuery();
            }
        }
    }
}
