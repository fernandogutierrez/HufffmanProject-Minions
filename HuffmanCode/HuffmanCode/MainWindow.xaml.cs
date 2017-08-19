using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace HuffmanCode
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            String filePath = String.Empty;

            if (openFileDialog.ShowDialog() == true)
            {
               filePath = openFileDialog.FileName;
            }

            string text = ReadInputService.LoadTxt(filePath);

            //// 2nd part

            //First Step
            //NodeList nodeList = new NodeList();
            List<Node> nodes = NodeList.GetCharFrequency(text);
            Stack<Node> minHeap = StackManager.GetSortedStack(nodes);

            // 2 and 3
            HuffmanTree huffmanTree = new HuffmanTree();
            Node tree = huffmanTree.BuildTree(minHeap);
            // Generate code
            string finalCode = huffmanTree.GenerateCode(tree, text);
            DecodeData(tree, tree, 0, finalCode);

            Console.ReadLine();
        }

        public static void DecodeData(Node parentNode, Node currentNode, int pointer, string input)
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
