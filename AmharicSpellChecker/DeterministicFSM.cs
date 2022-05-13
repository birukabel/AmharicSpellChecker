using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    public class DeterministicFSM
    {
        //Q defines the states of the machine
        private readonly List<string> Q = new List<string>();
        //testInput holds the word that needs to be tested
        private readonly List<char> testInput = new List<char>();
        //poosibleTransitions defines the list of transitions
        private readonly List<Transition> poosibleTransitions = new List<Transition>();
        //Q0 holds initial state
        private string Q0;
        //QF holds list of final states
        private readonly List<string> QF = new List<string>();

        //constructor to initialize DFSM components
        public DeterministicFSM(IEnumerable<string> qList, IEnumerable<char> tInput, IEnumerable<Transition> pTransitions, string q0, IEnumerable<string> qf)
        {
            Q = qList.ToList();
            testInput = tInput.ToList();
            AddTransitions(pTransitions);
            AddInitialState(q0);
            AddFinalStates(qf);
        }

        //adds a new transition to the previously existed list of transitions
        private void AddTransitions(IEnumerable<Transition> transitions)
        {
            foreach (var transition in transitions.Where(ValidTransition))
            {
                poosibleTransitions.Add(transition);
            }
        }

        //chekes if a transition is valied or not
        private bool ValidTransition(Transition transition)
        {
            return Q.Contains(transition.StartState) && Q.Contains(transition.EndState) && testInput.Contains(transition.Symbol) && !TransitionAlreadyDefined(transition);
        }

        //checks if a transition has been already defined or not
        private bool TransitionAlreadyDefined(Transition transition)
        {
            return poosibleTransitions.Any(t => t.StartState == transition.StartState && t.Symbol == transition.Symbol);
        }

        //add initial state to the DFSM
        private void AddInitialState(string q0)
        {
            if (q0 != null && Q.Contains(q0))
            {
                Q0 = q0;
            }
        }

        //adds final states to the DFSM
        private void AddFinalStates(IEnumerable<string> finalStates)
        {
            foreach (var finalState in finalStates.Where(finalState => Q.Contains(finalState)))
            {
                QF.Add(finalState);
            }
        }

        //Checks if the the input is valid or not and DFSA is valid or not
        private bool InvalidInputOrFSM(string input)
        {
            if (InputContainsNotDefinedSymbols(input))
            {
                return true;
            }
            if (InitialStateNotSet())//No initial state has been set
            {
                return true;
            }
            if (NoFinalStates())//No final states have been set
            {
                return true;
            }
            return false;
        }

        //Could not accept the input since the symbol " + symbol + " is not part of the alphabet"
        private bool InputContainsNotDefinedSymbols(string input)
        {
            foreach (var symbol in input.ToCharArray().Where(symbol => !testInput.Contains(symbol)))
            {
                return true;
            }
            return false;
        }

        //checks and returns a boolean value indicating there already exists any initial state or not
        private bool InitialStateNotSet()
        {
            return string.IsNullOrEmpty(Q0);
        }

        //checks and returns a boolean value indicating there already exists final states or not
        private bool NoFinalStates()
        {
            return QF.Count == 0;
        }

        public bool CheckIfStringIsAccepted(string input)
        {
            if (InvalidInputOrFSM(input))
            {
                return false;
            }
            var currentState = Q0;
            var steps = new StringBuilder();
            foreach (var symbol in input.ToCharArray())
            {
                var transition = poosibleTransitions.Find(t => t.StartState == currentState && t.Symbol == symbol);
                if (transition == null)
                {
                    return false;
                }
                currentState = transition.EndState;
                steps.Append(transition + "\n");
            }
            if (QF.Contains(currentState))
            {
                return true;
            }
            return false;
        }
    }
}
