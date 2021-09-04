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
    }
}
