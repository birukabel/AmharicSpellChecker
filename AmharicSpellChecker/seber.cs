using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    //class to define DFSA that will  generate words from the root word ስብር
    public class seber
    {
        public DeterministicFSM constructDFSMForSeberStartingWithS()
        {
            //List of DFSM states for words from ስብር starting with ሰ
            var QS = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16", "q17", "q18", "q19", "q20", "q21", "q22", "q23", "q24", "q25", "q26", "q27" };
            //List of input characters for words from ስብር starting with ሰ
            var listOfInputsForS = new List<char> { 'ሰ', 'በ', 'ረ', 'ች', 'ሩ', 'ር', 'ን', 'ሻ', 'ና', 'ቸ', 'ው', 'ብ', 'ራ', 'ባ', 'ሪ', 'ሁ', 'ሽ', 'ት', 'ስ' };

            var transitionsStatrtingWithS = new List<Transition>
         {
             new Transition("q0",'ሰ', "q1"),
             new Transition("q1",'በ', "q2"),
             new Transition("q2",'ረ', "q3"),
             new Transition("q3",'ች', "q6"),
             new Transition("q2",'ሩ', "q6"),

             new Transition("q2",'ር', "q4"),
             new Transition("q4",'ና', "q7"),
             new Transition("q7",'ቸ', "q8"),
             new Transition("q8",'ው', "q9"),            

             new Transition("q4",'ሻ', "q10"),
             new Transition("q4",'ን', "q5"),
             new Transition("q10",'ቸ', "q12"),
             new Transition("q10",'ት', "q11"),
             new Transition("q12",'ው', "q13"),
            
             new Transition("q2",'ራ', "q16"),
             new Transition("q4",'ሽ', "q14"),
             new Transition("q14",'ው', "q15"),
             new Transition("q16",'ች', "q17"),
             new Transition("q17",'ሁ', "q15"),

             new Transition("q1",'ብ', "q7"),
             new Transition("q7",'ራ', "q18"),

             new Transition("q0",'ስ', "q20"),
             new Transition("q20",'ባ', "q19"),
             new Transition("q19",'ሪ', "q18"),

             new Transition("q1",'ባ', "q21"),
             new Transition("q21",'ባ', "q22"),
             new Transition("q22",'ሪ', "q23"),
             new Transition("q24",'ሩ', "q23"),
             new Transition("q21",'በ', "q24"),

             new Transition("q24",'ር', "q25"),
             new Transition("q25",'ና', "q26"),
             new Transition("q26",'ቸ', "q27"),
             new Transition("q27",'ው', "q23"),
          };

            //initial state for DFSM words starting with ሰ
            var Q0S = "q0";
            //List of final states for DFSM starting with ሰ
            var FS = new List<string> { "q3", "q6", "q5", "q11", "q9", "q13", "q18", "q15", "q23" };
            return new DeterministicFSM(QS, listOfInputsForS, transitionsStatrtingWithS, Q0S, FS);
        }
        public DeterministicFSM constructDFSMForSeberStartingWithY()
        {
            //List of DFSM states for words from ስብር starting with ያ
            var QY = new List<string> { "q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14", "q15", "q16", "q17", "q18", "q19", "q20", "q21", "q22", "q23", "q24", "q25", "q26", "q27", "q28", "q29", "q30" };
            //List of input characters for words from ስብር starting with ያ
            var listOfInputsForY = new List<char> { 'ያ', 'ል', 'ተ', 'ይ', 'ሰ', 'ባ', 'በ', 'ረ', 'ች', 'ሩ', 'ህ', 'ር', 'ሽ', 'አ', 'ን', 'ብ', 'ሁ', 'ስ', 'ኝ' };

            var transitionsStatrtingWithY = new List<Transition>
         {
             new Transition("q0",'ያ', "q1"),
             new Transition("q1",'ል', "q2"),
             new Transition("q2",'ተ', "q3"),
             new Transition("q3",'ሰ', "q4"), 
             new Transition("q4",'ባ', "q5"),
             new Transition("q5",'በ', "q6"),
             new Transition("q6",'ረ', "q7"),
             new Transition("q7",'ች', "q8"),
             new Transition("q6",'ሩ', "q8"),
 
             new Transition("q2",'ሰ', "q14"),  
             new Transition("q14",'በ', "q12"),  
             new Transition("q12",'ረ', "q13"),            
             new Transition("q13",'ች', "q14"),
             new Transition("q12",'ሩ', "q14"),
             new Transition("q12",'ር', "q15"),
             new Transition("q15",'ን', "q14"),

             new Transition("q0",'ይ', "q9"),  
             new Transition("q9",'ስ', "q10"),  
             new Transition("q10",'በ', "q17"),            
             new Transition("q17",'ር', "q23"),
             new Transition("q23",'ሽ', "q24"),
             new Transition("q23",'ህ', "q24"),
            
             new Transition("q17",'ሩ', "q16"),
             new Transition("q16",'ሽ', "q15"),  
             new Transition("q16",'ህ', "q15"),            
             new Transition("q16",'አ', "q26"),
             new Transition("q26",'ች', "q27"),
             new Transition("q27",'ሁ', "q28"),

             new Transition("q17",'ረ', "q18"),
             new Transition("q18",'ን', "q19"),
             new Transition("q18",'ኝ', "q19"),
             new Transition("q9",'ሰ', "q20"),

             new Transition("q20",'ባ', "q21"),
             new Transition("q21",'ብ', "q22"),  
             new Transition("q22",'ሩ', "q29"),            
             new Transition("q29",'ኝ', "q30"),
             new Transition("q29",'ህ', "q30"),
             new Transition("q29",'ሽ', "q30"),
         };


            //initial state for DFSM words starting with ያ
            var Q0Y = "q0";
            //List of final states for DFSM starting with ያ
            var FY = new List<string> { "q7", "q8", "q13", "q14", "q19", "q15", "q24", "q30", "q28" };
            return new DeterministicFSM(QY, listOfInputsForY, transitionsStatrtingWithY, Q0Y, FY);
        }
    }
}
