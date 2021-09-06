using Managers.Interface;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managers.Manager
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository labelRepository;
        public LabelManager(ILabelRepository labelRepository)
        {
            this.labelRepository=labelRepository;
        }
        public string AddLabelUsingEdit(LabelModel labelModel)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.AddLabelUsingEdit(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabelUsingEdit(string labelName, int userId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.RemoveLabelUsingEdit(labelName, userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
