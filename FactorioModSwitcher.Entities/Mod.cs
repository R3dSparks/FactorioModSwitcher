using System.ComponentModel;

namespace FactorioModSwitcher.Entities
{
    /// <summary>
    /// Class for Json deserialization
    /// </summary>
    public class Mod
    {
        public string name { get; set; }
        public bool enabled { get; set; }
    }
}
