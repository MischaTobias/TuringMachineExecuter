using System;
using System.Collections.Generic;

namespace TuringMachineExecuter.Structures
{
    public class TuringMachine
    {
        private List<Node> States;
        private Node CurrentNode;
        private ReadingHead Head;
        private List<char> Alphabet;
        private string InitialState;
        private int NoOfStates;
        private bool Usable;

        public TuringMachine(){}
        public TuringMachine(int statesQty, string initialState, string alphabet)
        {
            States = new List<Node>();
            NoOfStates = statesQty;
            InitialState = initialState;
            GenerateAlphabet(alphabet);
            Usable = true;
        }

        public void SetUse(bool value) { Usable = value; }
        public bool IsUsable() { return Usable; }
        public bool StatesValidness() { return States.Count == NoOfStates; }
        public string GetInitialState() { return InitialState; }
        public Node GetInitialNode() { return States.Find(x => x.GetState() == InitialState); }
        public bool CharacterInAlphabet(char character) { return Alphabet.Contains(character); }
        public void SetCurrentNode(Node node) { CurrentNode = node; }
        public List<Node> GetStates() { return States; }
        public List<char> GetAlphabet() { return Alphabet; }
        public Node GetCurrentNode() { return CurrentNode; }

        private void GenerateAlphabet(string alphabet)
        {
            Alphabet = new List<char>(alphabet.ToCharArray());
            if (!Alphabet.Contains('_'))
            {
                Alphabet.Add('_');
            }
        }

        public string AddTransition(string transition)
        {
            //Validar Transiciones cuando leemos el mismo caracter NO SE PUEDE
            var transitionParts = transition.Split(',');
            //Validar Caracteres que esten en el alfabeto 
            if (!Alphabet.Contains(Convert.ToChar(transitionParts[1])))
                return "Transicion con caracter que no esta en el alfabeto";
            if (!Alphabet.Contains(Convert.ToChar(transitionParts[3])))
                return "Transicion con caracter que no esta en el alfabeto";
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
            States.Add(new Node(state, new List<Transition>()));
        }

        private bool PendingState(string stateName)
        {
            foreach (var state in States)
            {
                if (state.GetState() == stateName)
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
                if (States[i].GetState() == newTransition.CurrentState)
                {
                    if (!States[i].GetTransitions().Contains(newTransition))
                    {
                        States[i].AddTransition(newTransition);
                        return;
                    }
                }
            }
        }

        public bool CheckInitialState()
        {
            foreach (var state in States)
            {
                if (state.GetState() == InitialState)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
