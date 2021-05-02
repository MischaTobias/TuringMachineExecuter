using System.Collections.Generic;

namespace TuringMachineExecuter.Structures
{
    public class TuringMachine
    {
        public List<Node> States;
        public Node StartNode;
        public Node CurrentNode;
        public ReadingHead Head;
        public List<char> Alphabet;
        public string InitialState;
        public int NoOfStates;
        public bool Usable;

        public TuringMachine(){}
        public TuringMachine(int statesQty, string initialState, string alphabet)
        {
            States = new List<Node>();
            NoOfStates = statesQty;
            InitialState = initialState;
            Alphabet = new List<char>(alphabet.ToCharArray());
            Usable = true;
        }

        public string AddTransition(string transition)
        {
            var transitionParts = transition.Split(',');
            if (transitionParts.Length != 5)
            {
                return "Formato incorrecto";
            }
            if (PendingState(transitionParts[0]))
            {
                CreateState(transitionParts[0]);
            }
            if (PendingState(transitionParts[2]))
            {
                CreateState(transitionParts[2]);
            }
            AddTransition(transitionParts);
            if (States.Count > NoOfStates)
            {
                return "Entrada inválida, tiene más estados de los indicados";
            }
            return "Transición creada correctamente";
        }

        private void CreateState(string state)
        {
            States.Add(new Node() { State = state, Transitions = new List<Transition>() });
        }

        private bool PendingState(string stateName)
        {
            foreach (var state in States)
            {
                if (state.State == stateName)
                {
                    return false;
                }
            }
            return true;
        }

        private void AddTransition(string[] values)
        {
            var newTransition = new Transition()
            {
                CurrentState = values[0],
                ReadingCharacter = values[1],
                NextState = values[2],
                WritingCharacter = values[3],
                HeadMovement = values[4]
            };
            for (int i = 0; i < States.Count; i++)
            {
                if (States[i].State == newTransition.CurrentState)
                {
                    if (!States[i].Transitions.Contains(newTransition))
                    {
                        States[i].Transitions.Add(newTransition);
                        return;
                    }
                }
            }
        }

        public bool CheckInitialState()
        {
            foreach (var state in States)
            {
                if (state.State == InitialState)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
