using Xamarin.Forms;
using ConEd.PAP.ViewModels;
using PCLStorage;
using System;

namespace ConEd.PAP.Views
{
    public partial class ViewDocument : ContentPage
    {
        void Cwv_Navigated(object sender, WebNavigatedEventArgs e)
        {
            //activityIndicator Stop
        }

        void Cwv_Navigating(object sender, WebNavigatingEventArgs e)
        {
            //Activitiindicator Start
        }

        private string _selectedDocName;
        public string SelectedDocName
        {
            get { return _selectedDocName; }
            set
            {
                if (_selectedDocName != value)
                {
                    _selectedDocName = value;
                    OnPropertyChanged();
                }
            }
        }
		private bool _isFavorite;
		public bool IsFavorite
		{
			get { return _isFavorite; }
			set
			{
				if (_isFavorite != value)
				{
					_isFavorite = value;
					OnPropertyChanged();
				}
			}
		}
        public ViewDocument(string DocName, bool IsFavorite)
        {
            
            InitializeComponent();

			TapGestureRecognizer _norefgesture = new TapGestureRecognizer();
			_norefgesture.Tapped += async (object sender1, EventArgs e2) =>
				{
					btnViewFav.Image = "fav_gray.png";


					var check = await FileSystem.Current.LocalStorage.CheckExistsAsync(this.SelectedDocName);
					if (ExistenceCheckResult.FileExists == check)
					{
						App.PoliciesRepo.UpdateFavorites(this.SelectedDocName, "0");
						IFile file = await FileSystem.Current.LocalStorage.GetFileAsync(this.SelectedDocName);
						await file.DeleteAsync();
					}
					IsFavorite = false;

				};
			nobtnRef.GestureRecognizers.Add(_norefgesture);
            _norefgesture.NumberOfTapsRequired = 1;

			TapGestureRecognizer _yesrefgesture = new TapGestureRecognizer();
			_yesrefgesture.Tapped += (object sender1, EventArgs e2) =>
				{
					btnViewFav.Image = "fav_selected.png";
					App.PoliciesRepo.UpdateFavorites(this.SelectedDocName, "1");
					IsFavorite = true;
					ViewDocumentViewModel vdv = new ViewDocumentViewModel();
					vdv.viewDocument(this.SelectedDocName);
				};
			yesbtnref.GestureRecognizers.Add(_yesrefgesture);
            _yesrefgesture.NumberOfTapsRequired = 1;

            cwv.Navigating += Cwv_Navigating;
            cwv.Navigated += Cwv_Navigated;
            this.Title = "Policies and procedures";
           // NavigationPage.SetHasNavigationBar(this, false);
           // actIndicator.IsVisible = true;
            ViewDocumentViewModel vdm = new ViewDocumentViewModel();
            vdm.viewDocument(DocName);
            
            cwv.Uri = DocName;// "BookPreview2-Ch18-Rel0417.pdf";            
            this.SelectedDocName = DocName;
           // actIndicator.IsVisible = false;

            btnBackB.Clicked += (sender, e) => {
                Navigation.PopAsync();
            };

		}



        /// <summary>
        /// Back button click event
        /// </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        //private void btnBack_Clicked(object sender, System.EventArgs e)
        //{            
        //    DocumentDetails dd = new DocumentDetails();
        //    //DDE dd = new DDE();
        //    Label lblTitle = dd.FindByName<Label>("lblDDTitle");
        //    //lblTitle.Text = "CEHSP";
        //    lblTitle.Text = "lblDDTitle";
        //    Navigation.PushAsync(dd);
        //    dd = null;

        //    lblTitle = null;
        
        //}

        /// <summary>
        /// on Screen disappearing closing the pdf document
        /// </summary>
        protected override async void OnDisappearing()
        {            
            bool isFavorite = App.PoliciesRepo.IsFavorite(this.SelectedDocName);
            if (!isFavorite)
            {
                var check = await FileSystem.Current.LocalStorage.CheckExistsAsync(this.SelectedDocName);
                if (ExistenceCheckResult.FileExists == check)
                {
                    IFile file = await FileSystem.Current.LocalStorage.GetFileAsync(this.SelectedDocName);
                    await file.DeleteAsync();

                }
            }
        }
		public string selectedDocName = string.Empty;

		private async void btnViewFav_Clicked(object sender, System.EventArgs e)
		{
			Button btnf = this.FindByName<Button>("btnViewFav");
			activityIndicatorLayout.IsVisible = true;

			
			//var answer = await DisplayAlert("", "Would like to mark as favourite", "Yes", "No");
			//if (answer)
			//{

			//	btnf.Image = "fav_selected.png";

			//	App.PoliciesRepo.UpdateFavorites(this.SelectedDocName, "1");
			//	IsFavorite = true;
			//	ViewDocumentViewModel vdv = new ViewDocumentViewModel();
			//	vdv.viewDocument(this.SelectedDocName);

			//}
			//else
			//{
			//	btnf.Image = "fav-unselected.png";


			//	var check = await FileSystem.Current.LocalStorage.CheckExistsAsync(this.SelectedDocName);
			//	if (ExistenceCheckResult.FileExists == check)
			//	{
			//		App.PoliciesRepo.UpdateFavorites(this.SelectedDocName, "0");
			//		IFile file = await FileSystem.Current.LocalStorage.GetFileAsync(this.SelectedDocName);
			//		await file.DeleteAsync();
			//	}
			//	IsFavorite = false;
			//}

		}



		//private void btnBackB_Clicked_1(object sender, System.EventArgs e)
		//{
		//	DDE dd = new DDE();
		//	Navigation.PushAsync(dd);
		//	dd = null;
		//}
    }
}
