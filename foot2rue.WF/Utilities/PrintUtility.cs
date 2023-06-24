namespace foot2rue.WF.Utilities
{
	internal static class PrintUtility
	{
		private static PrintPreviewDialog? _printPreviewDialog;
		private static PrintPreviewDialog PrintPreviewDialog
		{
			get
			{
				if (_printPreviewDialog == null)
					_printPreviewDialog = new PrintPreviewDialog();
				return _printPreviewDialog;
			}
			set
			{
				_printPreviewDialog = value;
			}
		}

		public static void Print()
		{
			/**
             * Print Preview Dialog and all other dialogs (like OpenFileDialog, SaveFileDialog, etc) are system dialog.
             * You can not change it using .NET Localization. It depends on the language setting of your system.
             * 
             * TODO: create a custom Print Preview Dialog Form which you can localize using .NET Localization.
             */
			PrintPreviewDialog.Show();
		}
	}
}
