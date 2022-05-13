using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//using AmharicKeyMapper;

namespace AmharicSpellChecker
{
    
    public partial class frmMainWindow : Form
    {
        #region memberVariables
        //readonly  AmharicKeyMapper.PowerGeezMapper _mapper;
        ContextMenuStrip contextMenuStrip;

        #endregion

        #region constructor
        public frmMainWindow()
        {
            InitializeComponent();
            //_mapper = new AmharicKeyMapper.PowerGeezMapper();

            //InitializeAmharicSupport(richTxtInput);
        }

        #endregion


        #region memberEvents

        private void richTextInput_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                //char charToBeDeleted = richTxtInput.Text[richTxtInput.SelectionStart - 1];

                string m_strRecentWord = string.Empty;
                if (richTxtInput.Text.Length > 0)
                {
                    //holds last index of space from user input
                    int m_intLastIndex = richTxtInput.Text.Substring(0, richTxtInput.SelectionStart - 1).LastIndexOf(" ");
                    int m_intLength = richTxtInput.SelectionStart - m_intLastIndex - 1;
                    m_strRecentWord = richTxtInput.Text.Substring(m_intLastIndex + 1, m_intLength);
                    //amharicTokens amhTokens = new amharicTokens();
                    //string strRootForm = amhTokens.ReturnRootForm(m_strRecentWord);
                    int recentWordStartIndex = m_intLastIndex + 1;
                    int recentWordEndIndex = m_intLastIndex + m_intLength;
                    if (m_strRecentWord.Contains("\n"))
                    {
                        m_strRecentWord = Regex.Replace(m_strRecentWord, @"\t|\n|\r", "");//Replace new line character
                    }
                    if (m_strRecentWord.Any(x => Char.IsWhiteSpace(x)))
                    {
                        m_strRecentWord = Regex.Replace(m_strRecentWord, @"\s", "");
                    }
                    if (!string.IsNullOrWhiteSpace(m_strRecentWord))//Checks if input string is not full of white spaces
                        DisplayDFSAvalidationResult(DetermineDFSM(m_strRecentWord, recentWordStartIndex), m_strRecentWord, recentWordStartIndex);
                    //DetermineDFSM(m_strRecentWord, recentWordStartIndex);
                }
                //if (m_strRecentWord == "biruk")
                //{
                //    UnderLineWronglySpeltWord("biruk", recentWordStartIndex);
                //}
            }
        }

        private void richTextInput_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip = new ContextMenuStrip();

                //get string from starting to clicked position
                Int32 m_intClickIndex = richTxtInput.GetCharIndexFromPosition(new Point(e.X, e.Y));

                //index of clicked char
                string m_strInitialString = richTxtInput.Text.Substring(0, m_intClickIndex);

                //initialise index upto total lengh in case we are clicking on last word
                Int32 m_intStartIndex = richTxtInput.Text.Length - 1;

                //if clicked word is not last word
                if ((richTxtInput.Text.IndexOf(" ", m_intClickIndex) != -1))
                {
                    m_intStartIndex = richTxtInput.Text.IndexOf(" ", m_intClickIndex);
                }

                //moving towords starting of string from clicked position
                Int32 m_intLastIndex = m_strInitialString.LastIndexOf(" ");
                
                //original clicked word
                //string m_strWord = richTxtInput.Text.Substring(m_intLastIndex + 1, m_intStartIndex - m_intLastIndex);
                string m_strWord = richTxtInput.Text.Substring(m_intLastIndex + 1, (m_intStartIndex - m_intLastIndex)-1);

                //The following code is added to get the last Index of the most recent word
                int m_intLastIndexOfRecentWord = richTxtInput.Text.Substring(0, richTxtInput.SelectionStart - 1).LastIndexOf(" ");
                int recentWordStartIndex = m_intLastIndexOfRecentWord + 1;
                
                //end of newly added code
                
                if (!string.IsNullOrWhiteSpace(m_strWord))
                {
                    bool _isValid = DetermineDFSM(m_strWord, recentWordStartIndex);
                    if (!_isValid)
                    {
                        List<string> m_listOfAlternateWords = new List<string>();
                        if (m_strWord != "")
                        {
                            //DetermineDFSM(m_strWord, m_intStartIndex);
                            m_listOfAlternateWords = GenerateSuggestion(m_strWord[0]);
                        }

                        //List<string> sSugg = GenerateSuggestion(m_strWord[0]);
                        if (m_listOfAlternateWords.Count > 0)
                        {
                            for (int m_word = 0; m_word < m_listOfAlternateWords.Count; m_word++)
                            {
                                ToolStripMenuItem Item = new ToolStripMenuItem();
                                Item.Name = m_listOfAlternateWords[m_word];
                                Item.Text = Item.Name;

                                Item.Tag = new Int32[] {
							m_intLastIndex,
							m_intStartIndex
                        };
                                Item.Click += new EventHandler(ToolStripMenuItem_Click);
                                contextMenuStrip.Items.Add(Item);
                            }
                        }
                        else
                        {
                            ToolStripMenuItem Item = new ToolStripMenuItem();
                            Item.Name = "NoAlternative";
                            Item.Text = "ተቀያሪ ቃል የለውም";

                            Item.Tag = new Int32[] {
							m_intLastIndex,
							m_intStartIndex
                        };
                            Item.Click += new EventHandler(ToolStripMenuItem_Click);
                            contextMenuStrip.Items.Add(Item);
                        }
                        contextMenuStrip.Show(MousePosition);
                    }
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem m_item = (ToolStripMenuItem)sender;
            Int32[] m_pointArray = (Int32[])m_item.Tag;

            string m_strFirstPart = string.Empty;

            if ((m_pointArray[0] > 0))
            {
                m_strFirstPart = richTxtInput.Text.Substring(0, m_pointArray[0]) + " ";
            }

            string m_strMiddlePart = richTxtInput.Text.Substring(m_pointArray[0] + 1, m_pointArray[1] - m_pointArray[0]);

            string m_strLastPart = richTxtInput.Text.Substring(m_pointArray[1] + 1);

            richTxtInput.SelectionStart = m_pointArray[0] + 1;

            richTxtInput.SelectionLength = m_strMiddlePart.Length;

            //Underline U = new Underline(this.richTxtInput);
            //U.SelectionUnderlineStyle = Underline.UnderlineStyle.None;
            //U.SelectionUnderlineColor = Underline.UnderlineColor..Red;
            //Font m_font = richTxtInput.SelectionFont;
            //richTxtInput.SelectionFont = new Font(richTxtInput.SelectionFont.FontFamily, richTxtInput.SelectionFont.Size, FontStyle.Regular);
            if (m_item.Text != "ተቀያሪ ቃል የለውም")
            {
                richTxtInput.SelectionFont = new Font("Nyala", 11f, FontStyle.Regular);
            }
            //richTxtInput.SelectionFont = new Font(richTxtInput.SelectionFont.FontFamily, m_font.Size, FontStyle.Regular);
            if (m_item.Text != "ተቀያሪ ቃል የለውም")
                richTxtInput.SelectedText = m_item.Text + " ";

            richTxtInput.Refresh();
        }

        #endregion


        #region memberMethods

        //private void DetermineDFSM(string m_strRecentWord, int recentWordStartIndex)
        //{
        //    if (m_strRecentWord[0].Equals('ተ') || m_strRecentWord[0].Equals('መ') || m_strRecentWord[0].Equals('አ') || m_strRecentWord[0].Equals('እ'))
        //    {
        //        if (m_strRecentWord[0].Equals('ተ') || m_strRecentWord[0].Equals('መ'))
        //        {
        //            melese _meleseTM = new melese();
        //            DeterministicFSM _meleseTMDFSM = _meleseTM.constructDFSMForMeleseStartingWithTandM();
        //            DisplayDFSAvalidationResult(_meleseTMDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //        }
        //        else if (m_strRecentWord[0].Equals('አ') || m_strRecentWord[0].Equals('እ'))
        //        {
        //            melese _meleseA = new melese();
        //            DeterministicFSM _meleseADFSM = _meleseA.constructDFSMForMeleseStartingWithA();

        //            DisplayDFSAvalidationResult(_meleseADFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //        }
        //        else
        //        {
        //            DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //        }
        //    }
        //    else if (m_strRecentWord[0].Equals('ጥ') || m_strRecentWord[0].Equals('ጠ') || m_strRecentWord[0].Equals('ካ'))
        //    {
        //        tegeb _tegebK = new tegeb();
        //        DeterministicFSM tegebKDFSM = _tegebK.constructDFSMForTegebStartingWithK();

        //        bool isValid = tegebKDFSM.CheckIfStringIsAccepted(m_strRecentWord);

        //        if (isValid)
        //        {
        //            DisplayDFSAvalidationResult(isValid, m_strRecentWord, recentWordStartIndex);
        //        }
        //        else
        //        {
        //            tegeb _tegebT = new tegeb();
        //            DeterministicFSM tegebTDFSM = _tegebT.constructDFSMForTegebStartingWithT();

        //            DisplayDFSAvalidationResult(tegebTDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //        }
        //    }
        //    else if (m_strRecentWord[0].Equals('የ'))
        //    {
        //        zege _zege = new zege();
        //        DeterministicFSM zegeDFSM = _zege.constructDFSMForZegeStartingWithY();

        //        DisplayDFSAvalidationResult(zegeDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //    }
        //    else if (m_strRecentWord[0].Equals('በ'))
        //    {
        //        degef _degef = new degef();
        //        DeterministicFSM degefDFSM = _degef.constructDFSMForDegefStartingWithB();

        //        DisplayDFSAvalidationResult(degefDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //    }
        //    else if (m_strRecentWord[0].Equals('ሰ'))
        //    {
        //        seber _seberS = new seber();
        //        DeterministicFSM seberSDFSM = _seberS.constructDFSMForSeberStartingWithS();
        //        //bool isValid = seberSDFSM.CheckIfStringIsAccepted(m_strRecentWord);
        //        DisplayDFSAvalidationResult(seberSDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //    }
        //    else if (m_strRecentWord[0].Equals('ድ'))
        //    {
        //        if (m_strRecentWord.Length > 1)
        //        {
        //            if (m_strRecentWord[1].Equals('ጋ') && m_strRecentWord.Length > 1)
        //            {
        //                degef _degef = new degef();
        //                DeterministicFSM degefDFSM = _degef.ConstructDFSAForWordsStartingWithD();

        //                DisplayDFSAvalidationResult(degefDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //            }
        //            else if (m_strRecentWord[1].Equals('ካ') && m_strRecentWord.Length > 1)
        //            {
        //                dekem _dekem = new dekem();
        //                DeterministicFSM dekemDFSM = _dekem.constructDFSMForDekemfStartingWithD();
        //                DisplayDFSAvalidationResult(dekemDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //            }
        //            else
        //            {
        //                DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //            }
        //        }
        //        else
        //        {
        //            DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //        }
        //    }
        //    else if (m_strRecentWord[0].Equals('ይ'))//ስብር
        //    {
        //        seber _seberY = new seber();
        //        DeterministicFSM seberYDFSM = _seberY.constructDFSMForSeberStartingWithY();
        //        DisplayDFSAvalidationResult(seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //    }
        //    else if (m_strRecentWord[0].Equals('ያ'))//
        //    {
        //        if (m_strRecentWord.Length > 1)
        //        {
        //            if ((m_strRecentWord[1].Equals('ላ') || m_strRecentWord[1].Equals('ም')) && m_strRecentWord.Length > 1)
        //            {
        //                meret _meret = new meret();
        //                DeterministicFSM _meretDFSM = _meret.constructDFSMForMeretStartingWithY();
        //                DisplayDFSAvalidationResult(_meretDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //            }
        //            else if (m_strRecentWord[1].Equals('ል'))
        //            {
        //                if (m_strRecentWord.Length > 2)
        //                {
        //                    if (m_strRecentWord[2].Equals('ተ'))
        //                    {
        //                        if (m_strRecentWord.Length > 3)
        //                        {
        //                            if (m_strRecentWord[3].Equals('ዘ'))
        //                            {
        //                                zege _zege = new zege();
        //                                DeterministicFSM zegeDFSM = _zege.constructDFSMForZegeStartingWithY();

        //                                DisplayDFSAvalidationResult(zegeDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //                            }
        //                            else if (m_strRecentWord[3].Equals('ሰ'))
        //                            {
        //                                seber _seberY = new seber();
        //                                DeterministicFSM seberYDFSM = _seberY.constructDFSMForSeberStartingWithY();
        //                                DisplayDFSAvalidationResult(seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //                            }
        //                            else if (m_strRecentWord[3].Equals('መ'))
        //                            {
        //                                meret _meret = new meret();
        //                                DeterministicFSM _meretDFSM = _meret.constructDFSMForMeretStartingWithY();
        //                                DisplayDFSAvalidationResult(_meretDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //                            }
        //                            else
        //                            {
        //                                DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //                        }
        //                    }
        //                    else if (m_strRecentWord[2].Equals('ሰ'))
        //                    {
        //                        seber _seberY = new seber();
        //                        DeterministicFSM seberYDFSM = _seberY.constructDFSMForSeberStartingWithY();
        //                        //bool isValid = seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord);
        //                        DisplayDFSAvalidationResult(seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //                    }
        //                    else
        //                    {
        //                        DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //                    }
        //                }
        //                else
        //                {
        //                    DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //                }
        //            }
        //            else
        //            {
        //                DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //            }
        //        }
        //        else
        //        {
        //            DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //        }
        //    }
        //    else if (m_strRecentWord[0].Equals('ደ'))
        //    {
        //        if (m_strRecentWord.Length > 1)
        //        {
        //            if (m_strRecentWord[1].Equals('ግ') || m_strRecentWord[1].Equals('ገ'))
        //            {
        //                degef _degef = new degef();
        //                DeterministicFSM degefDFSM = _degef.ConstructDFSAForWordsStartingWithD();

        //                //bool isValid = degefDFSM.CheckIfStringIsAccepted(m_strRecentWord);
        //                DisplayDFSAvalidationResult(degefDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //            }
        //            else if (m_strRecentWord[1].Equals('ካ') || m_strRecentWord[1].Equals('ከ'))
        //            {
        //                dekem _dekem = new dekem();
        //                DeterministicFSM dekemDFSM = _dekem.constructDFSMForDekemfStartingWithD();
        //                DisplayDFSAvalidationResult(dekemDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //            }
        //            else
        //            {
        //                DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //            }
        //        }
        //        else
        //        {
        //            DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //        }
        //    }
        //    else if (m_strRecentWord[0].Equals('ወ'))
        //    {
        //        wesed _wesedW = new wesed();
        //        DeterministicFSM wesedWDFSM = _wesedW.constructDFSMForWesedStartingWithW();
        //        DisplayDFSAvalidationResult(wesedWDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //    }
        //    else if (m_strRecentWord[0].Equals('ስ'))
        //    {
        //        if (m_strRecentWord.Length > 1)
        //        {
        //            if (m_strRecentWord[1].Equals('ላ'))
        //            {
        //                wesed _wesedS = new wesed();
        //                DeterministicFSM wesedSDFSM = _wesedS.constructDFSMForWesedStartingWithS();
        //                DisplayDFSAvalidationResult(wesedSDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //            }
        //            else if (m_strRecentWord[1].Equals('ባ'))
        //            {
        //                seber _seberS = new seber();
        //                DeterministicFSM seberSDFSM = _seberS.constructDFSMForSeberStartingWithS();
        //                DisplayDFSAvalidationResult(seberSDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
        //            }
        //        }
        //        else
        //        {
        //            DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //        }
        //    }
        //    else
        //    {
        //        DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
        //    }
        //}

        private bool DetermineDFSM(string m_strRecentWord, int recentWordStartIndex)
        {
            bool _isValid = false;
            if (m_strRecentWord[0].Equals('ተ') || m_strRecentWord[0].Equals('መ') || m_strRecentWord[0].Equals('አ') || m_strRecentWord[0].Equals('እ'))
            {
                if (m_strRecentWord[0].Equals('ተ') || m_strRecentWord[0].Equals('መ'))
                {
                    melese _meleseTM = new melese();
                    DeterministicFSM _meleseTMDFSM = _meleseTM.constructDFSMForMeleseStartingWithTandM();
                    _isValid = _meleseTMDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                    //DisplayDFSAvalidationResult(_meleseTMDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                }
                else if (m_strRecentWord[0].Equals('አ') || m_strRecentWord[0].Equals('እ'))
                {
                    melese _meleseA = new melese();
                    DeterministicFSM _meleseADFSM = _meleseA.constructDFSMForMeleseStartingWithA();
                    _isValid = _meleseADFSM.CheckIfStringIsAccepted(m_strRecentWord);
                    //DisplayDFSAvalidationResult(_meleseADFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                }
                else
                {
                    _isValid = false;
                    //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                }
            }
            else if (m_strRecentWord[0].Equals('ጥ') || m_strRecentWord[0].Equals('ጠ') || m_strRecentWord[0].Equals('ካ'))
            {
                tegeb _tegebK = new tegeb();
                DeterministicFSM tegebKDFSM = _tegebK.constructDFSMForTegebStartingWithK();

                _isValid = tegebKDFSM.CheckIfStringIsAccepted(m_strRecentWord);

                //if (_isValid)
                //{
                //    //DisplayDFSAvalidationResult(isValid, m_strRecentWord, recentWordStartIndex);
                //}
                if (!_isValid)
                {
                    tegeb _tegebT = new tegeb();
                    DeterministicFSM tegebTDFSM = _tegebT.constructDFSMForTegebStartingWithT();
                    _isValid = tegebTDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                    //DisplayDFSAvalidationResult(tegebTDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                }
            }
            else if (m_strRecentWord[0].Equals('የ'))
            {
                zege _zege = new zege();
                DeterministicFSM zegeDFSM = _zege.constructDFSMForZegeStartingWithY();
                _isValid = zegeDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                //DisplayDFSAvalidationResult(zegeDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
            }
            else if (m_strRecentWord[0].Equals('በ'))
            {
                degef _degef = new degef();
                DeterministicFSM degefDFSM = _degef.constructDFSMForDegefStartingWithB();
                _isValid = degefDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                //DisplayDFSAvalidationResult(degefDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
            }
            else if (m_strRecentWord[0].Equals('ሰ'))
            {
                seber _seberS = new seber();
                DeterministicFSM seberSDFSM = _seberS.constructDFSMForSeberStartingWithS();
                _isValid = seberSDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                //DisplayDFSAvalidationResult(seberSDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
            }
            else if (m_strRecentWord[0].Equals('ድ'))
            {
                if (m_strRecentWord.Length > 1)
                {
                    if (m_strRecentWord[1].Equals('ጋ') && m_strRecentWord.Length > 1)
                    {
                        degef _degef = new degef();
                        DeterministicFSM degefDFSM = _degef.ConstructDFSAForWordsStartingWithD();
                        _isValid = degefDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                        //DisplayDFSAvalidationResult(degefDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                    }
                    else if (m_strRecentWord[1].Equals('ካ') && m_strRecentWord.Length > 1)
                    {
                        dekem _dekem = new dekem();
                        DeterministicFSM dekemDFSM = _dekem.constructDFSMForDekemfStartingWithD();
                        _isValid = dekemDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                        //DisplayDFSAvalidationResult(dekemDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                    }
                    else
                    {
                        _isValid = false;
                        //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                    }
                }
                else
                {
                    _isValid = false;
                    //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                }
            }
            else if (m_strRecentWord[0].Equals('ይ'))//ስብር
            {
                seber _seberY = new seber();
                DeterministicFSM seberYDFSM = _seberY.constructDFSMForSeberStartingWithY();
                _isValid = seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                //DisplayDFSAvalidationResult(seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
            }
            else if (m_strRecentWord[0].Equals('ያ'))//
            {
                if (m_strRecentWord.Length > 1)
                {
                    if ((m_strRecentWord[1].Equals('ላ') || m_strRecentWord[1].Equals('ም')) && m_strRecentWord.Length > 1)
                    {
                        meret _meret = new meret();
                        DeterministicFSM _meretDFSM = _meret.constructDFSMForMeretStartingWithY();
                        _isValid = _meretDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                        //DisplayDFSAvalidationResult(_meretDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                    }
                    else if (m_strRecentWord[1].Equals('ል'))
                    {
                        if (m_strRecentWord.Length > 2)
                        {
                            if (m_strRecentWord[2].Equals('ተ'))
                            {
                                if (m_strRecentWord.Length > 3)
                                {
                                    if (m_strRecentWord[3].Equals('ዘ'))
                                    {
                                        zege _zege = new zege();
                                        DeterministicFSM zegeDFSM = _zege.constructDFSMForZegeStartingWithY();
                                        _isValid = zegeDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                                        //DisplayDFSAvalidationResult(zegeDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                                    }
                                    else if (m_strRecentWord[3].Equals('ሰ'))
                                    {
                                        seber _seberY = new seber();
                                        DeterministicFSM seberYDFSM = _seberY.constructDFSMForSeberStartingWithY();
                                        _isValid = seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                                        //DisplayDFSAvalidationResult(seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                                    }
                                    else if (m_strRecentWord[3].Equals('መ'))
                                    {
                                        meret _meret = new meret();
                                        DeterministicFSM _meretDFSM = _meret.constructDFSMForMeretStartingWithY();
                                        _isValid = _meretDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                                        //DisplayDFSAvalidationResult(_meretDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                                    }
                                    else
                                    {
                                        _isValid = false;
                                        //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                                    }
                                }
                                else
                                {
                                    _isValid = false;
                                    //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                                }
                            }
                            else if (m_strRecentWord[2].Equals('ሰ'))
                            {
                                seber _seberY = new seber();
                                DeterministicFSM seberYDFSM = _seberY.constructDFSMForSeberStartingWithY();
                                _isValid = seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                                //DisplayDFSAvalidationResult(seberYDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                            }
                            else
                            {
                                _isValid = false;
                                //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                            }
                        }
                        else
                        {
                            _isValid = false;
                            //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                        }
                    }
                    else
                    {
                        _isValid = false;
                        //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                    }
                }
                else
                {
                    _isValid = false;
                    //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                }
            }
            else if (m_strRecentWord[0].Equals('ደ'))
            {
                if (m_strRecentWord.Length > 1)
                {
                    if (m_strRecentWord[1].Equals('ግ') || m_strRecentWord[1].Equals('ገ'))
                    {
                        degef _degef = new degef();
                        DeterministicFSM degefDFSM = _degef.ConstructDFSAForWordsStartingWithD();

                        _isValid = degefDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                        //DisplayDFSAvalidationResult(degefDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                    }
                    else if (m_strRecentWord[1].Equals('ካ') || m_strRecentWord[1].Equals('ከ'))
                    {
                        dekem _dekem = new dekem();
                        DeterministicFSM dekemDFSM = _dekem.constructDFSMForDekemfStartingWithD();
                        _isValid = dekemDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                        //DisplayDFSAvalidationResult(dekemDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                    }
                    else
                    {
                        _isValid = false;
                        //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                    }
                }
                else
                {
                    _isValid = false;
                    //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                }
            }
            else if (m_strRecentWord[0].Equals('ወ'))
            {
                wesed _wesedW = new wesed();
                DeterministicFSM wesedWDFSM = _wesedW.constructDFSMForWesedStartingWithW();
                _isValid = wesedWDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                //DisplayDFSAvalidationResult(wesedWDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
            }
            else if (m_strRecentWord[0].Equals('ስ'))
            {
                if (m_strRecentWord.Length > 1)
                {
                    if (m_strRecentWord[1].Equals('ላ'))
                    {
                        wesed _wesedS = new wesed();
                        DeterministicFSM wesedSDFSM = _wesedS.constructDFSMForWesedStartingWithS();
                        _isValid = wesedSDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                        //DisplayDFSAvalidationResult(wesedSDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                    }
                    else if (m_strRecentWord[1].Equals('ባ'))
                    {
                        seber _seberS = new seber();
                        DeterministicFSM seberSDFSM = _seberS.constructDFSMForSeberStartingWithS();
                        _isValid = seberSDFSM.CheckIfStringIsAccepted(m_strRecentWord);
                        //DisplayDFSAvalidationResult(seberSDFSM.CheckIfStringIsAccepted(m_strRecentWord), m_strRecentWord, recentWordStartIndex);
                    }
                }
                else
                {
                    _isValid = false;
                    //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
                }
            }
            else
            {
                _isValid = false;
                //DisplayDFSAvalidationResult(false, m_strRecentWord, recentWordStartIndex);
            }
            return _isValid;
        }

        private void UnderLineWronglySpeltWord(string m_strRecentWord, int recentWordStartIndex)
        {
            richTxtInput.SelectionStart = 0;
            Font m_font = richTxtInput.SelectionFont;
            //Int32 m_strIndex = 0;
            richTxtInput.Find(m_strRecentWord, recentWordStartIndex, RichTextBoxFinds.WholeWord);
            recentWordStartIndex = richTxtInput.Text.IndexOf(m_strRecentWord, recentWordStartIndex);

            Underline U = new Underline(this.richTxtInput);
            U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave;
            U.SelectionUnderlineColor = Underline.UnderlineColor.Red;
            richTxtInput.SelectionFont = new Font(m_font.FontFamily, m_font.Size, FontStyle.Underline);

            //richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength + 1;
            richTxtInput.SelectionStart = richTxtInput.Text.Length;
            richTxtInput.Refresh();

            richTxtInput.SelectionFont = new Font("Nyala", m_font.Size, FontStyle.Regular);
        }

        private void RemoveUnderLineFromCorrectlySpeltWord(string m_strRecentWord, int recentWordStartIndex)
        {
            richTxtInput.SelectionStart = 0;
            Font m_font = richTxtInput.SelectionFont;
            //Int32 m_strIndex = 0;
            richTxtInput.Find(m_strRecentWord, recentWordStartIndex, RichTextBoxFinds.WholeWord);
            recentWordStartIndex = richTxtInput.Text.IndexOf(m_strRecentWord, recentWordStartIndex);

            Underline U = new Underline(this.richTxtInput);
            U.SelectionUnderlineStyle = Underline.UnderlineStyle.None;
            U.SelectionUnderlineColor = Underline.UnderlineColor.White;
            richTxtInput.SelectionFont = new Font(m_font.FontFamily, m_font.Size, FontStyle.Regular);

            //richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength + 1;
            richTxtInput.SelectionStart = richTxtInput.Text.Length;
            richTxtInput.Refresh();

            richTxtInput.SelectionFont = new Font("Nyala", m_font.Size, FontStyle.Regular);
        }

        void DisplayDFSAvalidationResult(bool isValid, string m_strRecentWord,int recentWordStartIndex)
        {
            if (!isValid)
            {
                UnderLineWronglySpeltWord(m_strRecentWord, recentWordStartIndex);
            }
            else
            {
                RemoveUnderLineFromCorrectlySpeltWord(m_strRecentWord, recentWordStartIndex);
            }
        }

        private List<string> GenerateSuggestion(char c)
        {
            List<string> returnedSuggestions = new List<string>();
            string[] allSuggestions = new string[]{ "ወሰደልኝ","ወስዳለት","ወስዳላቸው","ወስዶላታል","ወስዶልኛል","ወስዶላቸዋል","ወሰደችልኝ","ወሰደችለት","ወስዳላቸዋለች","ወስዳላታለች","ወስዳልኛለች","ወሰድክላቸው","ወሰድክ","ወሰድክለት","ወሰድክላት","ወሰደለት","ወሰደላት","ወሰደላቸው","ወሰደ","ወሰድሽ","ወሰድሽለት",
            "ወሰድሽላት","ወሰደችላቸው","ወሰደችልን","ወስዳ","ወስዶ","ወስደው","ወስደን","ወስደሀል","ወስደሻል","ስላልወሰደችለት","ስላልወሰደችላቸው","ስላልወሰደችላት","ስላልወሰደችልን","ስላልወሰደችልኝ","ስለወሰደላት","ስላልወሰደላት",
            "ስላልወሰደለት","ስላልወሰደልን","ስላልወሰደላቸው","ስላልወሰደልኝ","ተመላለሱ","መለሰ","መለሰች","መለሱ","መላለሱ","መላለሰች","መላለሰ","መላለስን","መልስ","መልሺ","መልሱ","መላልስ","መላልሺ","መላልሱ","መላልሶ","መላልሳ",
            "መላልሰው","መልሶ","መልሳ","መልሰው","መላለሰ","መላለሰች","መላለሱ","አስመላለሱ","አስመለሰ","እያስመለሰ","አስመለሰች","እያስመለሰች","አላስመለሰችም","አስመለሱ","እያስመለሱ","እያስመላለሱ","አመላለሱ","አመላለሰች","እናመላልስ","እየተመለሱ","እየተመላለሱ","እያመላለሱ","እያስመለሱት","እያስመለሱአቸው",
            "እያስመለሱአት","እያስመለስናቸው","እያስመለስነው","አላስመለሰም","አላስመለሳትም","አላስመለሳቸውም","አላስመለሰንም","አላስመለሰችም","አላስመለሰችውም","አላስመለሰቻትም","አላስመለሰቻቸውም","አላስመለሰችንም","አላመላለሰችውም","አላመላለሰቻትም","አላመላለሰችንም","አላመላለሰቻቸውም","አላመላለስነውም",
            "አላመላለስናትም","አላመላለስናቸውም","አላመላለሰንም","ያልተመረተ","ያላመረቱ","ያላመረታችሁ","ያላስመረትክ","ያላስመረትሽ","ያላስመረታችሁ","ያልተመረተለት","ያልተመረተላት","ያልተመረተላቸው","ያልተመረተበት","ያልተመረተባት","ያልተመረተችባቸው","ያላመረቱበት","ያላመረቱባት","ያላመረቱባቸው","ያላስመረቱባቸው",
            "ያላስመረተችባቸው","ያላስመረተችበት","ያምርቱበት","ያምርትበት","ሰበረ","ሰበርን","ሰበረች","ሰበሩ","ሰብራ","ስባሪ","ሰባባሪ","ሰበራችሁ","ሰባበሩ","ሰበርሻት","ሰበርሽው","ሰበርሻቸው","ሰበርናቸው","ሰባበርናቸው","ያልተሰባበረ","ያልተሰባበሩ","ያልተሰባበረች","ያልሰበረ","ያልሰበሩ","ያልሰበረች","ያልሰበርን","ይስበርህ",
            "ይስበርሽ","ይስበረን","ይስበሩህ","ይስበሩሽ","ይስበሩአችሁ","ይሰባብሩህ","ይሰባብሩሽ","ይሰባብሩኝ","ይስበረኝ","ጥጋብ","ጥጋበኛ","ጠገበ","ጠግባ","ጠግበው","ጠግበን","ጠግቦ","ጠገብን","ጠገብንበት","ካልጠገበ","ካልጠገበች","ካልጠገበችባቸው","ካልጠገቡ","ካልጠገብን","ካልጠገበስ","ካልጠገበችስ","ካልጠገቡስ",
            "ካልጠገብንስ","ካልጠገበችብንስ","በደጋፊዎች","በደጋፊያችን","በደጋፊው","በደጋፊዋ","በደጋፊያቸው","ድጋፍ","ደግፍ","ደገፈ","ደግፈኝ","ደገፈችኝ","ደገፉኝ","ደገፈን","ደገፈችው","ድካሙ","ድካሙዋ","ድካማቸው","ደከማቸው","ደካማ","ድካም","ደከመ","ደከመች","ደካከመ","ደካከመው","ደካከመን","ደካከማት","ደካከማቸው",
            "የተዘጋ","የተዘጋጋ","ያልተዘጋ","ያልተዘጋጋ","የማንዘጋ","የማንዘጋጋ","የማናዘጋት","የማንዘጋጋት","የማንዘጋጋው","የማይዘጋው","የማትዘጋው","የማንዘጋው","የማይዘጉት" };
            foreach (string str in allSuggestions)
            {
                if (str[0].Equals(c))
                {
                    returnedSuggestions.Add(str);
                }
            }
            return returnedSuggestions;
        }

        //private void InitializeAmharicSupport(RichTextBox richTxtB)
        //{
        //    //Add all textBox control by their ID her  to enable the keymapper           
        //    //_mapper.AddControl(richTxtB);
        //}

        #endregion
    }
}
