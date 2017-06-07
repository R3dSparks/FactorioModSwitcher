using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FactorioModSwitcher.Entities
{
    public class Profile
    {
        /// <summary>
        /// Name of this profile
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <see cref="ModList"/> for this profile
        /// </summary>
        public ModList ProfileModList { get; set; }


        public Profile(string name, Mod[] modList) : this(name, new ModList(modList))
        {
        }

        public Profile(string name, ModList modsInProfile)
        {
            Name = name;
            ProfileModList = modsInProfile;
        }

        /// <summary>
        /// Get a deep copy of this profile
        /// </summary>
        /// <returns></returns>
        public Profile GetCopy()
        {
            return new Profile(Name, ProfileModList.GetCopy());
        }
    }
}