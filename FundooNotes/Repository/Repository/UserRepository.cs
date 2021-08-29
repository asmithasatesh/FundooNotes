using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository
{
    public class UserRepository:IUserRepository
    {
        public readonly UserContext userContext;
        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }
        public bool Register(RegisterModel userData)
        {
            try
            {
                if(userData !=null)
                {
                    this.userContext.Users.Add(userData);
                    this.userContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
