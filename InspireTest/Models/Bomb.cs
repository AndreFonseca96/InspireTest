using System;
using System.Collections.Generic;
using System.Linq;

namespace InspireTest.Models
{
    public class Bomb
    {
        #region Properties

        public List<Wire> Wires { get; set; }

        #endregion

        #region Constructor

        public Bomb()
        {
            Wires = new List<Wire>();
        }

        #endregion

        #region Methods

        public void AddWire (Wire wire)
        {
            Wires.Add(wire);
        }

        public void AddWires(params Wire[] wires)
        {
            foreach (Wire wire in wires)
            {
                AddWire(wire);
            }
        }

        public Wire GetWire(string wireColor)
        {
            return Wires.Find(w => w.Color.Name.ToUpper() == wireColor.ToUpper());
        }

        public bool WireExists(string wireColor)
        {
            if (Wires.Any(w => w.Color.Name.Equals(wireColor, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string output = "\nFios: \n";

            foreach (Wire wire in Wires)
            {
                output += "\n "+ wire.ToString();
            }
            return output;
        }

        #endregion
    }
}
