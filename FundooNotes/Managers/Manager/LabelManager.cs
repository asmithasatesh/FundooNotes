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
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.EditLabelUsingEdit(userId, labelName, newLabelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<LabelModel> GetLabelUsingUserId(int userId) 
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.GetLabelUsingUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<LabelModel> GetLabelByNoteId(int noteId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.GetLabelByNoteId(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabel(int lableId)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.RemoveLabel(lableId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string CreateLabelUsingNote(LabelModel labelModel)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.CreateLabelUsingNote(labelModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<LabelModel> DisplayLabelNote(int userId, string labelName)
        {
            try
            {
                ////Send userdata to Repository and return result true or false
                return this.labelRepository.DisplayLabelNote(userId, labelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
