using System.Collections.Generic;

namespace TuringMachineExecuter.Structures
{
    class Node
    {
        string State;
        List<Transition> Transitions;
        bool FinalState;
    }
}
