using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode
{
    public class NodeList
    {
        private List<Node> nodeList;
        public NodeList()
        {
            nodeList = new List<Node>();
        }

        public List<Node> GetCharFrequency(string text)
        {
            this.nodeList.Add(new Node(Convert.ToString(text[0]), 1));
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
                    if (data.Equals("\n")) 
                    {
                        data = "\x0A";
                    } 
                    else if(data.Equals("\r"))
                    {
                        data = "\x0D";
                    }
                    nodeList.Add(new Node(data, 1));
                }
            }

            return nodeList;
        }

        private int GetCharIndex(List<Node> listOfNodes, char data)
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
