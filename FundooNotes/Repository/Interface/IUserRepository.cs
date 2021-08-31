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
        /// <summary>
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>Returns true or false</returns>
        bool Register(RegisterModel userData);

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>Returns true or false</returns>
        public bool Login(string email, string password);

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns true or false</returns>
        public bool ForgetPassword(string email);
    }
}
