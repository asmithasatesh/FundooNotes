using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ICollaboratorRepository
    {
        public string AddCollaborator(CollaboratorModel model);
        public string RemoveCollaborator(int collabId);
        public List<string> GetCollaborator(int notesId);
    }
}
