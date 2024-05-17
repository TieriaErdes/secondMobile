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
    ///  This is our ViewModel for the second page
    /// </summary>
    public class BoardingRastaranViewModel: PageViewModelBase
    {
        public BoardingRastaranViewModel()
        {
            Debug.WriteLine("BoardingRastaranViewModel call success");
        }

        private bool _CanNavigateNext;

        // For this page the user can only go to the next page if all fields are valid. So we need a private setter.
        public override bool CanNavigateNext
        {
            get { return _CanNavigateNext; }
            protected set { this.RaiseAndSetIfChanged(ref _CanNavigateNext, value); }
        }

        // We allow navigate back in any case
        public override bool CanNavigatePrevious
        {
            get => true;
            protected set => throw new NotSupportedException();
        }
    }
}
