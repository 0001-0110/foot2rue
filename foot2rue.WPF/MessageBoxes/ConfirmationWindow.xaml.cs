using foot2rue.WPF.Extensions;
using System.Windows;

namespace foot2rue.WPF.MessageBoxes
{
    public partial class ConfirmationWindow : Window
	{
		private const string DEFAULTCONFIRMATIONLOCALIZATIONSTRING = "DefaultConfirmation";

		public ConfirmationWindow(string localizationString = DEFAULTCONFIRMATIONLOCALIZATIONSTRING)
		{
			InitializeComponent();

			TextBlock_Confirmation.SetLocalizationString(localizationString);

			this.LoadLocalization();
		}

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
			DialogResult = true;
        }
    }
}
