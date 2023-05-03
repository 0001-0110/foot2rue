using static foot2rue.WF.Properties.Settings;
using foot2rue.DAL.Repositories;
using System.Globalization;

namespace foot2rue.WF
{
    internal static class SettingsService
    {
#if DEBUG
        static SettingsService()
        {
            Default.Reset();
        }
#endif

        public static bool FirstLaunch
        {
            get { return Default.FirstLaunch; }
            set { Default.FirstLaunch = value; }
        }

        public static Genre SelectedGenre
        {
            get { return (Genre)Default.SelectedGenre; }
            set { Default.SelectedGenre = (int)value; }
        }

        public static string SelectedTeamFifaCode
        {
            get { return Default.SelectedTeamFifaCode; }
            set { Default.SelectedTeamFifaCode = value; }
        }

        public static bool OfflineMode
        {
            get { return Default.OfflineMode; }
            set { Default.OfflineMode = value; }
        }

        public static CultureInfo Culture
        {
            get { return new CultureInfo(Default.CultureLCID); }
            set { Default.CultureLCID = value.LCID; }
        }

        public static bool HasValues()
        {
            return Default.Properties.Count > 0;
        }

        public static void Save()
        {
            Default.Save();
        }
    }
}
