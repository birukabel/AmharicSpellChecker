using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    //class to define DFSA that will  generate words from the root word ድግፍ
    public class degef
    {
        public DeterministicFSM constructDFSMForDegefStartingWithB()
        {

            //List of DFSM states for words from ድግፍ starting with በ
            var QB = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9" };

            //List of input characters for words from ድግፍ starting with በ
            var listOfInputsForB = new List<char> { 'በ', 'ደ', 'ጋ', 'ፊ', 'ው', 'ዋ', 'ዎ', 'ች', 'ያ', 'ን', 'ቸ' };

            var transitionsStatrtingWithB = new List<Transition>
         {
             new Transition("q0",'በ', "q1"),
             new Transition("q1",'ደ', "q2"),
             new Transition("q2",'ጋ', "q3"),
             new Transition("q3",'ፊ', "q4"), 
 
             new Transition("q4",'ዋ', "q6"),
             new Transition("q4",'ው', "q6"),  
             new Transition("q4",'ዎ', "q5"),  
             new Transition("q4",'ያ', "q7"),  
           
             new Transition("q5",'ች', "q6"),
             new Transition("q7",'ች', "q8"),
             new Transition("q8",'ን', "q6"),
             new Transition("q9",'ው', "q6"),
             new Transition("q7",'ቸ', "q9"),
            
         };

            //initial state for DFSM words starting with በ
            var Q0B = "q0";
            //List of final states for DFSM starting with በ
            var FB = new List<string> { "q6" };
            return new DeterministicFSM(QB, listOfInputsForB, transitionsStatrtingWithB, Q0B, FB);
        }

        public DeterministicFSM ConstructDFSAForWordsStartingWithD()
        {
            //List of DFSM states for words from ድግፍ starting with ደ
            var QD = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12" };
            //List of input characters for words from ድግፍ starting with ደ
            var listOfInputsForD = new List<char> { 'ድ', 'ፍ', 'ደ', 'ጋ', 'ግ', 'ፈ', 'ኝ', 'ገ', 'ን', 'ች', 'ው', 'ፉ' };

            var transitionsStatrtingWithD = new List<Transition>
         {
             new Transition("q0",'ድ', "q1"),
             new Transition("q1",'ጋ', "q2"),
             new Transition("q2",'ፍ', "q3"),

             new Transition("q0",'ደ', "q4"),
             new Transition("q4",'ግ', "q5"),
             new Transition("q5",'ፈ', "q6"),
             new Transition("q6",'ኝ', "q7"),
             new Transition("q5",'ፍ', "q7"),

             new Transition("q4",'ገ', "q8"),
             new Transition("q8",'ፈ', "q9"),
             new Transition("q8",'ፉ', "q12"),
             new Transition("q12",'ኝ', "q11"),
             new Transition("q9",'ች', "q10"),
             new Transition("q10",'ኝ', "q11"),
             new Transition("q10",'ው', "q11"),
             new Transition("q9",'ን', "q11"),
             new Transition("q9",'ኝ', "q11"),
          };

            //initial state for DFSM words starting with ደ
            var Q0D = "q0";
            //List of final states for DFSM starting with ደ
            var FD = new List<string> { "q3", "q7", "q9", "q11" };
            return new DeterministicFSM(QD, listOfInputsForD, transitionsStatrtingWithD, Q0D, FD);
        }
    }
}
