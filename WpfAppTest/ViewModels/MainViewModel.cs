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
        public MainViewModel()
        {
            
            //Contract.Ensures(this.detailsViewModel == detailsViewModel);
            detailsViewModel = new DetailsViewModel();
            resultSetViewModel = new ResultSetViewModel();
            //Contract.Requires<ArgumentNullException>(detailsViewModel != null);
            //Contract.Requires<ArgumentNullException>(resultSetViewModel != null);
            resultSetViewModel.SelectedCardholderChanged += OnSelectedCardholderChanged;
        }

        public DetailsViewModel detailsViewModel { get; }

        public ResultSetViewModel resultSetViewModel { get; }

        //private void ValidateInvariants()
        //{
        //    Contract.Invariant(detailsViewModel != null);
        //}
        private void OnSelectedCardholderChanged(object sender, EventArgs e)
        {
            detailsViewModel.Cardholder = resultSetViewModel.SelectedCardholder;
        }
    }
}
