using foot2rue.WPF.Extensions;
using System.Windows;

namespace foot2rue.WPF.MessageBoxes
{
    public partial class ErrorWindow : Window
	{
		private const string DEFAULTERROR = "Error";

		public ErrorWindow() : this(DEFAULTERROR) { }

		public ErrorWindow(string errorLocalizationString)
		{
			InitializeComponent();
			Label_Error.SetLocalizationString(errorLocalizationString);
		}
	}
}
