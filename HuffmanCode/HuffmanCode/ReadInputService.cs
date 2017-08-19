using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode
{
    public class ReadInputService
    {
        public static string LoadTxt(string path)
        {
            StringText fullText = new StringText();

            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    fullText.ComposeText(reader.ReadLine());
                }
            }

            return fullText.ToString();
        }
    }
}
