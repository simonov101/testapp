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
        InMemoryDatabase inMemoryDatabase;
        private ObservableCollection<Cardholder> _cardholders;
        private Cardholder selectedCard;
        public ResultSetViewModel()
        {
            inMemoryDatabase = new InMemoryDatabase();
            SearchCommand = new DelegateCommand(OnSearch, CanSearch);
            SelectCommand = new DelegateCommand(OnSelect, CanSelect);
        }

        private bool CanSelect(object parameter)
        {
            return true;
        }

        private void OnSelect(object parameter)
        {
            Messenger.Default.Send<Cardholder>(SelectedCard);
        }

        public ICommand SearchCommand { get; }
        public ICommand SelectCommand { get; }

        private void OnSearch(object parameter)
        {
            Cardholders = inMemoryDatabase.GetCardholders();
            //NotifyOfPropertyChange(() => Cardholders);
        }

        private bool CanSearch(object parameter)
        {
            return true;
        }
        public Cardholder SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
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
