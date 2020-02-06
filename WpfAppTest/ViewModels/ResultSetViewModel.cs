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

namespace WpfAppTest.ViewModels
{
    public class ResultSetViewModel : Screen
    {
        IDatabase inMemoryDatabase;
        private ObservableCollection<Cardholder> _cardholders;
        private Cardholder selectedCardholder;
        public ResultSetViewModel(IDatabase database)
        {
            inMemoryDatabase = database;
            SearchCommand = new DelegateCommand(OnSearch, CanSearch);
        }
        public delegate void ParameterChange(Cardholder parameter);

        public ParameterChange OnParameterChange { get; set; }

        public ICommand SearchCommand { get; }

        private void OnSearch(object parameter)
        {
            Cardholders = inMemoryDatabase.GetCardholders();
            //NotifyOfPropertyChange(() => Cardholders);
        }

        private bool CanSearch(object parameter)
        {
            return true;
        }
        public Cardholder SelectedCardholder
        {
            get
            {
                return selectedCardholder;                
            }
            set
            {
                //Contract.Requires<ArgumentException>(Cardholders)
                selectedCardholder = value;
                NotifyOfPropertyChange(() => SelectedCardholder);
                OnParameterChange?.Invoke(SelectedCardholder);
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
                _cardholders = value;
                NotifyOfPropertyChange(() => Cardholders);
            }
        }
    }
}
