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
    
    /// TODO Add data binding
    /// TODO implement ObservableList<Combatant>
    /// TODO implement ListBox or ListView (research them both)
    /// TODO implement ViewModel
    /// TODO Create menu bar
    /// TODO Implement custom controls (kinda like fragments in android studio)
    /// TODO resolve initiative disputes (possibly through pop up menu)
    /// Make sure keyboard shortcuts are optimized for smooth workflow
    public partial class MainWindow : Window
    {

        public List<Combatant> combatants = [];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCombatantButton_Click(object sender, RoutedEventArgs e)
        {
            //get string from textbox
            Combatant newEntry = new(NameTextBox.Text, int.Parse(InitiativeTextBox.Text));

            //add string to list of combatants
            combatants.Add(newEntry);

            //order the list by initiative
            combatants.Sort((a, b) => b.Initiative.CompareTo(a.Initiative));

            //clear the initiativeTextBlock
            InitiativeTextBlock.Text = "";

            //loop through the combatants and add them to initiativeTextBlock
            foreach(Combatant combatant in combatants)
            {
                InitiativeTextBlock.Text += combatant.ToString() + "\n";
            }

        }
    }
}