using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppTest.Infrastructure;
using WpfAppTest.Models;
using WpfAppTest.Services;

namespace WpfAppTest.ViewModels
{
    class DetailsViewModel : Screen
    {
        private Cardholder _cardholder;
        private InMemoryDatabase inMemoryDatabase;
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdtaeCommand { get; set; }
        public DetailsViewModel()
        {
            inMemoryDatabase = new InMemoryDatabase();
            AddCommand = new DelegateCommand(Add, CanAdd);
            UpdtaeCommand = new DelegateCommand(Update, CanUpdate);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        private bool CanUpdate(object obj)
        {
            throw new NotImplementedException();
        }

        private void Update(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanDelete(object parameter)
        {
            return true;
        }

        private void Delete(object parameter)
        {
            inMemoryDatabase.DeleteCardHolder(Cardholder);
        }

        private bool CanAdd(object parameter)
        {
            return true;
        }

        private void Add(object parameter)
        {
            inMemoryDatabase.AddCardHolder(Cardholder);
        }

        public Cardholder Cardholder
        {
            get { return _cardholder; }
            set
            {
                _cardholder = value;
                NotifyOfPropertyChange(() => Cardholder);
            }
        }


    }
}
