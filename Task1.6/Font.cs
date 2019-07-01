using System;
using System.Collections.Generic;
using System.Text;

namespace OneTask
{
    class Font
    {
        private bool Bold { get; set; }
        private bool Italic { get; set; }
        private bool Underline { get; set; }

        public Font()
        {
            Bold = false;
            Italic = false;
            Underline = false;
        }

        /// <summary>
        /// Returns fields which is true
        /// </summary>
        /// <returns>fields which is true</returns>
        public string GetSignatureSettings()
        {
            string result = "";
            if (Bold == true)
            {
                result += "Bold, ";
            }
            if (Italic == true)
            {
                result += "Italic, ";
            }
            if (Underline == true)
            {
                result += "Underline, ";
            }
            if (String.IsNullOrWhiteSpace(result))
            {
                return "None";
            }
            result = result.Remove(result.Length - 2);
            return result;
        }

        /// <summary>
        /// Reverses Bold
        /// </summary>
        public void SetBold()
        {
            Bold = !Bold;
        }

        /// <summary>
        /// Reverses Italic
        /// </summary>
        public void SetItalic()
        {
            Italic = !Italic;
        }

        /// <summary>
        /// Reverses Underline
        /// </summary>
        public void SetUnderline()
        {
            Underline = !Underline;
        }
    }
}
