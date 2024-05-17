using CommunityToolkit.Mvvm.Input;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobive2CreativeProj.ViewModels
{
    /// <summary>
    ///  This is our ViewModel for the first page
    /// </summary>
    public partial class RestaurantSelectionViewModel: PageViewModelBase
    {
        public RestaurantSelectionViewModel()
        {
            Debug.WriteLine("RestaurantSelectionViewModel call success");
        }

        private PageViewModelBase _CurrentPage;

        /// <summary>
        /// Gets the current page. The property is read-only
        /// </summary>
        public PageViewModelBase CurrentPage
        {
            get { return _CurrentPage; }
            private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
        }

        [RelayCommand]
        public void BoardingRestaranPage()
        {
            CurrentPage = new BoardingRastaranViewModel();
        }

        // This is our first page, so we can navigate to the next page in any case
        public override bool CanNavigateNext
        {
            get => true;
            protected set => throw new NotSupportedException();
        }

        // You cannot go back from this page
        public override bool CanNavigatePrevious
        {
            get => false;
            protected set => throw new NotSupportedException();
        }
    }
}
