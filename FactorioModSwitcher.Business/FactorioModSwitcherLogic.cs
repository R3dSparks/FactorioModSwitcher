using FactorioModSwitcher.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioModSwitcher.Business
{
    public class FactorioModSwitcherLogic
    {

        private ModList m_availableMods;

        private List<Profile> m_profiles;

        /// <summary>
        /// Path to Factorio mod list in AppData
        /// </summary>
        private string m_pathToModList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Factorio\mods\mod-list.json");

        /// <summary>
        /// Path to profile folder inside Factorio mods folder
        /// </summary>
        private string m_pathToProfileFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Factorio\mods\profiles");

        public ModList MyProperty
        {
            get
            {
                if (m_availableMods == null)
                    m_availableMods = JsonConverter.Deserialize<ModList>(m_pathToModList);

                return m_availableMods;
            }
        }

        public List<Profile> Profiles
        {
            get
            {
                if (m_profiles == null)
                    m_profiles = readProfiles();

                return m_profiles;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public FactorioModSwitcherLogic()
        {

        }

        private List<Profile> readProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            if (Directory.Exists(m_pathToProfileFolder) == false)
            {
                string temp = Path.GetDirectoryName(m_pathToProfileFolder);
                Directory.CreateDirectory(m_pathToProfileFolder);
            }

            foreach (string path in Directory.GetFiles(m_pathToProfileFolder))
            {
                profiles.Add(new Profile(Path.GetFileNameWithoutExtension(path), JsonConverter.Deserialize<ModList>(path)));
            }

            return profiles;
        }

        public void SwitchProfile(Profile profile)
        {
            JsonConverter.Serialize(profile.Mods, m_pathToModList);
        }


    }
}
