using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    //class to define DFSA that will  generate words from the root word ምርት
    public class meret
    {
        public DeterministicFSM constructDFSMForMeretStartingWithY()
        {
            //List of DFSM states for words from ምርት starting with ያ
            var QY = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16", "q17", "q18", "q19", "q20", "q21", "q22", "q23", "q24", "q25", "q26", "q27", "q28", "q29", "q30", "q31", "q32", "q33", "q34", "q35", "q36", "q37", "q38", "q39", "q40", "q41", "q42", "q43", "q44", "q45", "q46", "q47", "q48", "q49", "q50", "q51", "q52", "q53", "q54" };
            //List of input characters for words from ምርት starting with ያ
            var listOfInputsForY = new List<char> { 'ያ', 'ል', 'ተ', 'መ', 'ረ', 'ተ', 'በ', 'ት', 'ለ', 'ቸ', 'ላ', 'ው', 'ባ', 'ቱ', 'ክ', 'ሽ', 'ታ', 'ች', 'ስ', 'ሁ', 'ም', 'ር' };

            var transitionsStatrtingWithY = new List<Transition>
         {
             new Transition("q0",'ያ', "q1"),
             new Transition("q1",'ል', "q2"),
             new Transition("q2",'ተ', "q3"),
             new Transition("q3",'መ', "q4"),
             new Transition("q4",'ረ', "q5"),
             new Transition("q5",'ተ', "q6"),

             new Transition("q6",'ች', "q32"),
             new Transition("q32",'ባ', "q31"),

             new Transition("q6",'በ', "q29"),
             new Transition("q29",'ት', "q24"),
             new Transition("q6",'ለ', "q23"),
             new Transition("q23",'ት', "q24"),
             new Transition("q6",'ላ', "q25"),
             new Transition("q25",'ት', "q24"),
             new Transition("q25",'ቸ', "q27"),
             new Transition("q27",'ው', "q28"),
             new Transition("q6",'ባ', "q31"),
             new Transition("q31",'ት', "q34"),
             new Transition("q31",'ቸ', "q33"),
             new Transition("q33",'ው', "q34"),

             new Transition("q1",'ም', "q50"),
             new Transition("q1",'ላ', "q7"),
             new Transition("q50",'ር', "q51"),
             new Transition("q51",'ት', "q52"),
             new Transition("q51",'ቱ', "q52"),
             new Transition("q52",'በ', "q53"),
             new Transition("q53",'ት', "q54"),
             
             new Transition("q7",'መ', "q8"),
             new Transition("q8",'ረ', "q9"),
             new Transition("q9",'ቱ', "q10"),
             new Transition("q10",'በ', "q35"),
             new Transition("q35",'ት', "q36"),
             new Transition("q10",'ባ', "q37"),
             new Transition("q9",'ታ', "q11"),
             new Transition("q11",'ች', "q12"),
             new Transition("q12",'ሁ', "q13"),
             
             new Transition("q7",'ስ', "q14"),
             new Transition("q14",'መ', "q15"),
             new Transition("q15",'ረ', "q16"),
             new Transition("q16",'ት', "q17"),
             new Transition("q17",'ክ', "q18"),
             new Transition("q17",'ሽ', "q18"),             

             new Transition("q7",'ላ', "q10"),
             new Transition("q10",'ቸ', "q11"),
             new Transition("q11",'ው', "q12"),
             new Transition("q11",'ዋ', "q28"),
             new Transition("q28",'ለ', "q29"),
             new Transition("q29",'ች', "q30"),
             new Transition("q10",'ታ', "q31"),
             //new Transition("q31",'ለ', "q32"),
             //new Transition("q32",'ች', "q33"),

             new Transition("q37",'ቸ', "q39"),
             new Transition("q37",'ት', "q40"),
             new Transition("q39",'ው', "q40"),

             new Transition("q16",'ቱ', "q41"),
             new Transition("q41",'ባ', "q42"),
             new Transition("q42",'ቸ', "q43"),
             new Transition("q43",'ው', "q44"),
             
             new Transition("q16",'ታ', "q20"),
             new Transition("q20",'ች', "q21"),
             new Transition("q21",'ሁ', "q22"),
             new Transition("q16",'ተ', "q45"),
             new Transition("q45",'ች', "q46"),
             
             new Transition("q46",'ባ', "q47"),
             new Transition("q46",'በ', "q50"),
             new Transition("q50",'ት', "q49"),
             new Transition("q47",'ቸ', "q48"),
             new Transition("q48",'ው', "q49"),
         };

            //initial state for DFSM words starting with ያ
            var Q0Y = "q0";
            //List of final states for DFSM starting with ያ
            var FY = new List<string> { "q54", "q6", "q10", "q24", "q28", "q34", "q36", "q13", "q18", "q22", "q40", "q49", "q44" };
            return new DeterministicFSM(QY, listOfInputsForY, transitionsStatrtingWithY, Q0Y, FY);
        }
    }
}
