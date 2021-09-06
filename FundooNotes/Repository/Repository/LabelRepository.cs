﻿using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class LabelRepository : ILabelRepository
    {
        /// <summary>
        /// The user context
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public LabelRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        /// <summary>
        /// Adds the label using edit.
        /// </summary>
        /// <param name="labelModel">The label model.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exceptions</exception>
        public string AddLabelUsingEdit(LabelModel labelModel)
        {
            try
            {
                var existLabel = this.UserContext.Labels.Where(label => label.LabelName == labelModel.LabelName && labelModel.UserId == label.UserId).SingleOrDefault();
                if(existLabel == null)
                {
                    this.UserContext.Labels.Add(labelModel);
                    this.UserContext.SaveChanges();
                    return "Label created";
                }

                return "Label already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the label using edit.
        /// </summary>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exceptions</exception>
        public string RemoveLabelUsingEdit(string labelName, int userId)
        {
            try
            {
                var labelList = this.UserContext.Labels.Where(label => label.LabelName == labelName && label.UserId == userId).ToList();
                if( labelList.Count != 0)
                {
                    this.UserContext.Labels.RemoveRange(labelList);
                    this.UserContext.SaveChanges();
                    return "Label deleted";
                }

                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edits the label using edit.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="labelName">Name of the label.</param>
        /// <param name="newLabelName">New name of the label.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exceptions</exception>
        public string EditLabelUsingEdit(int userId, string labelName, string newLabelName)
        {
            try
            {
                var labelList = this.UserContext.Labels.Where(label => label.LabelName == labelName && label.UserId == userId).ToList();
                var checknewLabel = this.UserContext.Labels.Where(label => label.LabelName == newLabelName && label.UserId == userId).ToList();
                if (labelList.Count != 0)
                {
                    foreach (var label in labelList)
                    {
                        label.LabelName = newLabelName;
                    }

                    this.UserContext.UpdateRange(labelList);
                    this.UserContext.SaveChanges();
                    if(checknewLabel.Count != 0)
                    {
                        return "Merge the '" + labelName+ "' label with the '" + newLabelName+ "' label? All notes labeled with '" + labelName+ "' will be labeled with '" + newLabelName+ "', and the '" + labelName+ "' label will be deleted.";
                    }

                    return "Label Updated";
                }

                return "Couldn't update Label";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}