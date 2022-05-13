using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    //class to define DFSA that will  generate words from the root word ውስድ
    public class wesed
    {
        public DeterministicFSM constructDFSMForWesedStartingWithS()
        {
            //List of DFSM states for words from ድግፍ starting with ሰ
            var QS = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16", "q17", "q18", "q19", "q20", "q21", "q22", "q23", "q24", "q25", "q26" };
            //List of input characters for words from ድግፍ starting with ሰ
            var listOfInputsForS = new List<char> { 'ስ', 'ላ', 'ል', 'ወ', 'ሰ', 'ደ', 'ች', 'ለ', 'ት', 'ል', 'ቸ', 'ው', 'ኝ', 'ን' };

            var transitionsStatrtingWithS = new List<Transition>
         {
             new Transition("q0",'ስ', "q1"),
             new Transition("q1",'ላ', "q2"),
             new Transition("q2",'ል', "q3"),
             new Transition("q3",'ወ', "q4"),
             new Transition("q4",'ሰ', "q5"),
             new Transition("q5",'ደ', "q6"),

             new Transition("q6",'ላ', "q24"),
             new Transition("q6",'ች', "q7"),
             new Transition("q6",'ለ', "q21"),
             new Transition("q6",'ል', "q20"),
             

             new Transition("q24",'ቸ', "q25"),
             new Transition("q25",'ው', "q26"),
             new Transition("q24",'ት', "q26"),

             new Transition("q25",'ት', "q22"),
             new Transition("q20",'ን', "q22"),
             new Transition("q20",'ኝ', "q22"),
             new Transition("q21",'ት', "q22"),

             new Transition("q7",'ለ', "q8"),
             new Transition("q8",'ት', "q9"),
             new Transition("q7",'ላ', "q10"),
             new Transition("q7",'ቸ', "q8"),
             new Transition("q8",'ው', "q9"),
             new Transition("q7",'ት', "q10"),

             new Transition("q10",'ቸ', "q11"),
             new Transition("q10",'ት', "q12"),
             new Transition("q11",'ው', "q12"),

             new Transition("q7",'ል', "q13"),
             new Transition("q13",'ን', "q23"),
             new Transition("q13",'ኝ', "q23"),

             new Transition("q1",'ለ', "q17"),
             new Transition("q14",'ወ', "q15"),
             new Transition("q15",'ሰ', "q16"),
             new Transition("q16",'ደ', "q17"),
             new Transition("q17",'ላ', "q18"),
             new Transition("q18",'ት', "q19"),
          };

            //initial state for DFSM words starting with ሰ
            var Q0S = "q0";
            //List of final states for DFSM starting with ሰ
            var FS = new List<string> { "q26", "q12", "q9", "q22", "q19", "q23" };
            return new DeterministicFSM(QS, listOfInputsForS, transitionsStatrtingWithS, Q0S, FS);
        }

        public DeterministicFSM constructDFSMForWesedStartingWithW()
        {
            //List of DFSM states for words from ድግፍ starting with ወ
            var QW = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16", "q17", "q18", "q19", "q20", "q21", "q22", "q23", "q24", "q25", "q27", "q26", "q28", "q29", "q30", "q31", "q32", "q33", "q34", "q35", "q36", "q37", "q38", "q39", "q40", "q41", "q42", "q43", "q44", "q45", "q46", "q47", "q48", "q49", "q50", "q51", "q52", "q53", "q54", "q55", "q56", "q57", "q58", "q59" };
            //List of input characters for words from ድግፍ starting with ወ
            var listOfInputsForW = new List<char> { 'ወ', 'ሰ', 'ደ', 'ው', 'ች', 'ል', 'ኝ', 'ለ', 'ት', 'ቸ', 'ላ', 'ስ', 'ዳ', 'ዶ', 'ድ', 'ታ', 'ኛ', 'ዋ', 'ክ', 'ድ', 'ን', 'ሻ', 'ሀ', 'ሽ' };


            var transitionsStatrtingWithW = new List<Transition>
         {
             new Transition("q0",'ወ', "q1"),
             new Transition("q1",'ሰ', "q2"),
             new Transition("q2",'ደ', "q3"),
             new Transition("q3",'ል', "q4"),
             new Transition("q3",'ው', "q5"),
             new Transition("q3",'ች', "q23"),
             new Transition("q3",'ላ', "q26"),
             new Transition("q3",'ለ', "q26"),
             new Transition("q3",'ች', "q50"),
             new Transition("q4",'ኝ', "q5"),

             new Transition("q23",'ላ', "q27"),
             new Transition("q27",'ቸ', "q55"),
             new Transition("q55",'ው', "q25"),

             new Transition("q23",'ል', "q24"),
             new Transition("q24",'ኝ', "q25"),
             new Transition("q24",'ን', "q25"),
             new Transition("q23",'ለ', "q26"),
             new Transition("q26",'ት', "q25"),
             new Transition("q26",'ቸ', "q45"),
             new Transition("q45",'ው', "q46"),

             new Transition("q1",'ስ', "q6"),
             new Transition("q2",'ድ', "q38"),
             new Transition("q6",'ዳ', "q7"),
             new Transition("q6",'ዶ', "q13"),
             new Transition("q6",'ደ', "q53"),
             new Transition("q7",'ለ', "q8"),
             new Transition("q8",'ት', "q9"),

             new Transition("q7",'ላ', "q10"),
             new Transition("q10",'ቸ', "q11"),
             new Transition("q11",'ው', "q12"),
             new Transition("q11",'ዋ', "q28"),
             new Transition("q28",'ለ', "q29"),
             new Transition("q29",'ች', "q30"),
             new Transition("q10",'ታ', "q31"),
             new Transition("q31",'ለ', "q32"),
             new Transition("q32",'ች', "q33"),

             new Transition("q13",'ላ', "q14"),
             new Transition("q14",'ታ', "q15"),
             new Transition("q15",'ል', "q16"),
             new Transition("q13",'ል', "q17"),
             new Transition("q17",'ኛ', "q18"),
             new Transition("q18",'ል', "q19"),
             new Transition("q14",'ቸ', "q20"),
             new Transition("q20",'ዋ', "q21"),
             new Transition("q21",'ል', "q22"),

             new Transition("q53",'ን', "q54"),
             new Transition("q53",'ው', "q54"),
             new Transition("q53",'ሻ', "q58"),
             new Transition("q53",'ሀ', "q56"),
             new Transition("q58",'ል', "q59"),
             new Transition("q56",'ል', "q57"),
             new Transition("q50",'ል', "q51"),
             new Transition("q51",'ል', "q52"),

             new Transition("q7",'ል', "q34"),
             new Transition("q34",'ኛ', "q35"),
             new Transition("q35",'ለ', "q36"),
             new Transition("q36",'ች', "q37"),

             new Transition("q38",'ሽ', "q47"),
             new Transition("q38",'ክ', "q39"),
             new Transition("q47",'ላ', "q48"),
             new Transition("q47",'ለ', "q43"),
             new Transition("q39",'ለ', "q43"),
             new Transition("q39",'ላ', "q40"),
             new Transition("q43",'ት', "q44"),
             new Transition("q40",'ት', "q44"),
             new Transition("q40",'ቸ', "q41"),
             new Transition("q48",'ቸ', "q41"),
             new Transition("q41",'ው', "q42"),
             new Transition("q48",'ት', "q49"),
         };

            //initial state for DFSM words starting with ወ
            var Q0W = "q0";
            //List of final states for DFSM starting with ወ
            var FW = new List<string> { "q3", "q5", "q7", "q9", "q25", "q46", "q30", "q33", "q12", "q16", "q19", "q22", "q13", "q54", "q59", "q57", "q52", "q37", "q49", "q42", "q44", "q47", "q39" };
            return new DeterministicFSM(QW, listOfInputsForW, transitionsStatrtingWithW, Q0W, FW);

        }
    }
}
