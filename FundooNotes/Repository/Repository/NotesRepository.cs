using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// User context is used to call constructor for database Context
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class
        /// </summary>
        /// <param name="userContext">User Data</param>
        /// <returns> Returns true if data added otherwise return false</returns>
        public NotesRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        public string CreateNote(NotesModel noteData)
        {
            try
            {
                var checkUser = this.UserContext.Notes.Where(user => user.NotesId == noteData.NotesId).FirstOrDefault();
                if (checkUser == null)
                {
                    if (noteData != null)
                    {
                        //// Add data to Dbset
                        this.UserContext.Notes.Add(noteData);
                        this.UserContext.SaveChanges();
                        return "Note has been created!";
                    }

                    return "No data given";
                }
                else
                {
                    this.UserContext.Notes.Update(noteData);
                    this.UserContext.SaveChanges();
                    return "Notes have been Updated Successfully!";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
