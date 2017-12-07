using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleSearch
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();

            firstButtonref.Clicked += (sender, e) => {
                Navigation.PushAsync(new SampleSearchPage("First"));
            };

            secondButtonref.Clicked += (sender, e) => {
                Navigation.PushAsync(new SampleSearchPage("Second"));
            };

            thirdButtonRef.Clicked += (sender, e) => {
                Navigation.PushAsync(new SampleSearchPage("Third"));
            };

            fourthButtonRef.Clicked += (sender, e) => {
                Navigation.PushAsync(new SampleSearchPage("Fourth"));
            };

            fifthButtonRef.Clicked += (sender, e) => {
                Navigation.PushAsync(new SampleSearchPage("Fifth"));
            };

            sixButtonRef.Clicked += (sender, e) => {
                Navigation.PushAsync(new SampleSearchPage("Six"));
            };
        }
    }
}
