using System.Collections.Generic;
using System.Linq;

namespace InspireTest.Models
{
    public class Rules
    {

        #region Properties

        public List<Color> Colors { get; set; }

        public bool Allowed { get; set; }

        #endregion

        #region Constructors

        public Rules(bool allowed, params string[] ruleColors)
        {
            Allowed = allowed;
            Colors = new List<Color>();

            foreach (string colorName in ruleColors)
            {
                Colors.Add(new Color(colorName));
            }
        }

        #endregion

        #region Methods

        public bool ValidateRule(string wireColor)
        {
            if (Allowed) // The wire(s) must be cut
            {
                if (!Colors.Any(c => c.Name == wireColor)) // If the wire is not on the rules
                {
                    return true; // Explodes
                }
            }
            else // The wire(s) cannot be Cut
            {
                if (Colors.Any(c => c.Name == wireColor)) // If the wire is on the rules
                {
                    return true; // Explodes
                }
            }

            return false; // Rule matched
        }

        public override string ToString()
        {
            string output = "\n";

            if(Colors.Count > 0)
            {
                if (Allowed)
                {
                    output += "\t\tTem de ser cortado um fio da cor:";
                }
                else
                {
                    output += "\t\tNão pode ser cortado um fio da cor:";
                }

                foreach (Color color in Colors)
                {
                    output += "\n \t\t" + color.Name; 
                }
            }
            return output;
        }

        #endregion
    }
}
