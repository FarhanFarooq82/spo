using System.Collections.ObjectModel;
using BeoRecruitment.Services;

namespace BeoRecruitment.ViewModels
{
    public class SearchResultViewModel : INavigationParameter<string>
    {
        private readonly ISpotifyService _spotifyService;

        public SearchResultViewModel(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
            ArtistsNames = new ObservableCollection<string>();
        }

        public ObservableCollection<string> ArtistsNames { get; }

        private async Task SearchArtistsAsync(string artistName)
        {
            if (string.IsNullOrWhiteSpace(artistName)) return;

            try
            {
                var results = await _spotifyService.SearchArtistsAsync(artistName);
                foreach (var artist in results)
                {
                    ArtistsNames.Add(artist.Name);
                }
            }
            finally
            { }
        }


        #region INavigationParameter<int>


        void INavigationParameter<string>.SetParameter(string? parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                _ = SearchArtistsAsync(parameter);
            }
        }

        #endregion

    }
}

