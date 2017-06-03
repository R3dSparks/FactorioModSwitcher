namespace FactorioModSwitcher.Entities
{
    /// <summary>
    /// Class for json deserialization
    /// </summary>
    public class ModList
    {
        public Mod[] mods;

        public ModList()
        {
            
        }

        public ModList(Mod[] _mods)
        {
            mods = _mods;
        }
    }
}
