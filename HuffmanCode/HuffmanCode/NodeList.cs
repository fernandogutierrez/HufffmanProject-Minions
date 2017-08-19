using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode
{
    public static class NodeList
    {
        public static List<Node> GetCharFrequency(string text)
        {
            List<Node> nodeList = new List<Node>();
            nodeList.Add(new Node(text[0].ToString(), 1));
            text = text.Remove(0, 1);

            foreach (var currentCharacter in text)
            {
                int position = GetCharIndex(nodeList, currentCharacter);
                if (position != -1)
                {
                    nodeList[position].Frequency++;
                }
                else
                {
                    string data = currentCharacter.ToString();
                    nodeList.Add(new Node(data, 1));
                }
            }

            return nodeList;
        }

        private static int GetCharIndex(List<Node> listOfNodes, char data)
        {
            string currentCharAsString = Convert.ToString(data);
            for (int i = 0; i < listOfNodes.Count; i++)
            {
                if (currentCharAsString.Equals(listOfNodes[i].Data))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
