using foot2rue.DAL.Models;
using foot2rue.WPF.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace foot2rue.WPF.Main
{
    public partial class FieldColumnUserControl : UserControl
    {
        public FieldColumnUserControl()
        {
            InitializeComponent();
            this.LoadLocalization();
        }

        #region Rock

        // Yahaha, you found me!

        #endregion

        public void SetPlayers(IEnumerable<Player> players)
        {
            Grid_Players.RowDefinitions.Clear();
            for (int i = 0; i< players.Count();  i++)
            {
                Grid_Players.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                PlayerFieldUserControl playerUserControl = new PlayerFieldUserControl(players.ElementAt(i));
                Grid_Players.Children.Add(playerUserControl);
                Grid.SetRow(playerUserControl, i);
            }
        }
    }
}
