using foot2rue.BLL.Extensions;
using foot2rue.BLL.Models;
using foot2rue.DAL.Repositories;
using LostInLocalization;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;

namespace foot2rue.BLL.Services
{
    public class SettingsService
	{
		private const string SETTINGSFOLDER = "foot2rue";
		private const string SETTINGSFILE = "launchsettings.json";

		public static SettingsService Instance { get; private set; }

		static SettingsService()
		{
			Instance = new SettingsService();
			// We only load this instance of the settings service
			// Do not put this in the contructor since it would be applied for instances created by json deserialization (Stack overflow)
			if (SettingsExists())
				Instance.LoadSettings();
		}

		public Genre SelectedGenre { get; set; }

		public string SelectedTeamFifaCode { get; set; }

		public StringCollection FavoritePlayers { get; set; }

		public bool OfflineMode { get; set; }

		public CultureInfo Culture { get; set; }

		public Resolution Resolution { get; set; }

		private static string GetSettingsFolder()
		{
			string appDataLocalpath = Application.LocalUserAppDataPath.Troncate("\\", -3);
			return Path.Combine(appDataLocalpath, SETTINGSFOLDER);
		}

		private static string GetSettingsPath()
		{
			return Path.Combine(GetSettingsFolder(), SETTINGSFILE);
		}

		public static bool SettingsExists()
		{
			return File.Exists(GetSettingsPath());
		}

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		private SettingsService()
		{
			// These are default values
			// The real values are going to override these one if there is any
			ResetSettings();
		}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

		public void ResetSettings()
		{
			SelectedGenre = Genre.Men;
			SelectedTeamFifaCode = "FRA";
			FavoritePlayers = new StringCollection();
			OfflineMode = false;
			Culture = LocalizationService.DefaultCulture;
			Resolution = new Resolution(800, 450);
		}

		public void LoadSettings()
		{
			if (!SettingsExists())
				return;

			SettingsService settings = JsonConvert.DeserializeObject<SettingsService>(File.ReadAllText(GetSettingsPath()))!;
			this.GetDataFrom(settings, overrideValues: true);
		}

		public void SaveSettings()
		{
			Directory.CreateDirectory(GetSettingsFolder());
			File.WriteAllText(GetSettingsPath(), JsonConvert.SerializeObject(this));
		}
	}
}
