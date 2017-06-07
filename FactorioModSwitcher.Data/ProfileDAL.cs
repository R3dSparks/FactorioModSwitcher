using FactorioModSwitcher.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FactorioModSwitcher.Data
{
    public static class ProfileDAL
    {
        public static bool Exists(this Profile profile)
        {
            string filePath = Path.Combine(DataHelper.PathToProfileFolder, profile.Name + ".json");

            return File.Exists(filePath);
        }

        public static void SaveProfile(Profile profile)
        {
            string jsonProfileString = JsonConvert.SerializeObject(profile.ProfileModList);

            DataHelper.SaveString(jsonProfileString, Path.Combine(DataHelper.PathToProfileFolder, profile.Name + ".json"));
        }

        public static void DeleteProfile(string name)
        {
            string filePath = Path.Combine(DataHelper.PathToProfileFolder, name + ".json");

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        /// <summary>
        /// Delete a profile file
        /// </summary>
        /// <param name="profile">The profile to delete</param>
        public static void DeleteProfile(Profile profile)
        {
            DeleteProfile(profile.Name);
        }

        /// <summary>
        /// Load all available profiles
        /// </summary>
        /// <returns>A <see cref="Profile"/> list</returns>
        public static List<Profile> LoadProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            if (Directory.Exists(DataHelper.PathToProfileFolder) == false)
            {
                Directory.CreateDirectory(DataHelper.PathToProfileFolder);
            }

            foreach (string path in Directory.GetFiles(DataHelper.PathToProfileFolder))
            {
                string jsonProfileModList = DataHelper.LoadString(path);

                profiles.Add(new Profile(Path.GetFileNameWithoutExtension(path), JsonConvert.DeserializeObject<ModList>(jsonProfileModList)));
            }

            return profiles;
        }
    }
}
