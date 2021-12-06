namespace AdventOfCode._2021.Day06
{
    public class Lanternfish
    {
        public int Timer { get; private set; }

        public const int RESET_TIMER_TO = 6; 
        public const int INIT_TIMER_NEW_SPAWN = 8; 
        
        public Lanternfish(int initialTimerState)
        {
            Timer = initialTimerState;
        }

        public Lanternfish Tick()
        {
            if (Timer > 0)
            {
                Timer--;
                return null;
            }

            Timer = RESET_TIMER_TO;
            return new Lanternfish(INIT_TIMER_NEW_SPAWN);
        }
    }
}