
using CSSaveToFileSysFW;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace CSSaveToFileSysWPFFW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string sqlConnectionString = ConfigurationManager.AppSettings["connString"];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveToFileSys(object subject, RoutedEventArgs e)
        {

            ComboBoxItem item = (ComboBoxItem)uiComboBox.SelectedItem;
            string templateName = item.Content.ToString();
            string path = uiTextBlock.Text.ToString();
            uiListView.ItemsSource = new List<string>();

            if (!path.EndsWith("\\"))
            {
                MessageBox.Show("Az elérési útvonal '\' jellel végződjön!");
            }
            else if (templateName.Equals(""))
            {
                MessageBox.Show("Válassz valamit a combobox-ból!");
            }
            else
            {

                uiListView.ItemsSource = new SaveToFileSysFW(
                    sqlConnectionString,
                    templateName,
                    path
                ).WriteOutAc4yObjectNameList();

            }
        }
    }
}
