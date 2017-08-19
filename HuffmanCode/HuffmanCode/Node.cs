using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCode
{
    public class Node
    {
        private String data;
        private int frequency;
        private Node leftChild, rightChild;

        public Node(String data, int frequency)
        {
            this.data = data;
            this.frequency = frequency;
        }

        public Node(Node leftChild, Node rightChild)
        {
            this.Data = leftChild.Data + ":" + rightChild.Data;
            this.Frequency = leftChild.Frequency + rightChild.Frequency;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

        public Node LeftChild 
        { 
            get 
            { 
                return this.leftChild; 
            } 
        }
        public Node RightChild 
        { 
            get 
            { 
                return this.rightChild; 
            } 
        }

        public int Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
            }
        }
        public String Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public Boolean IsLeaf()
        {
            if (this.leftChild == null && this.rightChild == null)
            {
                return true;
            }
            return false;
        }
    }
}
