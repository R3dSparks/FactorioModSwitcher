using FactorioModSwitcher.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FactorioModSwitcher.Data
{
    public static class DataHelper
    {
        /// <summary>
        /// Path to Factorio mod list in AppData
        /// </summary>
        public static readonly string PathToModList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Factorio\mods\mod-list.json");

        /// <summary>
        /// Path to profile folder inside Factorio mods folder
        /// </summary>
        public static readonly string PathToProfileFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Factorio\mods\profiles");

        public static void SaveProfile(Profile profile)
        {
            string jsonProfileString = JsonConvert.SerializeObject(profile.SerializationModList);

            SaveString(jsonProfileString, Path.Combine(PathToProfileFolder, profile.Name + ".json"));
        }

        /// <summary>
        /// Load string from file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string LoadString(string path)
        {
            string data;

            using (StreamReader reader = new StreamReader(path))
            {
                data = reader.ReadToEnd();
            }

            return data;
        }

        /// <summary>
        /// Save string to file
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        public static void SaveString(string data, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(data);
            }
        }

        /// <summary>
        /// Delete a profile file
        /// </summary>
        /// <param name="profile">The profile to delete</param>
        public static void DeleteProfile(Profile profile)
        {
            string filePath = Path.Combine(PathToProfileFolder, profile.Name + ".json");

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        /// <summary>
        /// Load the current factorio mod list
        /// </summary>
        /// <returns></returns>
        public static ModList LoadModList()
        {
            string jsonModList = LoadString(PathToModList);

            return JsonConvert.DeserializeObject<ModList>(jsonModList);
        }

        /// <summary>
        /// Load all available profiles
        /// </summary>
        /// <returns>A <see cref="Profile"/> list</returns>
        public static List<Profile> LoadProfiles()
        {
            List<Profile> profiles = new List<Profile>();

            if (Directory.Exists(PathToProfileFolder) == false)
            {
                Directory.CreateDirectory(PathToProfileFolder);
            }
            
            foreach (string path in Directory.GetFiles(PathToProfileFolder))
            {
                string jsonProfileModList = LoadString(path);

                profiles.Add(new Profile(Path.GetFileNameWithoutExtension(path), JsonConvert.DeserializeObject<ModList>(jsonProfileModList)));
            }

            return profiles;
        }
    }
}
