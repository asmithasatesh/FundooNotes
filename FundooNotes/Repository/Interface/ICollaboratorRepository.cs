// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Interface
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Interface containing method declaration
    /// </summary>
    public interface ICollaboratorRepository
    {
        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Returns success message</returns>
        public string AddCollaborator(CollaboratorModel model);

        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="collabId">The collaborator identifier.</param>
        /// <returns>Returns success message</returns>
        public string RemoveCollaborator(int collabId);

        /// <summary>
        /// Gets the collaborator.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns list of collaborators</returns>
        public List<CollaboratorModel> GetCollaborator(int notesId);
    }
}
