using foot2rue.BLL.Models;
using foot2rue.BLL.Services;
using foot2rue.WF.Extensions;
using foot2rue.WF.Utilities;

namespace foot2rue.WF.HomePage
{
    public partial class PlayerDisplayUserControl : UserControl
	{
		private static readonly DataService dataService = new();

		private readonly PlayerCupResult player;

		public PlayerDisplayUserControl(PlayerCupResult player)
		{
			this.player = player;

			InitializeComponent();

			// We add the captain icon to the player picture to make it transparent
			pictureBox_IsCaptain.Visible = player.IsCaptain;
			pictureBox_PlayerPicture.Controls.Add(pictureBox_IsCaptain);
			// If no image available, we keep the default one
			pictureBox_PlayerPicture.Image = ResourcesUtility.GetPlayerImage(player) ?? pictureBox_PlayerPicture.Image;
			pictureBox_Favorite.Image = player.IsFavorite ? Properties.Resources.star : Properties.Resources.non_favorite;
			label_FullName.SetLocalizationString($"{player.Name} ({player.ShirtNumber})");
			label_Position.SetLocalizationString($"{{{player.Position}}}");
			label_MatchPlayed.SetLocalizationString($"{{MatchPlayed}}: {player.MatchPlayed}");
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
