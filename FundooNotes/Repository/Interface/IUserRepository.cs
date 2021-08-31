// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Interface
{
    using System;
    using Models;

    /// <summary>
    /// Interface having method declaration for all methods implemented in User Repository
    /// </summary>
    public interface IUserRepository
    {
        bool Register(RegisterModel userData);
        public bool Login(string email, String password);
        public bool ForgetPassword(string Email);
    }
}
