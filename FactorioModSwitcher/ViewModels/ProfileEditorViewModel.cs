using FactorioModSwitcher.Business;
using FactorioModSwitcher.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace FactorioModSwitcher.ViewModels
{
    public class ProfileEditorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Private Properties

        private FactorioModSwitcherLogic m_logic;

        private Profile m_profile;

        #endregion

        #region Public Properties

        public IEnumerable<Mod> ProfileMods
        {
            get
            {
                return m_profile.Mods.Where(mod => mod.enabled == true);
            }
        }

        public IEnumerable<Mod> AvailableMods
        {
            get
            {
                return m_profile.Mods.Where(mod => mod.enabled == false);
            }
        }

        public Mod SelectedMod { get; set; }

        public string ProfileName { get; set; }

        #endregion

        #region Commands

        private RelayCommand m_click_addMod;

        private RelayCommand m_click_removeMod;

        private RelayCommand m_click_ok;

        private RelayCommand m_click_cancel;

        public ICommand Click_Ok
        {
            get
            {
                if (m_click_ok == null)
                    m_click_ok = new RelayCommand(saveChanges);

                return m_click_ok;
            }
        }

        public ICommand Click_Cancel
        {
            get
            {
                if (m_click_cancel == null)
                    m_click_cancel = new RelayCommand(cancel);

                return m_click_cancel;
            }
        }

        public ICommand Click_AddMod
        {
            get
            {
                if (m_click_addMod == null)
                    m_click_addMod = new RelayCommand(addModToProfile);

                return m_click_addMod;
            }
        }

        public ICommand Click_RemoveMod
        {
            get
            {
                if (m_click_removeMod == null)
                    m_click_removeMod = new RelayCommand(removeModFromProfile);

                return m_click_removeMod;
            }
        }

        #endregion

        #region Constructor

        public ProfileEditorViewModel(FactorioModSwitcherLogic logic)
        {
            m_logic = logic;

            Mod[] cleanModList = new Mod[m_logic.AvailableMods.mods.Length];

            int counter = 0;

            foreach (Mod mod in m_logic.AvailableMods.mods)
            {
                Mod cleanMod = new Mod()
                {
                    name = mod.name,
                    enabled = mod.name == "base" ? true : false,
                };

                cleanModList[counter] = cleanMod;

                counter++;
            }
            
            m_profile = new Profile("New Profile", cleanModList);
        }

        public ProfileEditorViewModel(FactorioModSwitcherLogic logic, Profile profile)
        {
            m_logic = logic;
            m_profile = profile;

            ProfileName = profile.Name;
        }

        #endregion

        #region Command Methods
    
        private void cancel()
        {

        }

        private void saveChanges()
        {

        }

        private void addModToProfile()
        {
            if (SelectedMod.enabled == false)
            {
                m_profile.Mods.FirstOrDefault(mod => mod.name == SelectedMod.name).enabled = true;
                PropertyChanged(this, new PropertyChangedEventArgs("ProfileMods"));
                PropertyChanged(this, new PropertyChangedEventArgs("AvailableMods"));
            }
                
        }

        private void removeModFromProfile()
        {
            if (SelectedMod.enabled == true)
            {
                m_profile.Mods.FirstOrDefault(mod => mod.name == SelectedMod.name).enabled = false;
                PropertyChanged(this, new PropertyChangedEventArgs("ProfileMods"));
                PropertyChanged(this, new PropertyChangedEventArgs("AvailableMods"));
            }
        }

        #endregion


    }
}
