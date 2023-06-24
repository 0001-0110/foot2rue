using foot2rue.WPF.Extensions;
using System.Windows;
namespace foot2rue.WPF.Settings
{
	/// <summary>
	/// Interaction logic for SettingsWindow.xaml
	/// </summary>
	public partial class SettingsWindow : Window
	{
		public SettingsWindow()
		{
			InitializeComponent();
			this.LoadLocalization();
		}
	}
}
