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
        private int _loggedIn=5;
        private string[,] _users = new string[4, 3]
        {
            {"jlennon", "johnny", "1250" },
            {"pmccartney", "pauly", "2500" },
            {"gharrison", "georgy", "3000" },
            {"rstarr", "ringoy", "1001"}
        };
        public string LogIn(string username, string password)
        {
            for (int i = 0; i < 4; i++)
            {
                if (username == _users[i, 0] && password == _users[i, 1])
                {
                    _loggedIn = i;
                    return username;
                }
            }
            _loggedIn=5;
            return "Invalid credentials\n";
        }
        public string Balance
        {
            get { return "Remaining balance: " + decimal.Parse(_users[_loggedIn, 2]).ToString("c") + "\n"; }
        }
        public string Deposit(string value)
        {
            _users[_loggedIn, 2] = (decimal.Parse(_users[_loggedIn, 2]) + decimal.Parse(value)).ToString();
            _vault += decimal.Parse(value);
            return ("Successfully deposited " + decimal.Parse(value).ToString("c") + "\n");
        }
        public string Withdraw(string value)
        {
            string capped = string.Empty;
            if (decimal.Parse(value) > 500m)
            {
                value = "500";
                capped = "Withdraw limit $500.\n";
            }
            if(decimal.Parse(value) > decimal.Parse(_users[_loggedIn, 2]))
            {
                value = _users[_loggedIn, 2];
                capped += "Withdraw exceeds reamaining balance.\n";
            }
            _users[_loggedIn, 2] = (decimal.Parse(_users[_loggedIn, 2]) - decimal.Parse(value)).ToString();
            _vault -= decimal.Parse(value);
            return capped + "You successfully withdrew " + decimal.Parse(value).ToString("c") + "\n";
        }


        public string LoggedIn()
        {
            return _users[_loggedIn, 0];
        }
        public decimal BankBalance
        {
            get { return _vault; }
        }
    }
}
