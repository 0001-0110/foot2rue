using foot2rue.DAL.Models;
using foot2rue.WPF.Extensions;
using foot2rue.WPF.Utilities;
using System.Windows.Controls;

namespace foot2rue.WPF.Main
{
    public partial class EventUserControl : UserControl
    {
        public EventUserControl(Event @event)
        {
            InitializeComponent();

            // TODO
            //Image_EventIcon.Source = ResourcesUtility.GetEventIcon(thing.Type);
            Label_EventName.SetLocalizationString($"{{{@event.Type}}}");
            Label_PlayerName.SetLocalizationString(@event.Player);
            Label_Time.SetLocalizationString(@event.Time);

            this.LoadLocalization();
        }
    }
}
