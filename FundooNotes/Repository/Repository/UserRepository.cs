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
                //Check whether data is present in userdata 
                if(userData !=null)
                {
                    //Encrypt password
                    userData.Password = EncryptPassword(userData.Password);
                    //Add data to Dbset
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

        //Encrypt password to Base 64 string
        public static string EncryptPassword(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
