using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MonkeyMVVM.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MonkeyMVVM.ViewModels
{
    class MonkeyCollectionViewModel:INotifyPropertyChanged
    {
        private bool isRefresh;
        public ObservableCollection<Monkey> MonkeyList { get; set; }

       

        public bool IsRefresh
        {
            get { return isRefresh; }
            set
            {
                if (isRefresh != value)
                {
                    isRefresh = value;
                    OnPropertyChanged(nameof(IsRefresh));
                }
            }
        }

        public MonkeyCollectionViewModel()
        {
            MonkeyList = new ObservableCollection<Monkey>();
          Monkeys monkeys = new Monkeys();
          foreach(Monkey m in monkeys.MonkeyList)
            {
                MonkeyList.Add(m);
            }
        }
        public ICommand RefreshCommand => new Command(Refresh);
        public ICommand DeleteCommand => new Command<Monkey>(Delete);

        public ICommand SelectionChanged => new Command<Monkey>(OnSelectionChanged);

        private void OnSelectionChanged(Monkey obj)
        {
           Page monkeyPage=new MonkeyPage();
            MonkeyPageViewModel monkeyVm = new MonkeyPageViewModel()
            {
                Name = obj.Name,
                Details = obj.Details,
                ImageUrl = obj.ImageUrl
            };

            monkeyPage.BindingContext = monkeyVm;
            monkeyPage.Title = obj.Name;
            if (NavigateToPageEvent != null)
                NavigateToPageEvent(monkeyPage);

        }
        

        private void Delete(Monkey m)
        {
            if (MonkeyList.Contains(m))
                MonkeyList.Remove(m);
        }
        
        private void Refresh()
        {
            MonkeyList.Clear();
            Monkeys monkeys = new Monkeys();
            foreach (Monkey m in monkeys.MonkeyList)
            {
                MonkeyList.Add(m);
            }
            IsRefresh = false;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Events
        public Action<Page> NavigateToPageEvent;
        #endregion
    }
}
