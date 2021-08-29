using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Interface
{
    public interface IUserManager
    {
        //Interface that implements 
        public bool Register(RegisterModel userData);
        public bool Login(string email, string password);
    }
}
