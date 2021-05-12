using System.Collections.Generic;

namespace TuringMachineExecuter.Structures
{
    public class Tape
    {
        public int CurrentPosition;
        public List<string> WordTape;
        public int Repetitions0;
        public int RepetitionsD;

        public Tape()
        {
            WordTape = new List<string>();
        }
    }
}
