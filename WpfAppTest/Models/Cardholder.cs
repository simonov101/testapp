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
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Company { get; set; }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.Firstname == "Mohamed");
        }
    }
}
