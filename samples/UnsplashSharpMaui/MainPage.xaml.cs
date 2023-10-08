using UnsplashSharp;
using UnsplashSharp.Models.Enums;
using UnsplashSharp.Models;

namespace UnsplashSharpMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly IUnsplashService _unsplashService;

        public MainPage()
        {
            InitializeComponent();

            _unsplashService
                = new UnsplashService("UNSPLASHAPIKEY");
        }

        private async void SearchButtonOnClicked(object sender, EventArgs e)
        {
            List<Photo> photos = await _unsplashService.SearchPhotosAsync(SearchPhotoEntry.Text, perPage: 30, orientation: Orientation.Squarish);
            SearchCollectionView.ItemsSource = photos;
        }
    }
}