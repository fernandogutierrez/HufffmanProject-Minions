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
        StringText textLog;
        public MainWindow()
        {
            InitializeComponent();
            textLog = new StringText();
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
            txtbl_log.Text = textLog.ComposeNewStrRow("Reading file path: ", filePath);

            List<Node> nodes = NodeList.GetCharFrequency(text);
            txtbl_log.Text += textLog.ComposeNewStrRow("Nodes with frequency: ", nodes.ToString());

            Stack<Node> minHeap = StackManager.GetSortedStack(nodes);
            txtbl_log.Text += textLog.ComposeNewStrRow("Min Heap: ", minHeap.ToString());

            HuffmanTree huffmanTree = new HuffmanTree();
            Node tree = huffmanTree.BuildTree(minHeap);
            txtbl_log.Text += textLog.ComposeNewStrRow("Tree of nodes: ", minHeap.ToString());
            string finalCode = huffmanTree.GenerateCode(tree, text);
            txtbl_log.Text += textLog.ComposeNewStrRow("Code generated: ", finalCode);
            //WriteOutputService.CreateTxt(huffmanTree.DecodeData());

            //DecodeData(tree, tree, 0, finalCode);

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
