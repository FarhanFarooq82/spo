using BeoRecruitment.ViewModels;

namespace BeoRecruitment.Views
{
    public class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            BindingContext = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));

            Title = "BnO Artist Search";

            var inputName = new Entry
            {
                Placeholder = "Enter artist name",
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
            };

            var btnSearch = new Button
            {
                Text = "Search",
                WidthRequest = 150,
                Padding = new Thickness(30, 10),
            };
            btnSearch.SetBinding(Button.CommandProperty, nameof(mainViewModel.DetailsCommand));
            inputName.SetBinding(Entry.TextProperty, nameof(mainViewModel.SearchTerm));

            Content = new StackLayout()
            {

                new Label
                {
                    Text = "Search for artists on Spotify.",
                    FontSize = 20,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Padding = new Thickness(30, 10),
                },
                inputName,
                btnSearch,
            };
        }
    }
}

