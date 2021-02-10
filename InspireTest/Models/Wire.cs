namespace InspireTest.Models
{
    public class Wire
    {
        #region Properties

        public Color Color { get; set; }

        public Rules Rules { get; set; }

        #endregion

        #region Constructor

        public Wire(string wireColor, Rules rules)
        {
            Color = new Color(wireColor);
            Rules = rules;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return "\tCor: " + Color.Name + "\n\tRegras: " + Rules.ToString();
        }

        #endregion
    }
}
