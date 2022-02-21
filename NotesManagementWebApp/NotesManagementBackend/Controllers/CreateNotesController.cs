using Microsoft.AspNetCore.Mvc;
using NotesManagementBackend.Authentication;
using NotesManagementBackend.Models;
using NotesManagementBackend.Repository;
using System;

namespace NotesManagementBackend.Controllers
{
    [ApiController]
    public class CreateNotesController : Controller
    {
        [HttpPost("api/addNewNote")]
        public IActionResult Index()
        {
            string noteData = Request.Headers["Authorization"];

            if (Authenticator.Authenticate(noteData))
            {
                //saving note if token is valid

                if (Request.Form["type"] =="Regular")
                {
                    NotesModel.RegularNoteClass regularObj = new NotesModel.RegularNoteClass();
                    regularObj.Type = Request.Form["type"];
                    regularObj.Text = Request.Form["text"];
                    regularObj.NoteId = NotesRepo.NumberOfNotes() + 1;
                    regularObj.Email = Authenticator.findEmail(noteData);
                    regularObj.Title = Request.Form["title"];
                    regularObj.CreatedAt = DateTime.Now;

                    bool saveSuccess = NotesRepo.AddNewNote(regularObj);
                    if (saveSuccess)
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(500, "Internal server problem");
                    }
                }
                else if (Request.Form["type"] == "Reminder")
                {
                    NotesModel.ReminderNoteClass reminderObj = new NotesModel.ReminderNoteClass();
                    reminderObj.NoteId = NotesRepo.NumberOfNotes() + 1;
                    reminderObj.Type = Request.Form["type"];
                    reminderObj.Email = Authenticator.findEmail(noteData);
                    reminderObj.Title = Request.Form["title"];
                    reminderObj.Text = Request.Form["text"];
                    reminderObj.DateTime = Convert.ToDateTime(Request.Form["datetime"]);
                    reminderObj.CreatedAt = DateTime.Now;

                    bool saveSuccess = NotesRepo.AddNewNote(reminderObj);
                    if (saveSuccess)
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(500, "Internal server problem");
                    }
                }
                else if (Request.Form["type"] == "Todo")
                {
                    NotesModel.TodoNoteClass todoObj = new NotesModel.TodoNoteClass();
                    todoObj.Type = Request.Form["type"];
                    todoObj.NoteId = NotesRepo.NumberOfNotes() + 1;
                    todoObj.Email = Authenticator.findEmail(noteData);
                    todoObj.Title = Request.Form["title"];
                    todoObj.Text = Request.Form["text"];
                    todoObj.DueDate = Convert.ToDateTime(Request.Form["dueDateTime"]);
                    todoObj.IsCompleted = false;
                    todoObj.CreatedAt = DateTime.Now;

                    bool saveSuccess = NotesRepo.AddNewNote(todoObj);
                    if (saveSuccess)
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(500, "Internal server problem");
                    }
                }
                else
                {
                    NotesModel.BookmarkNoteClass bookmarkObj = new NotesModel.BookmarkNoteClass();
                    bookmarkObj.Type = Request.Form["type"];
                    bookmarkObj.NoteId = NotesRepo.NumberOfNotes() + 1;
                    bookmarkObj.Email = Authenticator.findEmail(noteData);
                    bookmarkObj.Title = Request.Form["title"];
                    bookmarkObj.NoteUrl = Request.Form["noteUrl"];
                    bookmarkObj.CreatedAt = DateTime.Now;

                    bool saveSuccess = NotesRepo.AddNewNote(bookmarkObj);
                    if (saveSuccess)
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(500, "Internal server problem");
                    }
                }
            }

            return StatusCode(401, "Unauthorized access");
        }
    }
}
