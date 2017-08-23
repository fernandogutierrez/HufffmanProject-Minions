using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace HuffmanCode
{
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
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                fileToCompress = openFileDialog.FileName;
                compress_btn.IsEnabled = true;
            }
        }

        private void btnCompressData_Click(object sender, RoutedEventArgs e)
        {
            compress_btn.IsEnabled = false;
            openFile_btn.IsEnabled = false;
            decompres_btn.IsEnabled = true;

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
            compress_btn.IsEnabled = false;
            decompres_btn.IsEnabled = false;

            huffmanTree.DecodeData(treeOfCodes, finalCode);
        }

    }
}
