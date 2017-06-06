using FactorioModSwitcher.Data;
using FactorioModSwitcher.Entities;
using Newtonsoft.Json;
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



        public ModList AvailableMods
        {
            get
            {
                if (m_availableMods == null)
                    m_availableMods = DataHelper.LoadModList();

                return m_availableMods;
            }
        }

        public ObservableCollection<Profile> Profiles
        {
            get
            {
                if (m_profiles == null)
                    m_profiles = new ObservableCollection<Profile>(DataHelper.LoadProfiles());

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
            DataHelper.SaveProfile(profile);
        }

        /// <summary>
        /// Delete profile from profile list and remove its file
        /// </summary>
        /// <param name="profile"><see cref="Profile"/> to delete</param>
        public void DeleteProfile(Profile profile)
        {
            Profiles.Remove(profile);
            DataHelper.DeleteProfile(profile);
        }

        public ModList GetModListFromString(string profileString)
        {
            return JsonConvert.DeserializeObject<ModList>(profileString);
        }

        public string GetProfileString(Profile profile)
        {
            return JsonConvert.SerializeObject(profile.SerializationModList);
        }
    }
}
