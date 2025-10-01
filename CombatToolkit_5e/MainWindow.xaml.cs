using CombatToolkit_5e.Model;
using CombatToolkit_5e.ViewModel;
using System.Collections.ObjectModel;
using System.DirectoryServices;
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

namespace CombatToolkit_5e
{
    /// TODO Create menu bar
    /// TODO Implement custom controls (kinda like fragments in android studio)
    /// TODO resolve initiative disputes (possibly through pop up menu)
    /// TODO create "in combat" mode
    /// TODO add clear button
    /// TODO add error checking
    /// TODO get rid of the 0 in the InitiativeTextBox
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel viewModel = new();
            DataContext = viewModel;
        }

    }
}