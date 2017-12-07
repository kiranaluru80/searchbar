using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace SampleSearch
{
    public partial class SampleSearchPage : ContentPage
    {
        public class listviewData {
            
            public string Name { get; set; }
        }
        public List<listviewData> listObj = new List<listviewData>();

        public SampleSearchPage(string titleStr)
        {
            InitializeComponent();

            this.Title = titleStr;

            FilterRef.Clicked += (sender, e) => {
                if (searchRef.IsVisible){
                    searchRef.IsVisible = false;
                }else{
                    searchRef.IsVisible = true;
                }
            };

            searchButtonref.Clicked += (sender, e) => {
                searchRef.IsVisible = false;
            };


            entrySearchRef.TextChanged += (sender, e) => {

                Entry entryref = sender as Entry;
                Debug.WriteLine(entryref.Text);
            };

            listviewData objone = new listviewData();
            objone.Name = "Ravi";

            listviewData objTwo = new listviewData();
            objTwo.Name = "subbu";

            listviewData objthree = new listviewData();
            objthree.Name = "Rambabu";

            listviewData objFour = new listviewData();
            objFour.Name = "mahesh";

            listviewData objFive = new listviewData();
            objFive.Name = "suhasini";

            listviewData objSix = new listviewData();
            objSix.Name = "bujji";

            listviewData objSeven = new listviewData();
            objSeven.Name = "Sample";

            listviewData objEight = new listviewData();
            objEight.Name = "kadali";

            listObj.Add(objone);
            listObj.Add(objTwo);
            listObj.Add(objthree);
            listObj.Add(objFour);
            listObj.Add(objFive);
            listObj.Add(objSix);
            listObj.Add(objSeven);
            listObj.Add(objEight);

            homeListView.ItemsSource = listObj;


        }
    }
}
