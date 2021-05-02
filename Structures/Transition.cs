namespace TuringMachineExecuter.Structures
{
    public class Transition
    {
        public string CurrentState;
        public string NextState;
        public string ReadingCharacter;
        public string WritingCharacter;
        public string HeadMovement;

        public Transition() { }

        public string PrintTransition()
        {
            return $"{CurrentState}, {ReadingCharacter}, {NextState}, {WritingCharacter}, {HeadMovement}";
        }
    }
}
