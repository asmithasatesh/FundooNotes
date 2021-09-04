using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        public readonly UserContext UserContext;

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
            var userEmail = this.UserContext.Users.Where(x => model.CollaboratorEmail == x.Email).SingleOrDefault();
            var value = this.UserContext.Collaborators.Where(x => model.CollaboratorEmail == model.CollaboratorEmail && x.NotesId == model.NotesId).SingleOrDefault();
            var Track = (from o in this.UserContext.Notes
                              join i in this.UserContext.Users
                              on o.UserId equals i.UserId
                              select new
                              {
                                  Email= i.Email
                              }).SingleOrDefault();
            string message = "";
            message = "Email already exist!";
            var test = Track.Email;
            if ( Track.Email.Equals(model.CollaboratorEmail) == false && value == null)
            {
                message = "This email isn’t valid";
                if (userEmail != null)
                {
                    this.UserContext.Collaborators.Add(model);
                    this.UserContext.SaveChanges();
                    message = "Collaborator added";
                }
            }
            return message;
        }
    }
}
