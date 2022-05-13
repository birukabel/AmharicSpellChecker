using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AmharicSpellChecker
{
    public class Underline
    {
        public Underline(System.Windows.Forms.RichTextBox RTB)
        {
            this.R = RTB;
        }
        private const int CFM_UNDERLINETYPE = 8388608;
        private const int EM_SETCHARFORMAT = 1092;
        private const int EM_GETCHARFORMAT = 1082;
        private const int SCF_SELECTION = 0x1;

        private System.Windows.Forms.RichTextBox R;
        [StructLayout(LayoutKind.Sequential)]
        private struct CHARFORMAT
        {
            public int cbSize;
            public uint dwMask;
            public uint dwEffects;
            public int yHeight;
            public int yOffset;
            public int crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]

            public char[] szFaceName;
            // CHARFORMAT2 from here onwards.
            public short wWeight;
            public short sSpacing;
            public int crBackColor;
            public int LCID;
            public uint dwReserved;
            public short sStyle;
            public short wKerning;
            public byte bUnderlineType;
            public byte bAnimation;
            public byte bRevAuthor;
        }

        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int SendMessage(HandleRef hWnd, int msg, int wParam, ref CHARFORMAT lp);

        public UnderlineStyle SelectionUnderlineStyle
        {
            get
            {
                CHARFORMAT fmt = new CHARFORMAT();
                fmt.cbSize = Marshal.SizeOf(fmt);

                // Get the underline style.
                SendMessage(new HandleRef(this, R.Handle), EM_GETCHARFORMAT, SCF_SELECTION, ref fmt);

                // Default to no underline.
                if ((fmt.dwMask & CFM_UNDERLINETYPE) == 0)
                {
                    return UnderlineStyle.None;
                }

                byte style = Convert.ToByte(fmt.bUnderlineType & 0xf);

                return (UnderlineStyle)style;
            }

            set
            {
                // Ensure we don't alter the color by accident.
                UnderlineColor color = SelectionUnderlineColor;

                // Ensure we don't show it if it shouldn't be shown.
                if (value == UnderlineStyle.None)
                {
                    color = UnderlineColor.Black;
                }

                CHARFORMAT fmt = new CHARFORMAT();
                fmt.cbSize = Marshal.SizeOf(fmt);
                fmt.dwMask = CFM_UNDERLINETYPE;
                fmt.bUnderlineType = Convert.ToByte(Convert.ToByte(value) | Convert.ToByte(color));

                // Set the underline type.
                SendMessage(new HandleRef(this, R.Handle), EM_SETCHARFORMAT, SCF_SELECTION, ref fmt);
            }
        }

        public enum UnderlineStyle
        {
            /// <summary>
            /// No underlining.
            /// </summary>
            None = 0,

            /// <summary>
            /// Standard underlining across all words.
            /// </summary>
            Normal = 1,

            /// <summary>
            /// Standard underlining broken between words.
            /// </summary>
            Word = 2,

            /// <summary>
            /// Double line underlining.
            /// </summary>
            Double = 3,

            /// <summary>
            /// Dotted underlining.
            /// </summary>
            Dotted = 4,

            /// <summary>
            /// Dashed underlining.
            /// </summary>
            Dash = 5,

            /// <summary>
            /// Dash-dot ("-.-.") underlining.
            /// </summary>
            DashDot = 6,

            /// <summary>
            /// Dash-dot-dot ("-..-..") underlining.
            /// </summary>
            DashDotDot = 7,

            /// <summary>
            /// Wave underlining (like spelling mistakes in MS Word).
            /// </summary>
            Wave = 8,

            /// <summary>
            /// Extra thick standard underlining.
            /// </summary>
            Thick = 9,

            /// <summary>
            /// Extra thin standard underlining.
            /// </summary>
            HairLine = 10,

            /// <summary>
            /// Double thickness wave underlining.
            /// </summary>
            DoubleWave = 11,

            /// <summary>
            /// Thick wave underlining.
            /// </summary>
            HeavyWave = 12,

            /// <summary>
            /// Extra long dash underlining.
            /// </summary>
            LongDash = 13
        }

        public UnderlineColor SelectionUnderlineColor
        {
            get
            {
                CHARFORMAT fmt = new CHARFORMAT();
                fmt.cbSize = Marshal.SizeOf(fmt);

                // Get the underline color.
                SendMessage(new HandleRef(this, R.Handle), EM_GETCHARFORMAT, SCF_SELECTION, ref fmt);

                // Default to black.
                if ((fmt.dwMask & CFM_UNDERLINETYPE) == 0)
                {
                    return UnderlineColor.Black;
                }

                byte style = Convert.ToByte(fmt.bUnderlineType & 0xf0);

                return (UnderlineColor)style;
            }

            set
            {
                // Ensure we don't alter the style.
                UnderlineStyle style = SelectionUnderlineStyle;

                // Ensure we don't show it if it shouldn't be shown.
                if (style == UnderlineStyle.None)
                {
                    value = UnderlineColor.Black;
                }

                CHARFORMAT fmt = new CHARFORMAT();
                fmt.cbSize = Marshal.SizeOf(fmt);
                fmt.dwMask = CFM_UNDERLINETYPE;
                fmt.bUnderlineType = Convert.ToByte(Convert.ToByte(style) | Convert.ToByte(value));

                // Set the underline color.
                SendMessage(new HandleRef(this, R.Handle), EM_SETCHARFORMAT, SCF_SELECTION, ref fmt);
            }
        }

        public enum UnderlineColor
        {
            /// <summary>Black.</summary>
            Black = 0x0,

            /// <summary>Blue.</summary>
            Blue = 0x10,

            /// <summary>Cyan.</summary>
            Cyan = 0x20,

            /// <summary>Lime green.</summary>
            LimeGreen = 0x30,

            /// <summary>Magenta.</summary>
            Magenta = 0x40,

            /// <summary>Red.</summary>
            Red = 0x50,

            /// <summary>Yellow.</summary>
            Yellow = 0x60,

            /// <summary>White.</summary>
            White = 0x70,

            /// <summary>DarkBlue.</summary>
            DarkBlue = 0x80,

            /// <summary>DarkCyan.</summary>
            DarkCyan = 0x90,

            /// <summary>Green.</summary>
            Green = 0xa0,

            /// <summary>Dark magenta.</summary>
            DarkMagenta = 0xb0,

            /// <summary>Brown.</summary>
            Brown = 0xc0,

            /// <summary>Olive green.</summary>
            OliveGreen = 0xd0,

            /// <summary>Dark gray.</summary>
            DarkGray = 0xe0,

            /// <summary>Gray.</summary>
            Gray = 0xf0
        }
    }
}
