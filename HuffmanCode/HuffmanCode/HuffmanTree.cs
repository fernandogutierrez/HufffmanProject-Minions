using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode
{
    public class HuffmanTree
    {
        private Dictionary<String, String> codeDictionary;

        public HuffmanTree()
        {
            this.codeDictionary = new Dictionary<string, string>();
        }
        public Node BuildTree(Stack<Node> stack)
        {
            //2
            //3. Create a new internal node with frequency equal to the sum of 
            // the two nodes frequencies. Make the first extracted node 
            // as its left child and the other extracted node as its right child. Add this node to the min heap. 
            while (stack.Count > 1)
            {
                Node leftChild = stack.Pop();  // Make the first extracted node as its left child
                Node rightChild = stack.Pop(); // Make the second extracted node as its rigth child

                // Adding this node to the min heap
                Node newInternalNode = new Node(leftChild, rightChild);
                stack.Push(newInternalNode);
                stack = StackManager.GetSortedStack(stack.ToList<Node>());
            }
            // 4. Make the root node, the tree is complete
            return stack.Pop();
        }

        public string GenerateCode(Node parentNode, String text)
        {
            GenerateCodeFromNode(parentNode, String.Empty);
            return GenerateStringCode(text);
        }

        private void GenerateCodeFromNode(Node parentNode, string code)
        {
            if (parentNode != null)
            {
                GenerateCodeFromNode(parentNode.LeftChild, code + "0");
                if (parentNode.IsLeaf())
                {
                    Console.WriteLine(parentNode.Data + "{" + code + "}");
                    codeDictionary.Add(parentNode.Data, code);
                }
                GenerateCodeFromNode(parentNode.RightChild, code + "1");
            }
        }

        private string GenerateStringCode(string textToDecode)
        {
            StringBuilder text = new StringBuilder(textToDecode);

            foreach (char currChar in textToDecode)
            {
                string value = String.Empty;
                codeDictionary.TryGetValue(currChar.ToString(), out value);
                text.Replace(currChar.ToString(), value);
            }
            return text.ToString();
        }

        public string DecodeData() 
        {
            return string.Empty;
        }

        public void DecodeData(Node treeOfCodes, string dataDecoded)
        {
            DecodeData(treeOfCodes, treeOfCodes, 0, dataDecoded);
        }

        public void DecodeData(Node parentNode, Node currentNode, int pointer, string input)
        {
            if (input.Length == pointer)
            {
                if (currentNode.IsLeaf())
                {
                    Console.WriteLine(currentNode.Data);
                }

                return;
            }
            else
            {
                if (currentNode.IsLeaf())
                {
                    Console.WriteLine(currentNode.Data);
                    DecodeData(parentNode, parentNode, pointer, input);
                }
                else
                {
                    if (input.Substring(pointer, 1) == "0")
                    {
                        DecodeData(parentNode, currentNode.LeftChild, ++pointer, input);
                    }
                    else
                    {
                        DecodeData(parentNode, currentNode.RightChild, ++pointer, input);
                    }
                }
            }
        }
    }
}
