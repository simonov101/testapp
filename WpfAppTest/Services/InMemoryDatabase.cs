using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.Models;

namespace WpfAppTest.Services
{
    class InMemoryDatabase : IDatabase
    {
        private ObservableCollection<Cardholder> _cardholderTable;
        public InMemoryDatabase()
        {
            Cardholder cardholder1 = new Cardholder { Birthday = DateTime.Now, Company = "AKKA", Firstname = "Mohamed", Lastname = "Zekhnini" };
            Cardholder cardholder2 = new Cardholder { Birthday = DateTime.Now, Company = "VINCI", Firstname = "Abdel", Lastname = "Seghrouchni" };
            _cardholderTable = new ObservableCollection<Cardholder>();
            _cardholderTable.Add(cardholder1);
            _cardholderTable.Add(cardholder2);
        }

        public ObservableCollection<Cardholder> CardholderTable { get { return _cardholderTable; } set { _cardholderTable = value; } }

        public void AddCardHolder(Cardholder cardholder)
        {
            Contract.Requires(cardholder != null);
            Contract.Ensures(CardholderTable.Contains(cardholder));
            CardholderTable.Add(cardholder);
        }

        public void DeleteCardHolder(Cardholder cardholder)
        {
            Contract.Requires(CardholderTable.Contains(cardholder));
            Contract.Ensures(!CardholderTable.Contains(cardholder));
            CardholderTable.Remove(cardholder);
        }

        public ObservableCollection<Cardholder> GetCardholders()
        {
            return CardholderTable;
        }

        public void Update(Cardholder cardholder)
        {
            Cardholder cardholderToUpdate = CardholderTable.Where(c => c.Firstname == cardholder.Firstname).FirstOrDefault();
            cardholderToUpdate = cardholder;
        }
        
    }

   
}
