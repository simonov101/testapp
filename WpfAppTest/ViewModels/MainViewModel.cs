using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel(DetailsViewModel detailsViewModel, ResultSetViewModel resultSetViewModel)
        {
            this.detailsViewModel = detailsViewModel;
            this.resultSetViewModel = resultSetViewModel;
        }

        public DetailsViewModel detailsViewModel { get; }

        public ResultSetViewModel resultSetViewModel { get; }
    }
}
