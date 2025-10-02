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
		private readonly Combatant lairAction = new("Lair Action", 20);

		private string? name;

		public string? Name
		{
			get { return name; }
			set { name = value;
				OnPropertyChanged();
			}
		}


		private int? initiative;

		public int? Initiative
		{
			get { return initiative; }
			set { initiative = value; 
				OnPropertyChanged();
			}
		}

		private string errorLabel;

		public string ErrorLabel
		{
			get { return errorLabel; }
			set { errorLabel = value;
				OnPropertyChanged();
			}
		}


		private bool lairActions;

		public bool LairActions
		{
			get { return lairActions; }
			set 
			{
                if (lairActions != value)
                {
                    lairActions = value;
                    OnPropertyChanged();

                    if (lairActions)
                    {
                        if (!Combatants.Contains(lairAction))
                            Combatants.Add(lairAction);
                    }
                    else
                    {
                        if (Combatants.Contains(lairAction))
                            Combatants.Remove(lairAction);
                    }
                }
            }
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

			//bool initiativeIsValid = Initiative.HasValue;

			if (Name != "" && Name != null)
			{
				if(Initiative.HasValue)
				{
                    int checkedInitiative = Initiative.Value;
                    Combatants.Add(new Combatant(Name, checkedInitiative));
                    Name = string.Empty;
                    Initiative = null;
					ErrorLabel = string.Empty;
                }
				else
				{
					//just initiative is null
					ErrorLabel = "Name good -- init bad";
					Initiative = null;
				}
				
            }
            else
            {
				if (Initiative.HasValue)
				{
                    //name is empty but init is good
                    ErrorLabel = "Name bad -- init good";
					Initiative = null;
                }
				else
				{
                    //both are bad
                    ErrorLabel = "both bad";
					Initiative = null;
                }
				
            }

            

            //sort the list
            ICollectionView view = CollectionViewSource.GetDefaultView(Combatants);
            view.SortDescriptions.Add(new SortDescription("Initiative", ListSortDirection.Descending));
			
        }

        private void RemoveCombatant()
        {
			Combatants.Remove(SelectedCombatant);
        }

        private RelayCommand clearCommand;
        public ICommand ClearCommand => clearCommand ??= new RelayCommand(Clear);

		private void Clear(object commandParameter)
		{
			Combatants.Clear();
		}
    }
}
