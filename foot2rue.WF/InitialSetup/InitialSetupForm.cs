using foot2rue.WF.InitialSetup;
using foot2rue.WF.Extensions;

namespace foot2rue.WF
{
	public partial class InitialSetupForm : Form
	{
		private Control? control;

		public InitialSetupForm()
		{
			InitializeComponent();
			this.LoadLocalization();
		}

		private void SetControl(Control newControl)
		{
			if (control != null)
				panel1.Controls.Remove(control);

			control = newControl;
			control.SetParent(panel1);
			control.Show();
		}

		private void InitialSetupForm_Load(object sender, EventArgs e)
		{
			SetControl(
				new LanguageSelectionUserControl(OnLanguageValidation)
				{
					Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left,
					Dock = DockStyle.Fill,
				});
			Size = new Size(640, 360);
			CenterToScreen();
		}

		private void OnLanguageValidation()
		{
			SetControl(
				new TeamSelectionUserControl(OnTeamValidation)
				{
					Dock = DockStyle.Fill,
				});
			CenterToScreen();
		}

		private void OnTeamValidation()
		{
			SetControl(
				new FavoritesSelectionUserControl(OnFavoritesValidation)
				{
					Dock = DockStyle.Fill,
				});
			Size = new Size(1280, 720);
			CenterToScreen();
		}

		private void OnFavoritesValidation()
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		#region Cube in the water

		// Yahaha, you found me!

		#endregion

		private void button_Quit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
