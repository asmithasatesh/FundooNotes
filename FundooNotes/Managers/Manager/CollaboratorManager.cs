using Managers.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository collaboratorRepository;
        public CollaboratorManager(ICollaboratorRepository collaboratorRepository)
        {
            this.collaboratorRepository=collaboratorRepository;
        }
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
