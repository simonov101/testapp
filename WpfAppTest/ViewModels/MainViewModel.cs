using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Models;

namespace WpfAppTest.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel(DetailsViewModel detailsViewModel, ResultSetViewModel resultSetViewModel)
        {
            //Contract.Requires<ArgumentNullException>(detailsViewModel != null);
            //Contract.Requires<ArgumentNullException>(resultSetViewModel != null);
            //Contract.Ensures(this.detailsViewModel == detailsViewModel);
            this.detailsViewModel = detailsViewModel;
            this.resultSetViewModel = resultSetViewModel;
            this.resultSetViewModel.OnParameterChange += detailsViewModel_OnParameterChange;
        }

        public DetailsViewModel detailsViewModel { get; }

        public ResultSetViewModel resultSetViewModel { get; }

        //private void ValidateInvariants()
        //{
        //    Contract.Invariant(detailsViewModel != null);
        //}
        public void detailsViewModel_OnParameterChange(Cardholder cardholder)
        {
            detailsViewModel.Cardholder = cardholder;
        }
    }
}
