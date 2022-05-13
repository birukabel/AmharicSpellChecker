using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    public class Transition
    {
        //Defines the start state fo the current transition on progress not for the DFSM
        public string StartState { get; private set; }
        //Defines the current symbol on the transition
        public char Symbol { get; private set; }
        //Defines the final state for the current transition
        public string EndState { get; private set; }

        //constractor that initializes members of class Transitions
        public Transition(string startState, char symbol, string endState)
        {
            StartState = startState;
            Symbol = symbol;
            EndState = endState;
        }
    }
}
