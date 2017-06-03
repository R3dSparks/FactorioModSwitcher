using FactorioModSwitcher.Business;
using FactorioModSwitcher.Entities;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;

namespace FactorioModSwitcher.ViewModels
{
    public class MainWindowViewModel
    {

        #region Private Properties

        private FactorioModSwitcherLogic m_logic;

        #endregion

        #region Commands

        private RelayCommand m_click_menu_newProfile;

        private RelayCommand m_click_switch;

        private RelayCommand m_click_contextMenu_edit;

        private RelayCommand m_click_contextMenu_delete;

        public ICommand Click_Menu_NewProfile
        {
            get
            {
                if (m_click_menu_newProfile == null)
                    m_click_menu_newProfile = new RelayCommand(newProfile);

                return m_click_menu_newProfile;
            }
        }

        public ICommand Click_Switch
        {
            get
            {
                if (m_click_switch == null)
                    m_click_switch = new RelayCommand(switchProfile);

                return m_click_switch;
            }
        }

        public ICommand Click_ContextMenu_Edit
        {
            get
            {
                if (m_click_contextMenu_edit == null)
                    m_click_contextMenu_edit = new RelayCommand(editProfile);

                return m_click_contextMenu_edit;
            }
        }

        public ICommand Click_ContextMenu_Delete
        {
            get
            {
                if (m_click_contextMenu_delete == null)
                    m_click_contextMenu_delete = new RelayCommand(deleteProfile);

                return m_click_contextMenu_delete;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Currently selected profile
        /// </summary>
        public Profile SelectedProfile { get; set; }

        /// <summary>
        /// List of all profiles
        /// </summary>
        public List<Profile> ProfileList
        {
            get => m_logic.Profiles;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowViewModel()
        {
            m_logic = new FactorioModSwitcherLogic();
        }

        #endregion

        #region Command Methods

        private void newProfile()
        {
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

            ProfileEditor editor = new ProfileEditor(m_logic, new Profile("New Profile", cleanModList));

            editor.ShowDialog();
        }

        /// <summary>
        /// Switch current mod list with the selected profile
        /// </summary>
        private void switchProfile()
        {
            m_logic.SwitchProfile(SelectedProfile);
        }

        private void editProfile()
        {
            ProfileEditor editor = new ProfileEditor(m_logic, SelectedProfile);

            editor.ShowDialog();
        }

        private void deleteProfile()
        {

        }

        #endregion
    }
}
