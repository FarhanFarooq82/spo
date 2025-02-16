using System.Windows.Input;
using BeoRecruitment.Services;

namespace BeoRecruitment.ViewModels
{
    public class MainViewModel
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DetailsCommand = new Command(NavigateToSearchResultPage);
        }

        public ICommand DetailsCommand { get; }
        public string? SearchTerm { get; set; }

        private void NavigateToSearchResultPage()
        {
            _navigationService.NavigateToAsync<SearchResultViewModel, string>(SearchTerm);
        }
    }
}

