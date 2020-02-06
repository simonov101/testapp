using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.Models
{
    public class Cardholder
    {
        public Cardholder()
        {
            Contract.Ensures(Equals(Firstname, default(string)));
            Contract.Ensures(Equals(Lastname, default(string)));
            Contract.Ensures(Equals(Birthday, default(DateTime)));
            Contract.Ensures(Equals(Company, default(string)));
        }

        public virtual int? Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Company { get; set; }

        //[ContractInvariantMethod]
        //private void ValidateInvariants()
        //{
        //    Contract.Invariant(Firstname == "Mohamed");
        //}
    }
}
