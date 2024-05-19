using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBank_Engle
{
    public class Bank
    {
        private decimal _vault = 10000;
        private string[,] _users = new string[4, 3]
        {
            {"jlennon", "johnny", "1250" },
            {"pmccartney", "pauly", "2500" },
            {"gharrison", "georgy", "3000" },
            {"rstarr", "ringoy", "1001"}
        };
        public decimal BankBalance
        {
            get { return _vault; }
        }

    }
}
