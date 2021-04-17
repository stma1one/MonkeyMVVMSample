using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MonkeyMVVM.ViewModels;

namespace MonkeyMVVM
{
    public partial class MainPage : ContentPage
    {
       
       

        public MainPage()
        {

            MonkeyCollectionViewModel context = new MonkeyCollectionViewModel();
            context.NavigateToPageEvent += NavigateToMonkey;
            BindingContext = context;
            InitializeComponent();
        }

        public async void NavigateToMonkey(Page p)
        {
            await Navigation.PushAsync(p);
        }
        //private async void ColView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.CurrentSelection.Count == 1)
        //    {
        //        Page p = new MonkeyPage
        //        {
        //            BindingContext = e.CurrentSelection[0]
        //        };
        //        await Navigation.PushAsync(p);
        //    }
        //}
    }
}
