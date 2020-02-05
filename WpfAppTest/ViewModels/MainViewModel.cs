using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            detailsViewModel = new DetailsViewModel();
            resultSetViewModel = new ResultSetViewModel();
        }

        public DetailsViewModel detailsViewModel { get; }

        public ResultSetViewModel resultSetViewModel { get; }
    }
}
