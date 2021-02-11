using System.Collections.Generic;
using Prism.Events;
using TaskListV2.UI.Data;
using TaskListV2.UI.Event;

namespace TaskListV2.UI.ViewModel
{
    public class MenuColumnViewModel : ViewModelBase, IMenuColumnViewModel
    {
        private string _selectedItem;

        public IEnumerable<string> MenuItems { get; set; }

        private IEventAggregator _eventAggregator;

        public MenuColumnViewModel(IEventAggregator eventAggregator)
        {

            MenuItems = TaskListV2DataService.LeftMenuItems;
            _eventAggregator = eventAggregator;
        }

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (_selectedItem != null)
                {
                    _eventAggregator.GetEvent<SelectedMenuItemEvent>().Publish(_selectedItem);
                }
            }
        }
    }
}
