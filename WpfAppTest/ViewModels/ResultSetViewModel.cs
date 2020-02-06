using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppTest.Infrastructure;
using WpfAppTest.Models;
using WpfAppTest.Services;
using Caliburn.Micro;
using System.Diagnostics.Contracts;

namespace WpfAppTest.ViewModels
{
    internal sealed class ResultSetViewModel : Screen
    {
        #region Public

        //Constructor

        public ResultSetViewModel()
        {
            inMemoryDatabase = new InMemoryDatabase();
            SearchCommand = new DelegateCommand(OnSearch, CanSearch);
        }


        // Events

        public event EventHandler<EventArgs> SelectedCardholderChanged;


        // Properties        

        public ICommand SearchCommand { get; }

        public Cardholder SelectedCardholder
        {
            get
            {
                return selectedCardholder;
            }
            set
            {
                //Contract.Requires<ArgumentException>(!(Cardholders.Contains(SelectedCardholder)));
                selectedCardholder = value;
                NotifyOfPropertyChange(() => SelectedCardholder);
                SelectedCardholderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public ObservableCollection<Cardholder> Cardholders
        {
            get
            {
                return _cardholders;
            }
            set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                _cardholders = value;
                NotifyOfPropertyChange(() => Cardholders);
            }
        }

        #endregion


        #region Private 

        //Methods

        private void OnSearch(object parameter)
        {
            Cardholders = inMemoryDatabase.GetCardholders();
            //NotifyOfPropertyChange(() => Cardholders);
        }

        private bool CanSearch(object parameter)
        {
            return true;
        }


        //Fields

        private readonly IDatabase inMemoryDatabase;

        private ObservableCollection<Cardholder> _cardholders;

        private Cardholder selectedCardholder;

        #endregion 
    }
}
