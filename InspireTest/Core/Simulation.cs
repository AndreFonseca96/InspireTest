using InspireTest.Models;

namespace InspireTest.Core
{
    public class Simulation
    {

        #region Properties

        public Bomb Bomb { get; set; }

        public string UserInput { get; set; }

        #endregion

        #region Constructors

        public Simulation(Bomb bomb, string userInput)
        {
            Bomb = bomb;
            UserInput = userInput;
        }

        #endregion

        #region Methods

        public bool Simulate()
        {
            Wire prevWire = null;
            Wire currentWire;

            UserInput = UserInput.Replace(" ", string.Empty);

            string[] inputSub = UserInput.Split(",");

            foreach (string entry in inputSub)
            {
                if (prevWire is null)
                {
                    prevWire = Bomb.GetWire(entry); //Get the respective wire based on input
                }
                else
                {
                    currentWire = Bomb.GetWire(entry); //Get the respective wire based on input

                    if (prevWire.Rules.ValidateRule(currentWire.Color.Name)) //Validates if a rule from the previous wire has been broken
                    {
                        return true; // Bomb explodes
                    }
                    prevWire = currentWire;
                }
            }

            return false; // Bomb disarmed
        }

        #endregion
    }
}
