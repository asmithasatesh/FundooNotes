using Models;
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
    }
}
