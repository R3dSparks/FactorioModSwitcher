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

        public Mod()
        {

        }

        public Mod(string _name, bool _enabled)
        {
            name = _name;
            enabled = _enabled;
        }
    }
}
