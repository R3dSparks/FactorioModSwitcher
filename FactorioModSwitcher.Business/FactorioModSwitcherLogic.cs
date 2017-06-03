using FactorioModSwitcher.Data;
using FactorioModSwitcher.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace FactorioModSwitcher.Business
{
    public class FactorioModSwitcherLogic
    {
        private ModList m_availableMods;

        private ObservableCollection<Profile> m_profiles;

        /// <summary>
        /// Path to Factorio mod list in AppData
        /// </summary>
        private string m_pathToModList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Factorio\mods\mod-list.json");

        /// <summary>
        /// Path to profile folder inside Factorio mods folder
        /// </summary>
        private string m_pathToProfileFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Factorio\mods\profiles");

        public ModList AvailableMods
        {
            get
            {
                if (m_availableMods == null)
                    m_availableMods = JsonConverter.Deserialize<ModList>(m_pathToModList);

                return m_availableMods;
            }
        }

        public ObservableCollection<Profile> Profiles
        {
            get
            {
                if (m_profiles == null)
                    m_profiles = new ObservableCollection<Profile>(DataHelper.LoadProfiles(m_pathToProfileFolder));

                return m_profiles;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FactorioModSwitcherLogic()
        {

        }

        public void SwitchProfile(Profile profile)
        {
            JsonConverter.Serialize(profile.Mods, m_pathToModList);
        }

        public void AddProfile(Profile profile)
        {
            if (Profiles.Contains(profile) == false)
            {
                Profiles.Add(profile);
            }
                
        }

        public void SaveProfile(Profile profile)
        {
            JsonConverter.Serialize(profile.SerializationModList, Path.Combine(m_pathToProfileFolder, profile.Name + ".json"));
        }
    }
}
