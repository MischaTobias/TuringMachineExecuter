using System;
using System.Collections.Generic;

namespace TuringMachineExecuter.Structures
{
    public class Node
    {
        private string State;
        private List<Transition> Transitions;

        public Node(){}
        public Node(string state, List<Transition> transitions)
        {
            State = state;
            Transitions = transitions;
        }

        public string GetState() { return State; }
        public List<Transition> GetTransitions() { return Transitions; }
        public void AddTransition(Transition transition) { Transitions.Add(transition); }
    }
}
