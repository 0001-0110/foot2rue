using foot2rue.BLL.Models;
using foot2rue.WF.Extensions;
using foot2rue.WF.Services;

namespace foot2rue.WF.HomePage
{
    public partial class PlayerDisplayUserControl : UserControl
    {
        private static readonly DataService dataService = new DataService();

        private Player player;

        public PlayerDisplayUserControl(Player player)
        {
            this.player = player;

            InitializeComponent();

            pictureBox_IsCaptain.Visible = player.IsCaptain;
            // If no image available, we keep the default one
            if (player.Image != null)
                pictureBox_PlayerPicture.Image = player.Image;
            pictureBox_Favorite.Image = player.IsFavorite ? Properties.Resources.star : Properties.Resources.non_favorite;
            label_FullName.SetLocalizationString($"{player.Name} ({player.ShirtNumber})");
            label_Position.SetLocalizationString($"{{{player.Position}}}");
            label_GoalCount.SetLocalizationString($"{{Goals}}: {player.Goals}");
            label_YellowCardsCount.SetLocalizationString($"{{YellowCards}}: {player.YellowCards}");
            label_RedCardsCount.SetLocalizationString($"{{RedCards}}: {player.RedCards}");

            this.LoadLocalization();
        }

        private void pictureBox_Favorite_Click(object sender, EventArgs e)
        {
            ToggleFavorite();
        }

        private void ToggleFavorite()
        {
            player.IsFavorite = !player.IsFavorite;
            switch (player.IsFavorite)
            {
                case true:
                    pictureBox_Favorite.Image = Properties.Resources.star;
                    dataService.AddFavorite(player);
                    break;
                case false:
                    pictureBox_Favorite.Image = Properties.Resources.non_favorite;
                    dataService.RemoveFavorite(player);
                    break;
            }
        }
    }
}
