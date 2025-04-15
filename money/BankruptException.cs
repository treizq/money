using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace money
{
    public class BankruptException : Exception
    {
        public BankruptException(string message) : base(message) { }
    }
}
