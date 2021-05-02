using System;
using System.Collections.Generic;

namespace TuringMachineExecuter.Structures
{
    public class Node : IComparable
    {
        public string State;
        public List<Transition> Transitions;

        public Node(){}
        public Node(string state)
        {
            State = state;
        }

        public int CompareTo(object obj)
        {
            return State.CompareTo(((Node)obj).State);
        }
    }
}
