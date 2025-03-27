using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace appsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<AppObject> apps = new();
        private AppObject previousSelection = null;

        public MainWindow()
        {
            InitializeComponent();

            apps = AppObject.LoadFromCsv(@"..\..\..\src\apps.csv");

            kategoriakListbox.ItemsSource = apps.Select(a => a.Category.CategoryName).Distinct();
            kategoriakListbox.SelectedIndex = 0;

            kategoriaElemeiCombobox.ItemsSource = apps.Where(a => a.Category.CategoryName == kategoriakListbox.SelectedValue.ToString());
            kategoriaElemeiCombobox.SelectedIndex = 0;



        }

        private void kategoriakListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (kategoriakListbox.SelectedItem != null)
            {
                kategoriaElemeiCombobox.ItemsSource = apps.Where(a => a.Category.CategoryName == kategoriakListbox.SelectedValue.ToString());
                kategoriaElemeiCombobox.SelectedIndex = 0;
                previousSelection = null;
                confirmButton.IsEnabled = false;
            }
        }

        private void kategoriaElemeiCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (kategoriaElemeiCombobox.SelectedItem is AppObject selectedApp)
            {
                versionNumberLabel.Content = selectedApp.CurrentVer;
                categorizationLabel.Content = selectedApp.Rating;
                viewLabel.Content = selectedApp.Reviews;

                if (previousSelection != null && previousSelection != selectedApp &&
                    previousSelection.Category.CategoryName == selectedApp.Category.CategoryName)
                {
                    confirmButton.IsEnabled = true;
                }

                previousSelection = selectedApp;
            }
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (kategoriakListbox.SelectedItem == null) return;

            string selectedCategory = kategoriakListbox.SelectedItem.ToString();
            var appsInCategory = apps.Where(a => a.Category.CategoryName == selectedCategory).ToList();

            if (appsInCategory.Count == 0) return;

            Random random = new Random();
            AppObject randomApp = appsInCategory[random.Next(appsInCategory.Count)];

            versionNumberLabel.Content = randomApp.CurrentVer;
            categorizationLabel.Content = randomApp.Rating;
            viewLabel.Content = randomApp.Reviews;

            confirmButton.IsEnabled = false;
            previousSelection = null;
        }
    }
}