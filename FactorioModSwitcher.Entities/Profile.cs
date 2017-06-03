using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FactorioModSwitcher.Entities
{
    public class Profile
    {
        public string Name { get; set; }

        public Mod[] Mods { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Profile(string name, ModList modsInProfile)
        {
            Name = name;
            Mods = modsInProfile.mods;
        }
    }
}