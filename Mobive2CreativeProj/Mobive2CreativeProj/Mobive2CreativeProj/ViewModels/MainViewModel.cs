using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using ReactiveUI;
using System.Windows.Input;

namespace Mobive2CreativeProj.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";

        public MainViewModel()
        {
            // Set current page to first on start up
            _CurrentPage = Pages[0];

            // Create Observables which will activate to deactivate our commands based on CurrentPage state
            var canNavNext = this.WhenAnyValue(x => x.CurrentPage.CanNavigateNext);
            var canNavPrev = this.WhenAnyValue(x => x.CurrentPage.CanNavigatePrevious);

            NavigateNextCommand = ReactiveCommand.Create(NavigateNext, canNavNext);
            NavigatePreviousCommand = ReactiveCommand.Create(NavigatePrevious, canNavPrev);

            CurrentPage = new RestaurantSelectionViewModel();
        }

        #region Default page switching

        // A read.only array of possible pages
        private readonly PageViewModelBase[] Pages =
        {
            new RestaurantSelectionViewModel(),
            //new BoardingRastaranViewModel()
        };

        // The default is the first page
        private PageViewModelBase _CurrentPage;

        /// <summary>
        /// Gets the current page. The property is read-only
        /// </summary>
        public PageViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }

        /// <summary>
        /// Gets a command that navigates to the next page
        /// </summary>
        public ICommand NavigateNextCommand { get; }

        private void NavigateNext()
        {
            // get the current index and add 1
            var index = Pages.IndexOf(CurrentPage) + 1;

            //  /!\ Be aware that we have no check if the index is valid. You may want to add it on your own. /!\
            CurrentPage = Pages[index];
        }

        /// <summary>
        /// Gets a command that navigates to the previous page
        /// </summary>
        public ICommand NavigatePreviousCommand { get; }

        private void NavigatePrevious()
        {
            // get the current index and subtract 1
            var index = Pages.IndexOf(CurrentPage) - 1;

            //  /!\ Be aware that we have no check if the index is valid. You may want to add it on your own. /!\
            CurrentPage = Pages[index];
        }


        #endregion

        [RelayCommand]
        public void RestaurantSelectionPage()
        {
            CurrentPage = new RestaurantSelectionViewModel();
        }

        //private readonly PageViewModelBase
        [RelayCommand]
        public void BoardingRestaranPage()
        {
            CurrentPage = new BoardingRastaranViewModel();
        }
    }
}