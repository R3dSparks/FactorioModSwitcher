namespace FactorioModSwitcher.Business
{
    public class Profile
    {
        public string Name { get; set; }

        public ModList Mods { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Profile(string name, ModList mods)
        {
            Name = name;
            Mods = mods;
        }
    }
}