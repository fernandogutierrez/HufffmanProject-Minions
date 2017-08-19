using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode
{
    public class StringText
    {
        public StringBuilder Text { get; private set; }
        public int AmountLines { get; private set; }

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
            Text.Append(line);//.Append(Environment.NewLine);
            AmountLines++;
        }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
