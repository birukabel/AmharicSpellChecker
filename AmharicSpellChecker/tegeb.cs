using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    //class to define DFSA that will  generate words from the root word ጥግብ
    public class tegeb
    {
        public DeterministicFSM constructDFSMForTegebStartingWithK()
        {
            //List of DFSM states for words from ጥግብ starting with ከ
            var Qk = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16" };
            //List of input characters for words from ጥግብ starting with ከ
            var listOfInputsFork = new List<char> { 'ካ', 'ል', 'ጠ', 'ገ', 'ብ', 'በ', 'ቡ', 'ን', 'ች', 'ን', 'ው', 'ቸ', 'ስ', 'ባ' };

            var transitionsStatrtingWithK = new List<Transition>
         {
             new Transition("q0",'ካ', "q1"),
             new Transition("q1",'ል', "q2"),
             new Transition("q2",'ጠ', "q3"),
             new Transition("q3",'ገ', "q4"),             
             new Transition("q4",'ብ', "q11"),
             new Transition("q4",'በ', "q5"),
             new Transition("q4",'ቡ', "q10"),
             new Transition("q11",'ን', "q12"),
             new Transition("q12",'ስ', "q13"),
             new Transition("q5",'ች', "q6"),
             new Transition("q6",'ስ', "q13"),
             new Transition("q6",'ባ', "q7"),
             new Transition("q7",'ቸ', "q8"),
             new Transition("q8",'ው', "q9"),
             new Transition("q5",'ስ', "q14"),
             new Transition("q10",'ስ', "q14"),
             new Transition("q6",'ብ', "q15"),
             new Transition("q15",'ን', "q16"),
             new Transition("q16",'ስ', "q9"),
         };

            //initial state for DFSM words starting with ከ
            var Q0K = "q0";
            //List of final states for DFSM starting with ከ
            var FK = new List<string> { "q12", "q13", "q5", "q6", "q9", "q14", "q10" };
            return new DeterministicFSM(Qk, listOfInputsFork, transitionsStatrtingWithK, Q0K, FK);
        }

        public DeterministicFSM constructDFSMForTegebStartingWithT()
        {
            //List of DFSM states for words from ጥግብ starting with ጠ
            var QT = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16" };
            //List of input characters for words from ጥግብ starting with ጠ
            var listOfInputsForT = new List<char> { 'ጥ', 'ጋ', 'ብ', 'በ', 'ኛ', 'ን', 'ቦ', 'ባ', 'ገ', 'ጕ', 'ጠ', 'ግ', 'ት', 'ው' };

            var transitionsStatrtingWithT = new List<Transition>
         {
             new Transition("q0",'ጥ', "q1"),
             new Transition("q1",'ጋ', "q2"),
             new Transition("q2",'ብ', "q3"),
             new Transition("q2",'በ', "q4"),
             new Transition("q4",'ኛ', "q5"),

             new Transition("q0",'ጠ', "q6"),
             new Transition("q6",'ገ', "q7"), 
             new Transition("q6",'ግ', "q9"), 
             new Transition("q7",'በ', "q8"), 
             new Transition("q7",'ብ', "q13"), 
             new Transition("q13",'ን', "q14"), 
             new Transition("q14",'በ', "q15"),
             new Transition("q15",'ት', "q16"),
             new Transition("q9",'ቦ', "q10"),
             new Transition("q9",'ባ', "q10"),
             new Transition("q9",'በ', "q11"),
             new Transition("q11",'ው', "q12"),
             new Transition("q11",'ን', "q12"),
         };
            //initial state for DFSM words starting with ጠ
            var Q0T = "q0";
            //List of final states for DFSM starting with ጠ
            var FT = new List<string> { "q3", "q5", "q8", "q10", "q12", "q14", "q16" };
            return new DeterministicFSM(QT, listOfInputsForT, transitionsStatrtingWithT, Q0T, FT);
        }
    }
}
