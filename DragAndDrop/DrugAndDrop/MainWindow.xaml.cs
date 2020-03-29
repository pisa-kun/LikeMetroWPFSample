using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DrugAndDrop
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyFileList _list;
        public MainWindow()
        {
            InitializeComponent();
            _list = this.DataContext as MyFileList;
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {            
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null)
            {
                foreach (var s in files)
                    _list.FileNames.Add(s);
            }
        }
        private void Window_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = "";
            foreach(var t in _list.FileNames)
            {
                text += t;
            }
            MessageBox.Show($"List is \n {text}");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _list.FileNames.Clear();
        }
    }
    public class MyFileList
    {
        public MyFileList()
        {
            FileNames = new ObservableCollection<string>();
        }
        public ObservableCollection<string> FileNames
        {
            get;
            private set;
        }
    }
}
