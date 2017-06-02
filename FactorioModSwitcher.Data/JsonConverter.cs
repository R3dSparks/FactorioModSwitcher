using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace FactorioModSwitcher.Data
{
    public static class JsonConverter
    {     
        public static T Deserialize<T>(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            T jsonObject;

            using (StreamReader reader = new StreamReader(path))
            {
                jsonObject = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }

            return jsonObject;
        }

        public static void Serialize(object objectToSerialize,string path)
        {         
            string output = JsonConvert.SerializeObject(objectToSerialize);

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(output);
            }
        }


    }
}
