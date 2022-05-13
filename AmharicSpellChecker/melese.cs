using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    //class to define DFSA that will  generate words from the root word ምልስ
    public class melese
    {
        public DeterministicFSM constructDFSMForMeleseStartingWithA()
        {
            //List of DFSM states for words from ምልስ starting with አ
            var QA = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13",
                "q14", "q15", "q16", "q17", "q18", "q19", "q20", "q21", "q22", "q23", "q24", "q25", "q26", "q27", "q28", "q29", 
                "q30", "q31", "q32", "q33", "q34", "q35", "q36", "q37", "q38", "q39", "q40", "q41", "q42", "q43", "q44", "q45", 
                "q46", "q47", "q48", "q49", "q50", "q51", "q52", "q53", "q54", "q55", "q56", "q57", "q58", "q59", "q60", "q61", 
                "q62", "q63", "q64", "q65", "q66", "q67", "q68", "q69", "q70", "q71", "q72", "q73", "q74", "q75", "q76", "q77", 
                "q78", "q79", "q80", "q81", "q82", "q83", "q84", "q85", "q86", "q87", "q88", "q89", "q90", "q91", "q92", "q93", 
                "q94", "q95", "q96", "q97", "q98", "q99", "q100", "q101", "q102", "q103", "q104", "q105", "q106", "q107", "q108",
                "q109", "q110", "q111", "q112" };
            //List of input characters for words from ምልስ starting with አ
            var listOfInputsForTA = new List<char> { 'መ', 'ላ', 'ለ', 'ሰ', 'ን', 'ች', 'ም', 'ው', 'ስ', 'ነ', 'ቻ', 'ና', 'ት', 'ቸ', 'አ', 'እ', 'ያ', 'ሱ', 'የ', 'መ', 'ሳ', 'ተ', 'ል' };

            var transitionsStatrtingWithTA = new List<Transition>
         {
             new Transition("q0",'አ', "q1"),
             new Transition("q1",'ስ', "q2"),
             new Transition("q2",'መ', "q3"),
             new Transition("q3",'ላ', "q4"),
             new Transition("q4",'ለ', "q5"),
             new Transition("q5",'ሱ', "q6"),
             new Transition("q1",'ላ', "q17"),
             new Transition("q1",'መ', "q26"),

             new Transition("q0",'እ', "q7"),
             new Transition("q7",'ያ', "q8"),
             new Transition("q8",'ስ', "q9"),
             new Transition("q9",'መ', "q10"),
             new Transition("q3",'ለ', "q12"),

             new Transition("q10",'ለ', "q11"),
             new Transition("q11",'ሰ', "q15"),
             new Transition("q11",'ስ', "q51"),
             new Transition("q51",'ና', "q52"),
             new Transition("q52",'ቸ', "q53"),
             new Transition("q53",'ው', "q54"),
             new Transition("q51",'ነ', "q55"),
             new Transition("q55",'ው', "q54"),
             new Transition("q15",'ች', "q16"),
             new Transition("q10",'ላ', "q24"),
             new Transition("q24",'ለ', "q25"),
             new Transition("q25",'ሱ', "q16"),

             new Transition("q11",'ሱ', "q45"),
             new Transition("q45",'ት', "q46"),
             new Transition("q45",'አ', "q47"),
             new Transition("q47",'ት', "q49"),
             new Transition("q47",'ቸ', "q48"),
             new Transition("q48",'ው', "q49"),

             new Transition("q12",'ሰ', "q13"),
             new Transition("q13",'ች', "q14"),
             new Transition("q12",'ሱ', "q14"),

             new Transition("q7",'ና', "q32"),
             new Transition("q7",'የ', "q36"),
             new Transition("q8",'መ', "q42"),
            
             new Transition("q17",'ስ', "q18"),
             new Transition("q18",'መ', "q19"),
             new Transition("q19",'ለ', "q20"),
             new Transition("q20",'ሰ', "q21"),
             new Transition("q20",'ሳ', "q58"),

             new Transition("q21",'ን', "q64"),
             new Transition("q21",'ች', "q22"),
             new Transition("q21",'ም', "q57"),
             new Transition("q21",'ቻ', "q68"),

             new Transition("q64",'ም', "q65"),
             new Transition("q22",'ን', "q75"),
             new Transition("q75",'ም', "q76"),
             new Transition("q22",'ም', "q23"),
             new Transition("q22",'ው', "q66"),
             new Transition("q66",'ም', "q67"),

             new Transition("q58",'ት', "q59"),
             new Transition("q58",'ቸ', "q61"),
             new Transition("q59",'ም', "q60"),
             new Transition("q61",'ው', "q62"),
             new Transition("q62",'ም', "q63"),

             new Transition("q68",'ት', "q70"),
             new Transition("q68",'ቸ', "q72"),
             new Transition("q72",'ው', "q73"),
             new Transition("q73",'ም', "q74"),
             new Transition("q70",'ም', "q71"),

             new Transition("q26",'ላ', "q27"),
             new Transition("q27",'ለ', "q28"),
             new Transition("q28",'ሱ', "q31"),
             new Transition("q28",'ሰ', "q30"),
             new Transition("q30",'ች', "q31"),

             new Transition("q32",'መ', "q33"),
             new Transition("q33",'ላ', "q34"),
             new Transition("q34",'ል', "q35"),
             new Transition("q35",'ስ', "q31"),

             new Transition("q36",'ተ', "q37"),
             new Transition("q37",'መ', "q38"),
             new Transition("q38",'ለ', "q39"),
             new Transition("q39",'ሱ', "q31"),

             new Transition("q38",'ላ', "q40"),
             new Transition("q42",'ላ', "q43"),
             new Transition("q40",'ለ', "q41"),
             new Transition("q43",'ለ', "q44"),
             new Transition("q41",'ሱ', "q31"),
             new Transition("q44",'ሱ', "q31"),

             new Transition("q1",'ላ', "q17"),
             new Transition("q17",'መ', "q77"),
             new Transition("q77",'ላ', "q78"),
             new Transition("q78",'ለ', "q79"),
             new Transition("q79",'ሰ', "q80"),
             new Transition("q80",'ን', "q111"),
             new Transition("q111",'ም', "q112"),
             new Transition("q80",'ች', "q81"),
             new Transition("q81",'ን', "q87"),
             new Transition("q81",'ው', "q82"),
             new Transition("q87",'ም', "q83"),
             new Transition("q82",'ም', "q83"),

             new Transition("q80",'ቻ', "q84"),
             new Transition("q84",'ት', "q85"),
             new Transition("q85",'ም', "q83"),
             new Transition("q84",'ቸ', "q89"),
             new Transition("q89",'ው', "q90"),
             new Transition("q90",'ም', "q83"),

             new Transition("q79",'ስ', "q101"),
             new Transition("q101",'ነ', "q102"),
             new Transition("q102",'ው', "q103"),
             new Transition("q103",'ም', "q104"),
             new Transition("q101",'ና', "q105"),
             new Transition("q105",'ት', "q106"),
             new Transition("q106",'ም', "q104"),
             new Transition("q108",'ው', "q109"),
             new Transition("q109",'ም', "q104"),
             new Transition("q105",'ቸ', "q108"),
          };

            //initial state for DFSM words starting with አ
            var Q0A = "q0";
            //List of final states for DFSM starting with አ
            var FA = new List<string> { "q112", "q83", "q104", "q6", "q54", "q15", "q16", "q513", "q14", "q13", "q65", "q45", "q46", "q23", "q57", "q67", "q30", "q31", "q60", "q63", "q71", "q74", "q49", "q76" };
            return new DeterministicFSM(QA, listOfInputsForTA, transitionsStatrtingWithTA, Q0A, FA);
        }

        public DeterministicFSM constructDFSMForMeleseStartingWithTandM()
        {
            //List of DFSM states for words from ምልስ starting with ተ and መ
            var QTM = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13" };
            //List of input characters for words from ምልስ starting with ተ and መ
            var listOfInputsForTM = new List<char> { 'ተ', 'መ', 'ላ', 'ለ', 'ሱ', 'ሰ', 'ች', 'ስ', 'ን', 'ል', 'ሺ', 'ሶ', 'ሰ', 'ው', 'ሳ' };

            var transitionsStatrtingWithTM = new List<Transition>
         {
             new Transition("q0",'ተ', "q1"),
             new Transition("q1",'መ', "q3"),
             new Transition("q3",'ላ', "q4"),
             new Transition("q4",'ለ', "q5"),
             new Transition("q5",'ሱ', "q6"),

             new Transition("q0",'መ', "q2"),
             new Transition("q2",'ላ', "q10"),
             new Transition("q10",'ል', "q12"),
             new Transition("q10",'ለ', "q7"),
             new Transition("q2",'ል', "q12"),
             new Transition("q2",'ለ', "q7"),

             new Transition("q7",'ሰ', "q8"),
             new Transition("q8",'ች', "q9"),
             new Transition("q7",'ሱ', "q9"),
             new Transition("q7",'ስ', "q11"),
             new Transition("q11",'ን', "q9"),
             
             new Transition("q12",'ስ', "q9"),
             new Transition("q12",'ሺ', "q9"),
             new Transition("q12",'ሱ', "q9"),
             new Transition("q12",'ሶ', "q9"),
             new Transition("q12",'ሳ', "q9"),
             new Transition("q12",'ሰ', "q13"),
             new Transition("q13",'ው', "q9"),
          };

            //initial state for DFSM words starting with ተ and መ
            var Q0TM = "q0";
            //List of final states for DFSM starting with ተ and መ
            var FTM = new List<string> { "q6", "q8", "q9" };
            return new DeterministicFSM(QTM, listOfInputsForTM, transitionsStatrtingWithTM, Q0TM, FTM);
        }
    }
}
