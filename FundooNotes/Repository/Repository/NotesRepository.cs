// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Asmitha Satesh"/>
// ----------------------------------------------------------------------------------------------------------
namespace Repository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.Extensions.Configuration;
    using Models;
    using global::Repository.Context;
    using global::Repository.Interface;
    using Microsoft.AspNetCore.Http;

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
        /// The configuration
        /// </summary>
        public readonly IConfiguration Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class.
        /// </summary>
        /// <param name="userContext">The user context.</param>
        /// <param name="configuration">The configuration.</param>
        public NotesRepository(UserContext userContext, IConfiguration configuration)
        {
            this.UserContext = userContext;
            this.Configuration = configuration;
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
                var userEmail = this.UserContext.Users.Where(user => user.UserId == userId).Select(x => x.Email).SingleOrDefault();
                List<NotesModel> collabList = (
                                  from o in this.UserContext.Notes
                                  join n in this.UserContext.Collaborators
                                  on o.NotesId equals n.NotesId
                                  where userEmail.Equals(n.CollaboratorEmail)
                                  select o).ToList();

                List<NotesModel> noteList = this.UserContext.Notes.Where(x => x.UserId == userId && x.Trash == false && x.Archive == false).ToList();
                if (collabList.Count != 0)
                {
                      collabList.AddRange(noteList);
                    return collabList;
                }

                return noteList;
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
                var deleteNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId)).SingleOrDefault();
                string message = string.Empty;
                if (deleteNote == null)
                {
                    message = "Note doesn't Exist!";
                }
                else
                {
                    deleteNote.Trash = true;
                    deleteNote.Remainder = null;
                    if (deleteNote.Pin == true)
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
                var restoreNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Trash == true)).SingleOrDefault();
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
                var deleteNote = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Trash == true)).SingleOrDefault();
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
                NotesModel archiveNote = this.UserContext.Notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                string message = string.Empty;
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
                NotesModel restoreNote = this.UserContext.Notes.Where(x => x.NotesId == notesId && x.Archive == true).SingleOrDefault();
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
                NotesModel pinNote = this.UserContext.Notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                string message = string.Empty;
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
                NotesModel removePin = this.UserContext.Notes.Where(x => (x.NotesId == notesId && x.Pin == true)).SingleOrDefault();
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
        /// <param name="notesId">Notes Id</param>
        /// <param name="color">The Color</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns Exception</exception>
        public string SetColor(int notesId, string color)
        {
            try
            {
                var colorData = this.UserContext.Notes.Where(x => (x.NotesId == notesId)).SingleOrDefault();
                if (colorData != null)
                {
                    colorData.Color = color;
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
        /// <param name="notesId">Notes Id</param>
        /// <param name="reminder">The Reminder</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns Exception</exception>
        public string SetReminder(NotesModel notesModel)
        {
            try
            {
                var reminderData = this.UserContext.Notes.Where(x => (x.NotesId == notesModel.NotesId)).SingleOrDefault();
                if (reminderData != null)
                {
                    reminderData.Remainder = notesModel.Remainder;
                    this.UserContext.Notes.Update(reminderData);
                    this.UserContext.SaveChanges();
                    return "Reminder has been Set!";
                }
                else
                {
                    this.UserContext.Notes.Add(notesModel);
                    this.UserContext.SaveChanges();
                    return "Note created";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the reminder.
        /// </summary>
        /// <param name="notesId">Notes Id</param>
        /// <returns>
        /// Returns success message
        /// </returns>
        /// <exception cref="System.Exception">Returns Exception</exception>
        public string RemoveReminder(int notesId)
        {
            try
            {
                var reminderData = this.UserContext.Notes.Where(x => (x.NotesId == notesId)).SingleOrDefault();
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
                var updateNote = this.UserContext.Notes.Where(x => (x.NotesId == notesModel.NotesId)).SingleOrDefault();
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

                return null;
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

                return null;
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

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds the image.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="openReadStream">The open read stream.</param>
        /// <returns>Returns List of archive</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string AddImage(int notes, IFormFile formFile, int userId)
        {
            try
            {
                var note = this.UserContext.Notes.Where(x => x.NotesId == notes).SingleOrDefault();
                Account account = new Account(this.Configuration["CloudinaryAccount:CloudName"], this.Configuration["CloudinaryAccount:APIKey"], this.Configuration["CloudinaryAccount:APISecret"]);
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadFile = new ImageUploadParams()
                {
                    File = new FileDescription(formFile.FileName, formFile.OpenReadStream())
                };
                var uploadResult = cloudinary.Upload(uploadFile);
                if (note != null)
                {
                    note.Image = uploadResult.Url.ToString();
                    this.UserContext.SaveChanges();
                    return "Image Uploaded";
                }
                else
                {
                    NotesModel notesModel = new NotesModel();
                    notesModel.Image = uploadResult.Url.ToString();
                    notesModel.UserId = userId;
                    this.UserContext.Notes.Add(notesModel);
                    this.UserContext.SaveChanges();
                    return "Note created";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Removes the image.
        /// </summary>
        /// <param name="notesId">The notes identifier.</param>
        /// <returns>Returns success message</returns>
        /// <exception cref="System.Exception">Returns exception message</exception>
        public string RemoveImage(int notesId)
        {
            try
            {
                var note = this.UserContext.Notes.Where(x => x.NotesId == notesId).SingleOrDefault();
                if (note != null)
                {
                    note.Image = null;
                    this.UserContext.SaveChanges();
                    return "Image removed";
                }

                return "Couldn't remove Image";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
