using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MonkeyMVVM.ViewModels
{
    class MonkeyPageViewModel:INotifyPropertyChanged
    {
      public string Name { get; set; }
      public string Details { get; set; }
      public string ImageUrl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
