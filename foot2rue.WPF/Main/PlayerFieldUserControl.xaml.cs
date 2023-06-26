using foot2rue.DAL.Models;
using foot2rue.WPF.Extensions;
using foot2rue.WPF.Utilities;
using System.Windows.Controls;

namespace foot2rue.WPF.Main
{
    /// <summary>
    /// Interaction logic for PlayerFieldUserControl.xaml
    /// </summary>
    public partial class PlayerFieldUserControl : UserControl
    {
        public PlayerFieldUserControl(Player player)
        {
            InitializeComponent();

            Image_Player.Source = ResourcesUtility.ConvertToWpfImage(ResourcesUtility.GetPlayerImage(player));
            Label_PlayerName.SetLocalizationString($"{player.Name} ({player.ShirtNumber})");

            this.LoadLocalization();
        }
    }
}
