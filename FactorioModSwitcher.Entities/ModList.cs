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

        public ModList GetCopy()
        {
            Mod[] modsCopy = new Mod[mods.Length];

            for (int i = 0; i < mods.Length; i++)
            {
                modsCopy[i] = new Mod(mods[i].name, mods[i].enabled);
            }

            return new ModList(modsCopy);
        }
    }
}
