using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    //class to define DFSA that will  generate words from the root word ዝግእ
    public class zege
    {
        public DeterministicFSM constructDFSMForZegeStartingWithY()
        {
            //List of DFSM states for words from ዝግእ starting with የ
            var Qy = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16", "q17", "q18", "q19", "q20", "q21", "q22", "q23", "q24", "q24", "q25", "q26", "q27", "q28", "q29", "q30" };
            //List of input characters for words from ድግፍ starting with ደ
            var listOfInputsForY = new List<char> { 'የ', 'ተ', 'ዘ', 'ጋ', 'ያ', 'ል', 'ማ', 'ን', 'ው', 'ና', 'ይ', 'ጉ', 'ት' };


            var transitionsStatrtingWithY = new List<Transition>
         {
             new Transition("q0",'የ', "q1"),
             new Transition("q1",'ተ', "q2"),
             new Transition("q2",'ዘ', "q3"),
             new Transition("q3",'ጋ', "q4"),
             new Transition("q4",'ጋ', "q5"),
             new Transition("q10",'ጋ', "q5"),

             new Transition("q0",'ያ', "q6"),
             new Transition("q6",'ል', "q7"),
             new Transition("q7",'ተ', "q8"),
             new Transition("q8",'ዘ', "q9"),
             new Transition("q9",'ጋ', "q10"),

             new Transition("q1",'ማ', "q11"),
             new Transition("q11",'ን', "q12"),
             new Transition("q12",'ዘ', "q13"),
             new Transition("q13",'ጋ', "q14"),

             new Transition("q14",'ው', "q16"),
             new Transition("q14",'ጋ', "q15"),
             new Transition("q15",'ት', "q16"),
             new Transition("q15",'ው', "q16"),

             new Transition("q11",'ና', "q17"),
             new Transition("q17",'ዘ', "q18"),
             new Transition("q18",'ጋ', "q19"),
             new Transition("q19",'ት', "q20"),

             new Transition("q11",'ይ', "q21"),
             new Transition("q11",'ት', "q25"),

             new Transition("q21",'ዘ', "q22"),
             new Transition("q22",'ጋ', "q23"),
             new Transition("q23",'ው', "q24"),
             new Transition("q22",'ጉ', "q29"),
             new Transition("q29",'ት', "q30"),

             new Transition("q25",'ዘ', "q26"),
             new Transition("q26",'ጋ', "q27"),
             new Transition("q27",'ው', "q28"),
          };


            //initial state for DFSM words starting with ደ
            var Q0Y = "q0";
            //List of final states for DFSM starting with ደ
            var FY = new List<string> { "q4", "q5", "q10", "q14", "q15", "q16", "q20", "q24", "q30", "q28" };
            return new DeterministicFSM(Qy, listOfInputsForY, transitionsStatrtingWithY, Q0Y, FY);

        }
    }
}
