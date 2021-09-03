﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;

    /// <summary>
    /// Defines method/business logic for all API call
    /// </summary>
    /// <seealso cref="Repository.Interface.INotesRepository" />
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// User context is used to call constructor for database Context
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        public NotesRepository(UserContext userContext)
        {
            this.UserContext = userContext;
        }

        /// <summary>
        /// Creates the note.
        /// </summary>
        /// <param name="noteData">The note data.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string CreateNote(NotesModel noteData)
        {
            try
            {
                if (noteData.Title != null || noteData.Description != null)
                {
                    //// Add data to Dbset
                    this.UserContext.Notes.Add(noteData);
                    this.UserContext.SaveChanges();
                    return "Note created!";
                }

                return "Need Title or description to add note";
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
                List<NotesModel> noteList = this.UserContext.Notes.Where(x => x.UserId == userId && x.Trash == false && x.Archive == false).ToList();
                if (noteList.Count != 0)
                {
                    return noteList;
                }

                return default;
            }
            catch (Exception ex)
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
        public string TrashNote(int notesId)
        {
            try
            {
                var deleteNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId)).FirstOrDefault();
                string message = "";
                if (deleteNote == null)
                {
                    message = "Note doesn't Exist!";
                }
                else
                {
                    deleteNote.Trash = true;
                    deleteNote.Remainder = null;
                    if(deleteNote.Pin == true)
                    {
                        deleteNote.Pin = false;
                        message = "Note unpinned and trashed";
                    }
                    this.UserContext.Update(deleteNote);
                    this.UserContext.SaveChanges();
                    return "Note trashed";
                }
                return message;
            }
            catch (Exception ex)
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
        public string RestoreTrash(int notesId)
        {
            try
            {
                var restoreNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Trash == true)).FirstOrDefault();
                if (restoreNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    restoreNote.Trash = false;
                    this.UserContext.Update(restoreNote);
                    this.UserContext.SaveChanges();
                    return "Note restored";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deletes the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string DeleteNote(int notesId)
        {
            try
            {
                var deleteNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Trash == true)).FirstOrDefault();
                if (deleteNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    this.UserContext.Notes.Remove(deleteNote);
                    this.UserContext.SaveChanges();
                    return "Note deleted!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Empties the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string EmptyTrash(int userId)
        {
            try
            {
                var noteList = this.UserContext.Notes.Where(x => x.UserId == userId && x.Trash == true);
                this.UserContext.Notes.RemoveRange(noteList);
                this.UserContext.SaveChanges();
                return "Trash has been cleared!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Archives the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string ArchiveNote(int notesId)
        {
            try
            {
                NotesModel archiveNote = this.UserContext.Notes.Where(x => x.NotesId == notesId).FirstOrDefault();
                string message = "";
                if (archiveNote == null)
                {
                    message = "Note doesn't Exist!";
                }
                else
                {
                    archiveNote.Archive = true;
                    message = "Note archived";
                    if (archiveNote.Pin == true)
                    {
                        archiveNote.Pin = false;
                        message = "Note unpinned and archived";
                    }
                    this.UserContext.Update(archiveNote);
                    this.UserContext.SaveChanges();
                }
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restore the archive note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string UnArchiveNote(int notesId)
        {
            try
            {
                NotesModel restoreNote = this.UserContext.Notes.Where(x => x.NotesId == notesId && x.Archive == true).FirstOrDefault();
                if (restoreNote == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    restoreNote.Archive = false;
                    this.UserContext.Update(restoreNote);
                    this.UserContext.SaveChanges();
                    return "Note unarchived";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Pins the note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string PinNote(int notesId)
        {
            try
            {
                NotesModel pinNote = this.UserContext.Notes.Where(x => x.NotesId == notesId).FirstOrDefault();
                string message = "";
                if (pinNote == null)
                {
                    message = "Note doesn't Exist!";
                }
                else
                {
                    pinNote.Pin = true;
                    message = "Note has been Pinned!";
                    if (pinNote.Archive == true)
                    {
                        pinNote.Archive = false;
                        message = "Note unarchived and pinned";
                    }
                    this.UserContext.Update(pinNote);
                    this.UserContext.SaveChanges();
                }
                return message;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Restore the pin note.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string UnPinNote(int notesId)
        {
            try
            {
                NotesModel removePin = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Pin == true)).FirstOrDefault();
                if (removePin == null)
                {
                    return "Note doesn't Exist!";
                }
                else
                {
                    removePin.Pin = false;
                    this.UserContext.Update(removePin);
                    this.UserContext.SaveChanges();
                    return "Note has been removed from Pin!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Return success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string SetColor(NotesModel notesModel)
        {
            try
            {
                var colorData = this.UserContext.Notes.Where(x => (x.NotesId == notesModel.NotesId)).FirstOrDefault();
                if (colorData != null)
                {
                    colorData.Color = notesModel.Color;
                    this.UserContext.Notes.Update(colorData);
                    this.UserContext.SaveChanges();
                    return "Note color has been Set!";
                }

                return "Couldn't set Color";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Sets the reminder.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string SetReminder(NotesModel notesModel)
        {
            try
            {
                var reminderData = this.UserContext.Notes.Where(x => (x.NotesId == notesModel.NotesId)).FirstOrDefault();
                if (reminderData != null)
                {
                    reminderData.Remainder = notesModel.Remainder;
                    this.UserContext.Notes.Update(reminderData);
                    this.UserContext.SaveChanges();
                    return "Reminder has been Set!";
                }

                return "Couldn't set Reminder";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the reminder.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string RemoveReminder(NotesModel notesModel)
        {
            try
            {
                var reminderData = this.UserContext.Notes.Where(x => (x.NotesId == notesModel.NotesId)).FirstOrDefault();
                if (reminderData != null)
                {
                    reminderData.Remainder = null;
                    this.UserContext.Notes.Update(reminderData);
                    this.UserContext.SaveChanges();
                    return "Reminder deleted";
                }

                return "Couldn't remove Reminder";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updates the note.
        /// </summary>
        /// <param name="notesModel">The notes model.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string UpdateNote(NotesModel notesModel)
        {
            try
            {
                var updateNote = this.UserContext.Notes.Where(x => (x.NotesId == notesModel.NotesId)).FirstOrDefault();
                if (updateNote != null)
                {
                    updateNote.Title = notesModel.Title;
                    updateNote.Description = notesModel.Description;
                    this.UserContext.Notes.Update(updateNote);
                    this.UserContext.SaveChanges();
                    return "Updated Note!";
                }

                return "Couldn't update";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the trash.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns list of trash</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public List<NotesModel> GetTrash(int userId)
        {
            try
            {
                List<NotesModel> noteList = this.UserContext.Notes.Where(x => x.UserId == userId && x.Trash == true).ToList();
                if (noteList.Count != 0)
                {
                    return noteList;
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the reminder.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns List of Reminders</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public List<NotesModel> GetReminder(int userId)
        {
            try
            {
                List<NotesModel> noteList = this.UserContext.Notes.Where(x => x.UserId == userId && x.Remainder != null).ToList();
                if (noteList.Count != 0)
                {
                    return noteList;
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets the archive.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Returns List of archive</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public List<NotesModel> GetArchive(int userId)
        {
            try
            {
                List<NotesModel> noteList = this.UserContext.Notes.Where(x => x.UserId == userId && x.Archive == true && x.Trash == false).ToList();
                if (noteList.Count != 0)
                {
                    return noteList;
                }

                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
