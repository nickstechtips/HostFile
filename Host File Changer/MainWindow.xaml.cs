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
using System.IO;
namespace Host_File_Changer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename = @"C:\Windows\System32\drivers\etc\hosts";
        List<string> hostFile = new List<string>();
        public MainWindow()
        {
            InitializeComponent();


            if (System.IO.File.Exists(filename))
            {
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        currentHostFileListbox.Items.Add(line);
                        hostFile.Add(line);

                    }
                    streamReader.Dispose();

                }


            }
        }

        private void currentHostFileListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void loadHostFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void commentOutBtn_Click(object sender, RoutedEventArgs e)
        {


            if (System.IO.File.Exists(filename))
            {
                
                int selectedIndex = currentHostFileListbox.SelectedIndex;
                if (selectedIndex != null && selectedIndex >= 0)
                {

                    
                    if (!hostFile[selectedIndex].Contains('#'))
                    {

                        string newLine;
                        newLine = '#' + hostFile[selectedIndex];
                        hostFile.RemoveAt(selectedIndex);
                        hostFile.Insert(selectedIndex, newLine);
                        currentHostFileListbox.Items.Clear();
                        using (StreamWriter streamWriter = new StreamWriter(filename))
                        {
                            foreach (string line in hostFile)
                            {
                                streamWriter.WriteLine(line);
                                currentHostFileListbox.Items.Add(line);
                            }
                        }
                    }
                }

                
            }
        }

        private void unCommentOutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(filename))
            {
                
                int selectedIndex = currentHostFileListbox.SelectedIndex;
                if (selectedIndex != null && selectedIndex >= 0)
                {

                    string newLine = currentHostFileListbox.SelectedItem.ToString();
                    if (newLine.Contains('#'))
                    {
                        newLine = newLine.Remove(0, 1);

                        hostFile.RemoveAt(selectedIndex);
                        hostFile.Insert(selectedIndex, newLine);
                        currentHostFileListbox.Items.Clear();
                        using (StreamWriter streamWriter = new StreamWriter(filename))
                        {
                            foreach (string line in hostFile)
                            {
                                streamWriter.WriteLine(line);
                                currentHostFileListbox.Items.Add(line);
                            }
                        }
                    }
                }


            }
        }

        private void local_IP_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void addNewBtn_Click(object sender, RoutedEventArgs e)
        {
            string ip = ipAddressBox.Text;
            string domain = domainNameBox.Text;
            string newLine = ip + ' ' + domain;
            hostFile.Add(newLine);
            currentHostFileListbox.Items.Clear();

            using (StreamWriter streamWrite = new StreamWriter(filename))
            {
                foreach (string line in hostFile)
                {
                    streamWrite.WriteLine(line);
                    currentHostFileListbox.Items.Add(line);
                }
            }
           

        }



        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ipAddressBox.Text = @"127.0.0.1";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ipAddressBox.Text = "";
        }
        


    }
}
