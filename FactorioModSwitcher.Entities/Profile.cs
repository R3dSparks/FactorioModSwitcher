using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FactorioModSwitcher.Entities
{
    public class Profile
    {
        public string Name { get; set; }

        public Mod[] Mods { get; set; }

        public Profile(string name, Mod[] modsInProfile)
        {
            Name = name;
            Mods = modsInProfile;
        }

        public Profile(string name, ModList modsInProfile) : this(name, modsInProfile.mods)
        {
        }
    }
}