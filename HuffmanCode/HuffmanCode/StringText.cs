using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode
{
    public class StringText
    {
        public StringBuilder Text { get; set; }
        public int AmountLines { get; set; }

        public StringText()
        {
            Text = new StringBuilder();
            AmountLines = 0;
        }

        public StringText(string text)
        {
            Text = new StringBuilder(text);
        }

        public void ComposeText(string line)
        {
            Text.Append(line);
            Text.Append(System.Environment.NewLine);
            AmountLines++;
        }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
