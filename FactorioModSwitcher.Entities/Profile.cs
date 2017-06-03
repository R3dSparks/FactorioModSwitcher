using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FactorioModSwitcher.Entities
{
    public class Profile
    {
        public ModList SerializationModList { get; set; }

        public string Name { get; set; }

        public Mod[] Mods { get => SerializationModList.mods; }

        public Profile(string name, Mod[] modList) : this(name, new ModList(modList))
        {
        }

        public Profile(string name, ModList modsInProfile)
        {
            Name = name;
            SerializationModList = modsInProfile;
        }

        public Profile GetCopy()
        {
            Mod[] modsCopy = new Mod[Mods.Length];

            for(int i = 0; i < Mods.Length; i++)
            {
                modsCopy[i] = new Mod(Mods[i].name, Mods[i].enabled);
            }

            return new Profile(Name, modsCopy);
        }
    }
}