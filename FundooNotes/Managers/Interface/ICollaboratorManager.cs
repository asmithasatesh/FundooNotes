using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Interface
{
    public interface ICollaboratorManager
    {
        public string AddCollaborator(CollaboratorModel model);
        public string RemoveCollaborator(int collabId);
        public List<string> GetCollaborator(int notesId);
    }
}
