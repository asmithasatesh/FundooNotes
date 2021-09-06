using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
    public interface ILabelRepository
    {
       public string  AddLabelUsingEdit(LabelModel labelModel);
        public string RemoveLabelUsingEdit(string labelName, int userId);
    }
}
