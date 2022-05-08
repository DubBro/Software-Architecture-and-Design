using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA_lab1._2_1._3
{
    class Account : IAccount
    {
        public bool LogIn(string nickname, string password)
        {
            // Entering to account: hashing password, finding data in the DB
            // If date is existed, return true. Else - return false
            // Hard code is using as example
            if (nickname == "admin" && password == "admin")
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
