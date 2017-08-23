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
        String fileToCompress;
        Node treeOfCodes;
        HuffmanTree huffmanTree;
        string finalCode;

        public MainWindow()
        {
            InitializeComponent();
            textLog = new StringText();
            fileToCompress = String.Empty;
            huffmanTree = new HuffmanTree();
            finalCode = String.Empty;
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                fileToCompress = openFileDialog.FileName;
            }
        }

        private void btnCompressData_Click(object sender, RoutedEventArgs e)
        {
            string text = ReadInputService.LoadTxt(fileToCompress);
            txtbl_log.Text = textLog.ComposeNewStrRow("Reading file path: ", fileToCompress);

            List<Node> nodes = NodeList.GetCharFrequency(text);
            txtbl_log.Text += textLog.ComposeNewStrRow("Nodes with frequency: ", nodes.ToString());

            Stack<Node> minHeap = StackManager.GetSortedStack(nodes);
            txtbl_log.Text += textLog.ComposeNewStrRow("Min Heap: ", minHeap.ToString());

            treeOfCodes = huffmanTree.BuildTree(minHeap);
            txtbl_log.Text += textLog.ComposeNewStrRow("Tree of nodes: ", minHeap.ToString());
            finalCode = huffmanTree.GenerateCode(treeOfCodes, text);
            txtbl_log.Text += textLog.ComposeNewStrRow("Code generated: ", finalCode);

        }
        private void btnDeCompressData_Click(object sender, RoutedEventArgs e)
        {
            huffmanTree.DecodeData(treeOfCodes, finalCode);
        }

    }
}
