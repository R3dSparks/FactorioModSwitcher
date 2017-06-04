using FactorioModSwitcher.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorioModSwitcher.Data
{
    public static class DataHelper
    {
        public static void DeleteProfile(string pathToProfiles, Profile profile)
        {

        }

        public static List<Profile> LoadProfiles(string pathToProfiles)
        {
            List<Profile> profiles = new List<Profile>();

            if (Directory.Exists(pathToProfiles) == false)
            {
                Directory.CreateDirectory(pathToProfiles);
            }

            foreach (string path in Directory.GetFiles(pathToProfiles))
            {
                profiles.Add(new Profile(Path.GetFileNameWithoutExtension(path), JsonConverter.Deserialize<ModList>(path)));
            }

            return profiles;
        }
    }
}
