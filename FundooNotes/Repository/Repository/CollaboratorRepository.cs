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
            var checkValidEmail = this.UserContext.Users.Where(x => model.CollaboratorEmail == x.Email).SingleOrDefault();
            var existingEmail = this.UserContext.Collaborators.Where(x => x.CollaboratorEmail == model.CollaboratorEmail && x.NotesId == model.NotesId).SingleOrDefault();
            var OwnerEmail = (from o in this.UserContext.Notes
                              join i in this.UserContext.Users
                              on o.UserId equals i.UserId
                              select new
                              {
                                  Email= i.Email
                              }).SingleOrDefault();
            string message = "";
            message = "Email already exist!";
            if (OwnerEmail.Email.Equals(model.CollaboratorEmail) == false && existingEmail == null)
            {
                message = "This email isn’t valid";
                if (checkValidEmail != null)
                {
                    this.UserContext.Collaborators.Add(model);
                    this.UserContext.SaveChanges();
                    message = "Collaborator added";
                }
            }
            return message;
        }

        public string RemoveCollaborator(int collabId)
        {
            var getCollab = this.UserContext.Collaborators.Where(x => x.CollaboratorId == collabId).SingleOrDefault();
            if(getCollab != null)
            {
                this.UserContext.Collaborators.Remove(getCollab);
                this.UserContext.SaveChanges();
                return "Collaborator removed";
            }
            return "Collaborator doesn't exist!";
        }
        public List<string> GetCollaborator(int notesId)
        {
            try
            {
                List<CollaboratorModel> collabList= this.UserContext.Collaborators.Where(x => x.NotesId == notesId).ToList();
                if (collabList.Count != 0)
                {
                    return collabList.Select(x => x.CollaboratorEmail).ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
