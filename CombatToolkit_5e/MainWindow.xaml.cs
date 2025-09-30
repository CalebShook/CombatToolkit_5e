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
    
    /// TODO implement ObservableList<Combatant>
    /// TODO implement ViewModel
    /// TODO Create menu bar
    /// TODO Implement custom controls (kinda like fragments in android studio)
    /// TODO resolve initiative disputes (possibly through pop up menu)
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            DataContext = this;
            combatants = new ObservableCollection<string>();
            InitializeComponent();
        }

        private ObservableCollection<string> combatants;

        public ObservableCollection<string> Combatants
        {
            get { return combatants; }
            set { combatants = value; }
        }


        private void AddCombatantButton_Click(object sender, RoutedEventArgs e)
        {
            if(verifyInputs())
            {
                //get string from textbox
                Combatant newCombatant = new(NameTextBox.Text, int.Parse(InitiativeTextBox.Text));

                //add string to list of combatants
                combatants.Add(newCombatant.ToString());

                NameTextBox.Clear();
                InitiativeTextBox.Clear();
                NameTextBox.Focus();
            }
        }

        private void RemoveCombatantButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                combatants.RemoveAt(InitiativeListView.SelectedIndex);
            }
            catch 
            {
                errorLabel.Content = "You must select a combatant to remove";
            }
        }

        public bool verifyInputs()
        {
            errorLabel.Content = string.Empty;

            string name = NameTextBox.Text;
            if (name != "")
            {
                //name is good
                if (int.TryParse(InitiativeTextBox.Text, out int successfulInitiative))
                {
                    //both are good
                    return true;
                }
                else
                {
                    //just the init is bad
                    errorLabel.Content = "Please enter a valid initiative";
                }
            }
            else if (int.TryParse(InitiativeTextBox.Text, out int successfulInitiative))
            {
                //just the name is bad
                errorLabel.Content = "Please enter a name";
            }
            else
            {
                //both are bad
                errorLabel.Content = "Please enter a name and valid initiative";
            }
            return false;
        }

        
    }
}