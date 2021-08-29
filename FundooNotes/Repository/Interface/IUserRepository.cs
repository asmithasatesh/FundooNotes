using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        bool Register(RegisterModel userData);
        public bool Login(string email, String password);
    }
}
