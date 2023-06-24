using foot2rue.BLL.Services;
using foot2rue.WF.Extensions;
using LostInLocalization;
using System.Globalization;

namespace foot2rue.WF.Settings
{
	[Flags]
	public enum SettingsDialogResult
	{
		// The values of this enum must be power of two
		// so that they can be used as flags (multiple can be used at the same time)
		None = 0,
		Cancel = 1 << 0,
		LanguageChanged = 1 << 1,
		OfflineModeChanged = 1 << 2,
		SettingsReseted = LanguageChanged | 1 << 3,

		#region Dead tree

		// Yahaha, you found me!

		#endregion
	}

	public partial class SettingsForm : Form
	{
		private SettingsService settingsService;
		private LocalizationService localizationService;

		public SettingsDialogResult SettingsDialogResult { get; private set; }

		public SettingsForm()
		{
			settingsService = SettingsService.Instance;
			localizationService = LocalizationService.Instance;
			InitializeComponent();
		}

		private void Init()
		{
			comboBox_LanguageSelection.LoadLanguageSelection();
			checkBox_OfflineModeSelection.Checked = settingsService.OfflineMode;
		}

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			Init();
			// This needs to be set after loading the languages because otherwise index changed sets it back to true everytime
			SettingsDialogResult = SettingsDialogResult.None;
		}

		private void comboBox_LanguageSelection_SelectedIndexChanged(object sender, EventArgs e)
		{
			SettingsDialogResult |= SettingsDialogResult.LanguageChanged;
			this.LoadLocalization((CultureInfo)comboBox_LanguageSelection.SelectedItem);
		}

		private void checkBox_OfflineModeSelection_CheckedChanged(object sender, EventArgs e)
		{
			SettingsDialogResult |= SettingsDialogResult.OfflineModeChanged;
		}

		private void buttonResetSettings_Click(object sender, EventArgs e)
		{
			// You can't cancel a reset
			button_Cancel.Disable();
			settingsService.ResetSettings();
			settingsService.SaveSettings();
			this.InitialSetup(settingsService);
			SettingsDialogResult |= SettingsDialogResult.SettingsReseted;
			Close();
		}

		private void button_Save_Click(object sender, EventArgs e)
		{
			if (SettingsDialogResult.HasFlag(SettingsDialogResult.LanguageChanged))
			{
				CultureInfo culture = comboBox_LanguageSelection.GetSelectedItem<CultureInfo>();
				settingsService.Culture = culture;
				localizationService.Culture = culture;
			}
			if (SettingsDialogResult.HasFlag(SettingsDialogResult.OfflineModeChanged))
				settingsService.OfflineMode = checkBox_OfflineModeSelection.Checked;

			// No need to do anything if settings have been reseted since it already modified these changes

			settingsService.SaveSettings();
			Close();
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			SettingsDialogResult = SettingsDialogResult.Cancel;
			Close();
		}
	}
}
