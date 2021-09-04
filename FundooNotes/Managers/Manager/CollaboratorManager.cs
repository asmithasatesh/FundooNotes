// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Managers.Manager
{
    using System;
    using System.Collections.Generic;
    using Managers.Interface;
    using Models;
    using Repository.Interface;

    /// <summary>
    /// Pass data from Controller to Repository
    /// </summary>
    /// <seealso cref="Managers.Interface.ICollaboratorManager" />
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// The collaborator repository
        /// </summary>
        private readonly ICollaboratorRepository collaboratorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorManager"/> class.
        /// </summary>
        /// <param name="collaboratorRepository">The collaborator repository.</param>
        public CollaboratorManager(ICollaboratorRepository collaboratorRepository)
        {
            this.collaboratorRepository = collaboratorRepository;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string AddCollaborator(CollaboratorModel model)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.collaboratorRepository.AddCollaborator(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="collabId">The collaboration identifier.</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string RemoveCollaborator(int collabId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.collaboratorRepository.RemoveCollaborator(collabId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>
        /// Returns list of collaborators
        /// </returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public List<string> GetCollaborator(int notesId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.collaboratorRepository.GetCollaborator(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
