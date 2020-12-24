using Prism.Events;

namespace TaskListV2.UI.Event
{
  public class SelectedMenuItemEvent : PubSubEvent<string>
  {
    public SelectedMenuItemEvent()
    {
    }
  }
}
