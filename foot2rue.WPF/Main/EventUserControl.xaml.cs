using foot2rue.DAL.Models;
using foot2rue.WPF.Extensions;
using System.Windows.Controls;

namespace foot2rue.WPF.Main
{
    public partial class EventUserControl : UserControl
    {
        public EventUserControl(Event @event)
        {
            InitializeComponent();

            // TODO

            this.LoadLocalization();
        }
    }
}
