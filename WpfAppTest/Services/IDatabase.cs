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
    //[ContractClass(typeof(ValidationContract))]
    public interface IDatabase
    {
        ObservableCollection<Cardholder> CardholderTable { get; set; }
        ObservableCollection<Cardholder> GetCardholders();
        void AddCardHolder(Cardholder cardholder);
        void DeleteCardHolder(Cardholder cardholder);

        void Update(Cardholder cardholder);
    }
}
