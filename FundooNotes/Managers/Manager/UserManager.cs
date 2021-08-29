using Managers.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Manager
{
    public class UserManager: IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                return this.repository.Register(userData);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
