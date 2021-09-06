using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Interface
{
    public interface ILabelManager
    {
        public string AddLabelUsingEdit(LabelModel labelModel);
        public string RemoveLabelUsingEdit(string labelName, int userId);
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName);
        public List<LabelModel> GetLabelUsingUserId(int userId);
        public List<LabelModel> GetLabelByNoteId(int noteId);
        public string RemoveLabel(int lableId);
        public string CreateLabelUsingNote(LabelModel labelModel);
    }
}
