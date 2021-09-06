// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// Defines method/business logic for all API call
    /// </summary>
    /// <seealso cref="Repository.Interface.ICollaboratorRepository" />
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public CollaboratorRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        /// <summary>
        /// Adds the collaborator.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Returns success message</returns>
        public string AddCollaborator(CollaboratorModel model)
        {
            try
            {
                string message = string.Empty;
                var existingEmail = this.UserContext.Collaborators.Where(x => x.CollaboratorEmail == model.CollaboratorEmail && x.NotesId == model.NotesId).SingleOrDefault();
                var ownerEmail = (from o in this.UserContext.Notes
                                  join i in this.UserContext.Users
                                  on o.UserId equals i.UserId
                                  where model.NotesId == o.NotesId
                                  select new
                                  {
                                      Email = i.Email
                                  }).SingleOrDefault();
                message = "Email already exist!";
                if (ownerEmail.Email.Equals(model.CollaboratorEmail) == false && existingEmail == null)
                {
                    this.UserContext.Collaborators.Add(model);
                    this.UserContext.SaveChanges();
                    message = "Collaborator added";
                }

                return message;
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
        /// <returns>Returns list of collaborators</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public List<CollaboratorModel> GetCollaborator(int notesId)
        {
            try
            {
                List<CollaboratorModel> collabList = this.UserContext.Collaborators.Where(x => x.NotesId == notesId).ToList();
                if (collabList.Count != 0)
                {
                    return collabList;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the collaborator.
        /// </summary>
        /// <param name="collabId">The collaborator identifier.</param>
        /// <returns>Returns Success Message</returns>
        public string RemoveCollaborator(int collabId)
        {
            try
            {
                var getCollab = this.UserContext.Collaborators.Where(x => x.CollaboratorId == collabId).SingleOrDefault();
                if (getCollab != null)
                {
                    this.UserContext.Collaborators.Remove(getCollab);
                    this.UserContext.SaveChanges();
                    return "Collaborator removed";
                }

                return "Collaborator doesn't exist!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
