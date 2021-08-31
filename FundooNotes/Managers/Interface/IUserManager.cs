// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Managers.Interface
{
    using Models;

    /// <summary>
    /// Contains method for User Manager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>Return true is successful</returns>
        public bool Register(RegisterModel userData);

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>Returns true if successful</returns>
        public bool Login(string email, string password);

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns true if successful</returns>
        public bool ForgetPassword(string email);
    }
}
