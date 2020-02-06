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
    //[ContractClassFor(typeof(IDatabase))]
    //sealed class ValidationContract : IDatabase
    //{
    //    ObservableCollection<Cardholder> CardholderTable
    //    {
    //        [Pure]
    //        get
    //        {
    //            return Contract.Result<ObservableCollection<Cardholder>>();
    //        }
    //        set
    //        {
    //            Contract.Requires<ArgumentNullException>(value!=null, "CardholderTable cannot be null!!");
    //        }
    //    }

    //    public void AddCardHolder(Cardholder cardholder)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void DeleteCardHolder(Cardholder cardholder)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public ObservableCollection<Cardholder> GetCardholders()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Update(Cardholder cardholder)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    
}
