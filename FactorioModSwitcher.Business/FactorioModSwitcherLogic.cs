using FactorioModSwitcher.Data;
using FactorioModSwitcher.Entities;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System;

namespace FactorioModSwitcher.Business
{
    public class FactorioModSwitcherLogic
    {
        private ModList m_availableMods;

        private ObservableCollection<Profile> m_profiles;



        public ModList AvailableMods
        {
            get
            {
                if (m_availableMods == null)
                {
                    m_availableMods = DataHelper.LoadModList();

                    Array.Sort(m_availableMods.mods, (x, y) => string.Compare(x.name, y.name));
                }

                return m_availableMods;
            }
        }

        public ObservableCollection<Profile> Profiles
        {
            get
            {
                if (m_profiles == null)
                {
                    List<Profile> profileList = ProfileDAL.LoadProfiles();

                    profileList.ForEach(addAvailableModsToProfile);

                    foreach (var profile in profileList)
                    {
                        Array.Sort(profile.ProfileModList.mods, (x, y) => string.Compare(x.name, y.name));
                    }
                                     
                    m_profiles = new ObservableCollection<Profile>(profileList);

                }

                return m_profiles;
            }
        }

        public IEnumerable<Mod> GetCleanModList()
        {
            foreach (var mod in AvailableMods.mods)
            {
                yield return new Mod(mod.name, false);
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FactorioModSwitcherLogic()
        {

        }

        private List<Mod> nonAvailableModsFromProfile(Profile profile)
        {

        }

        private List<Mod> nonAvailableModsInProfile(Profile profile)
        {

        }

        private void addAvailableModsToProfile(Profile profile)
        {
            profile.ProfileModList.mods = profile.ProfileModList.mods.Union(GetCleanModList(), new ModComparer()).ToArray();
        }

        public void SwitchProfile(Profile profile)
        {
            
        }

        public void AddProfile(Profile profile)
        {
            if (Profiles.Contains(profile) == false)
            {
                Profiles.Add(profile);
            }
                
        }

        /// <summary>
        /// Save profile to file
        /// </summary>
        /// <param name="profile"><see cref="Profile"/> to save</param>
        public void SaveProfile(Profile profile)
        {
            ProfileDAL.SaveProfile(profile);
        }

        /// <summary>
        /// Delete profile from profile list and remove its file
        /// </summary>
        /// <param name="profile"><see cref="Profile"/> to delete</param>
        public void DeleteProfile(Profile profile)
        {
            Profiles.Remove(profile);
            ProfileDAL.DeleteProfile(profile);
        }

        /// <summary>
        /// Convert string to <see cref="ModList"/>
        /// </summary>
        /// <param name="profileString"></param>
        /// <returns></returns>
        public ModList GetModListFromString(string profileString)
        {
            return JsonConvert.DeserializeObject<ModList>(profileString);
        }

        /// <summary>
        /// Convert <see cref="ModList"/> to string
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public string GetProfileString(Profile profile)
        {
            return JsonConvert.SerializeObject(profile.ProfileModList);
        }

        private class ModComparer : IEqualityComparer<Mod>
        {
            public bool Equals(Mod x, Mod y)
            {
                return x.name.Equals(y.name);
            }

            public int GetHashCode(Mod obj)
            {
                return obj.name.ToCharArray().Sum(c => (int)c);
            }
        }
    }
}
