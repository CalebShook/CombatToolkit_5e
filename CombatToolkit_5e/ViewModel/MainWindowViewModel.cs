using CombatToolkit_5e.Model;
using CombatToolkit_5e.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CombatToolkit_5e.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		private int initiative;

		public int Initiative
		{
			get { return initiative; }
			set { initiative = value; }
		}

		public ObservableCollection<Combatant> Combatants { get; set; }

		public RelayCommand AddCommand => new RelayCommand(execute => AddCombatant());
        public RelayCommand RemoveCommand => new RelayCommand(execute => RemoveCombatant(), canExecute => selectedCombatant != null);

        public MainWindowViewModel() 
		{
			Combatants = new ObservableCollection<Combatant>();
		}

		private Combatant selectedCombatant;

        public Combatant SelectedCombatant
		{
			get { return selectedCombatant; }
			set 
			{ 
				selectedCombatant = value;
				OnPropertyChanged();
			}
		}

        private void AddCombatant()
		{
			Combatants.Add(new Combatant(Name, Initiative));

            //sort the list
            ICollectionView view = CollectionViewSource.GetDefaultView(Combatants);
            view.SortDescriptions.Add(new SortDescription("Initiative", ListSortDirection.Descending));
        }

        private void RemoveCombatant()
        {
			Combatants.Remove(SelectedCombatant);
        }

    }
}
