using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmharicSpellChecker
{
    public class amharicTokens
    {
        string[] listOfTokensWesed = new string[] { "ልኝ", "ለት", "ላቸው", "ላታል", "ልኛል", "ላቸዋል", "ችልኝ", "ችለት", "ላቸዋለች", "ላታለች", "ልኛለች", "ክላቸው", "ክ", "ክለት", "ክላት", "ለት", "ላት", "ላቸው", "ሽ", "ሽለት", "ሽላት", "ችላቸው", "ችልን", "ው", "ን", "ሀል", "ሻል", "ስላል", "ችለት", "ችላቸው", "ችላት", "ችልን", "ችልኝ", "ልን" };
        string[] listOfTokensMeles = new string[] { "ች", "ላ", "ን", "ሺ", "ው", "አስ", "እያስ", "ችም", "እና", "እየተ", "እያ", "እያስ", "አቸው", "አት", "ናቸው", "ነው", "ም", "ትም", "ቸውም", "ንም", "አላስ", "ችውም", "ችም", "ቻትም", "ቻቸውም", "ችንም", "ነውም", "አላ", "ናትም", "ናቸውም", "ንም" };
        string[] listOfTokensDegef = new string[] { "በ", "ዎች", "ያችን", "ው", "ዋ", "ያቸው", "ኝ", "ችው", "ን"};
        string[] listOfTokensDekem = new string[] { "ዋ", "ቸው", "ች", "ካ", "ው", "ን", "ት"};
        string[] listOfTokensMeret = new string[] { "ያልተ", "ያላ", "ችሁ", "ያላስ", "ክ", "ያላስ", "ሽ", "ለት", "ላት", "ላቸው", "በት", "ባት", "ችባቸው", "ባቸው" };
        string[] listOfTokensSeber = new string[] { "ን", "ች", "ባ", "ችሁ", "ሻት", "ሽው", "ሻቸው", "ናቸው", "ያልተ", "ያል", "ህ", "ይ", "ሽ", "አችሁ", "ኝ"};
        string[] listOfTokensTegeb = new string[] { "ኛ", "ው", "ን", "ንበት", "ካል", "ች", "ችባቸው", "ችስ", "ንስ", "ስ", "ብንስ" };
        string[] listOfTokensZege = new string[] { "የተ", "ጋ", "ያልተ", "የማን", "የማና", "ት", "ጋት", "ጋው", "የማይ", "ው", "የማት", "ት" };

        public string RemovePrefix(string strInput)
        {
            if (strInput.StartsWith("ያልተ"))
            {
                return strInput.Remove(0, 3);
            }
            return "";
        }

        public string RemoveSuffix(string strInput)
        {
            if (strInput.EndsWith("ን"))
            {
                return strInput.Remove(strInput.Length-1, 1);
            }
            return "";
        }

        public string ReturnRootForm(string strInput)
        {
            strInput = RemovePrefix(strInput);
            strInput = RemoveSuffix(strInput);
            return strInput;
        }
    }
}
