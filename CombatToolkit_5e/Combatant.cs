using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatToolkit_5e
{
    public class Combatant
    {
        // Instance variables (fields)
        private string name;
        private int initiative;

        // Constructor
        public Combatant(string name, int initiative)
        {
            this.name = name;
            this.initiative = initiative;
        }

        // Public properties for access
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Initiative
        {
            get { return initiative; }
            set { initiative = value; }
        }
        public override string ToString()
        {
            return name + " " + initiative.ToString();        
        }
    }
}
