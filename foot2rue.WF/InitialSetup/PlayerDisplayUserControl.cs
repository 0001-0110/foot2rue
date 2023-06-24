﻿using foot2rue.BLL.Models;
using foot2rue.WF.Extensions;
using foot2rue.WF.Utilities;

namespace foot2rue.WF.InitialSetup
{
	public partial class PlayerDisplayUserControl : UserControl
	{
		public Player Player { get; private set; }

		public PlayerDisplayUserControl(Player player)
		{
			Player = player;
			InitializeComponent();

			pictureBox_PlayerPicture.Image = ResourcesUtility.GetPlayerImage(player);
			label_PlayerName.SetLocalizationString(player.Name);

			this.LoadLocalization();
		}
	}
}
