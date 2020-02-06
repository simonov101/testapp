using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.Models
{
    public class CardholderOrm
    {
        public CardholderOrm()
        {           
        }

        public virtual int? Id { get; set; }

        public virtual string Firstname { get; set; }

        public virtual string Lastname { get; set; }
        public virtual DateTime Birthday { get; set; }
        public virtual string Company { get; set; }

        //[ContractInvariantMethod]
        //private void ValidateInvariants()
        //{
        //    Contract.Invariant(Firstname == "Mohamed");
        //}
    }
}
