using foot2rue.WPF.Extensions;
using System.Windows;

namespace foot2rue.WPF.Main
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.LoadLocalization();
		}
	}
}
