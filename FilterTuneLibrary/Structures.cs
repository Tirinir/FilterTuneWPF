using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterTuneWPF_dll
{
    /// <summary>
    /// Range of int numbers, used to describe parts of string array, that meet specified conditions
    /// </summary>
    public struct Block
    {
        public int Start { get; set; }
        public int Finish { get; set; }

        public Block(int _st, int _fn)
        {
            this.Start = _st;
            this.Finish = _fn;
        }
    }
    /// <summary>
    /// Contains two strings
    /// </summary>
    public struct StringPair
    {
        public string Name { get; set; }
        public string Value { get; set; }
        /// <summary>
        /// Creates instance of StringPair
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_value"></param>

        public StringPair(string _name, string _value)
        {
            this.Name = _name;
            this.Value = _value;
        }

        /// <summary>
        /// Creates instance of StringPair from single line, empty StringPair.Value is set to '*'
        /// </summary>
        /// <param name="text"></param>
        public StringPair(string text)
        {
            int spacePosition = text.IndexOf(' ');
            string _name, _value;
            if (spacePosition > 0)
            {
                _name = text.Substring(0, spacePosition);
                _value = text.Substring(spacePosition);
            }
            else
            {
                _name = text;
                _value = "*";
            }

            this.Name = _name;
            this.Value = _value;
        }
    }
}
