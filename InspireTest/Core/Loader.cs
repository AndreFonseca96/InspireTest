using InspireTest.Models;

namespace InspireTest.Core
{
    public class Loader
    {
        #region Constuctor

        public Loader()
        {
        }

        #endregion

        #region Methods
        public Bomb LoadBomb()
        {
            Bomb bomb = new Bomb();

            Wire whiteWire = new Wire("Branco", new Rules(false, "Branco", "Preto"));
            Wire redWire = new Wire("Vermelho", new Rules(true, "Verde"));
            Wire blackWire = new Wire("Preto", new Rules(false, "Branco", "Verde", "Laranja"));
            Wire orangeWire = new Wire("Laranja", new Rules(true, "Vermelho", "Preto"));
            Wire greenWire = new Wire("Verde", new Rules(true, "Laranja", "Branco"));
            Wire purpleWire = new Wire("Roxo", new Rules(false, "Roxo", "Verde", "Laranja", "Branco"));

            bomb.AddWires(whiteWire, redWire, blackWire, orangeWire, greenWire, purpleWire);

            return bomb;
        }

        #endregion
    }
}
