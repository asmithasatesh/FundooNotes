// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Dandge Arti Subhash"/>
// ----------------------------------------------------------------------------------------------------------
namespace Managers.Manager
{
    using System;
    using Managers.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// IManager methods are defined in User Manager
    /// </summary>
    /// <seealso cref="Managers.Interface.IUserManager" />
    public class UserManager : IUserManager
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IUserRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Registers the specified user data.
        /// </summary>
        /// <param name="userData">The user data.</param>
        /// <returns>
        /// Return true is successful
        /// </returns>
        /// <exception cref="System.Exception">Throw exception</exception>
        public string Register(RegisterModel userData)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.Register(userData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// Returns true if successful
        /// </returns>
        /// <exception cref="System.Exception">Throw exception</exception>
        public RegisterModel Login(string email, string password)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.Login(email, password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// Returns true if successful
        /// </returns>
        /// <exception cref="System.Exception">Throw exception</exception>
        public bool ForgetPassword(string email)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.repository.ForgetPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The Password</param>
        /// <returns>
        /// Returns true if successful
        /// </returns>
        /// <exception cref="System.Exception">Throws exception</exception>
        public bool ResetPassword(string email, string password)
        {
            try
            {
                return this.repository.ResetPassword(email, password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>
        /// Returns token string
        /// </returns>
        /// <exception cref="System.Exception">Returns exception</exception>
        public string GenerateToken(string email)
        {
            try
            {
                return this.repository.GenerateToken(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
