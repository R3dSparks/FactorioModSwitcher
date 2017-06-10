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
        /// Load the current factorio mod list
        /// </summary>
        /// <returns></returns>
        public static ModList LoadModList()
        {
            string jsonModList = LoadString(PathToModList);

            return JsonConvert.DeserializeObject<ModList>(jsonModList);
        }

        public static void SaveModList(ModList modList)
        {
            string jsonModList = JsonConvert.SerializeObject(modList);

            SaveString(jsonModList, PathToModList);
        }


    }
}
