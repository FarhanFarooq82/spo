using BeoRecruitment.ViewModels;

namespace BeoRecruitment.Views
{
    public class SearchResultPage : ContentPage
    {
        public SearchResultPage(SearchResultViewModel searchResultViewModel)
        {
            BindingContext = searchResultViewModel ?? throw new ArgumentNullException(nameof(searchResultViewModel));

            Title = "Artists";

            var listView = new ListView(ListViewCachingStrategy.RecycleElement);
            listView.ItemTapped += Handle_ItemTapped;

            listView.SetBinding(ListView.ItemsSourceProperty, nameof(searchResultViewModel.ArtistsNames));

            Content = listView;
        }

        private void Handle_ItemTapped(object? sender, ItemTappedEventArgs e)
        {
            // Deselect Item
            if (sender is ListView listView)
            {
                listView.SelectedItem = null;
            }

            if (e.Item is string item)
            {
                _ = DisplayAlert(item, "What an excelent choice!", "OK");
            }
        }
    }
}

