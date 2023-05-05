using foot2rue.WF.Models;

namespace foot2rue.WF.HomePage
{
    public partial class PlayerDisplayUserControl : UserControl
    {
        public PlayerDisplayUserControl(Player player)
        {
            InitializeComponent();

            pictureBox_PlayerPicture.Image = player.Image;
            pictureBox_Favorite.Visible = player.IsFavorite;
            label_FullName.Text = player.Name;
            label_GoalCount.Text = player.Goals.ToString();
            label_YellowCardsCount.Text = player.YellowCards.ToString();
        }
    }
}
