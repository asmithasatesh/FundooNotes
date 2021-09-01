﻿using Models;
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
                if (noteData != null)
                {
                    //// Add data to Dbset
                    this.UserContext.Notes.Add(noteData);
                    this.UserContext.SaveChanges();
                    return "Note has been created!";
                }

                return "No data given to add note";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Gets the user notes.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Return List of notes</returns>
        /// <exception cref="System.Exception">Returns Exception</exception>
        public List<NotesModel> GetUserNotes(int userId)
        {
            try
            {
                List<NotesModel> noteList = this.UserContext.Notes.Where(x => x.UserId == userId).ToList();
                if (noteList.Count != 0)
                {
                    return noteList;
                }
                return default;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Move to Trash
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Return success Message</returns>
        /// <exception cref="System.Exception">Returns Exception Message</exception>
        public string TrashNote(int notesId, int userID)
        {
            try
            {
                var deleteNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.UserId == userID)).FirstOrDefault();
                if(deleteNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    deleteNote.Trash = true;
                    this.UserContext.Update(deleteNote);
                    this.UserContext.SaveChanges();
                    return "Note has been moved to Trash!";
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restores the trash.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Return success Message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string RestoreTrash(int notesId, int userID)
        {
            try
            {
                var restoreNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Trash == true && x.UserId == userID)).FirstOrDefault();
                if (restoreNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    restoreNote.Trash = false;
                    this.UserContext.Update(restoreNote);
                    this.UserContext.SaveChanges();
                    return "Note has been restored!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ArchiveNote(int notesId,int userID)
        {
            try
            {
                var archiveNote = this.UserContext.Notes.Where(x => x.NotesId == notesId && x.UserId == userID).FirstOrDefault();
                if (archiveNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    archiveNote.Archive = true;
                    this.UserContext.Update(archiveNote);
                    this.UserContext.SaveChanges();
                    return "Note has been Archieved!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnArchiveNote(int notesId, int userID)
        {
            try
            {
                var restoreNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Archive == true && x.UserId == userID)).FirstOrDefault();
                if (restoreNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    restoreNote.Archive = false;
                    this.UserContext.Update(restoreNote);
                    this.UserContext.SaveChanges();
                    return "Note has been unarchived!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string PinNote(int notesId, int userID)
        {
            try
            {
                var pinNote = this.UserContext.Notes.Where(x => x.NotesId == notesId && x.UserId == userID).FirstOrDefault();
                if (pinNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    pinNote.Pin = true;
                    this.UserContext.Update(pinNote);
                    this.UserContext.SaveChanges();
                    return "Note has been Pinned!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnPinNote(int notesId, int userID)
        {
            try
            {
                var unPinNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Pin == true && x.UserId == userID)).FirstOrDefault();
                if (unPinNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    unPinNote.Pin = false;
                    this.UserContext.Update(unPinNote);
                    this.UserContext.SaveChanges();
                    return "Note has been removed from Pin!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
