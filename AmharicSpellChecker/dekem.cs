using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    //class to define DFSA that will  generate words from the root word ድክም
    public class dekem
    {
        public DeterministicFSM constructDFSMForDekemfStartingWithD()
        {
            //List of DFSM states for words from ድክም starting with ደ
            var QD = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16", "q17" };
            //List of input characters for words from ድግፍ starting with ደ
            var listOfInputsForD = new List<char> { 'ድ', 'ካ', 'ሙ', 'ም', 'ዋ', 'ማ', 'ቸ', 'ው', 'ደ', 'ከ', 'መ', 'ች', 'ን', 'ት' };


            var transitionsStatrtingWithD = new List<Transition>
         {
             new Transition("q0",'ድ', "q1"),
             new Transition("q1",'ካ', "q2"),
             new Transition("q2",'ሙ', "q3"),

             new Transition("q2",'ም', "q4"),
             new Transition("q2",'ማ', "q5"),
             new Transition("q3",'ዋ', "q4"),
             new Transition("q5",'ቸ', "q6"),
             new Transition("q6",'ው', "q4"),

             new Transition("q0",'ደ', "q7"),
             new Transition("q7",'ከ', "q8"),
             new Transition("q8",'ማ', "q5"),
             new Transition("q7",'ካ', "q9"),
             new Transition("q9",'ማ', "q10"),

             new Transition("q8",'መ', "q11"),
             new Transition("q11",'ች', "q10"),
             new Transition("q9",'ከ', "q12"),
             new Transition("q12",'መ', "q13"),
             new Transition("q13",'ው', "q14"),
             new Transition("q13",'ን', "q14"),

             new Transition("q12",'ማ', "q15"),
             new Transition("q15",'ት', "q16"),
             new Transition("q15",'ቸ', "q17"),
             new Transition("q17",'ው', "q16"),
          };

            //initial state for DFSM words starting with ደ
            var Q0D = "q0";
            //List of final states for DFSM starting with ደ
            var FD = new List<string> { "q3", "q4", "q10", "q11", "q13", "q14", "q16" };
            return new DeterministicFSM(QD, listOfInputsForD, transitionsStatrtingWithD, Q0D, FD);
        }
    }
}
