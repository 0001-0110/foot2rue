﻿using static foot2rue.WF.Properties.Settings;
using foot2rue.DAL.Repositories;
using System.Globalization;

namespace foot2rue.WF
{
    internal class SettingsService
    {
        // Eager singleton since this is always gonna be needed
        public static SettingsService Instance = new SettingsService();

        public Genre SelectedGenre
        {
            get { return (Genre)Default.SelectedGenre; }
            set { Default.SelectedGenre = (int)value; }
        }

        public string SelectedTeamFifaCode
        {
            get { return Default.SelectedTeamFifaCode; }
            set { Default.SelectedTeamFifaCode = value; }
        }

        public bool OfflineMode
        {
            get { return Default.OfflineMode; }
            set { Default.OfflineMode = value; }
        }

        public CultureInfo Culture
        {
            get { return new CultureInfo(Default.CultureLCID); }
            set { Default.CultureLCID = value.LCID; }
        }

        private SettingsService() 
        {
#if DEBUG
            Default.Reset();
#endif
        }

        public void Save()
        {
            Default.Save();
        }
    }
}
