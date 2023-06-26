using foot2rue.BLL.Services;
using foot2rue.WF.MessageBoxes;

namespace foot2rue.WF.Extensions
{
	internal static class FormExtensions
	{
		private const string INITIALSETUPFAILURELOCALIZATIONSTRING = "{InitialSetupFailure}";

		public static void InitialSetup(this Form form, SettingsService settingsService)
		{
			Form initialSetupForm = new InitialSetupForm() { Parent = form };
			// We need to use ShowDialog to make sure that the initial setup is done before the user can interact with this form
			DialogResult dialogResult = initialSetupForm.ShowDialog();
			// We then check if the setup was succesful
			// Could have failed if the user forcefully close the form for example
			if (dialogResult != DialogResult.OK)
			{
				// TODO Do this form
				new ErrorForm(INITIALSETUPFAILURELOCALIZATIONSTRING).ShowDialog();
				// Force quit
				Application.Exit();
			}
			settingsService.SaveSettings();
		}
	}
}
