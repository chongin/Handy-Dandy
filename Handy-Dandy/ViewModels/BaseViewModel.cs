using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Handy_Dandy.ViewModels
{
	public partial class BaseViewModel: ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _title;

        public BaseViewModel()
		{
            
        }
	}
}

