using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICollaboratorRepository
    {
        public string AddCollaborator(CollaboratorModel model);
    }
}
