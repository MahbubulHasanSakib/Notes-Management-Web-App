using System;

namespace NotesManagementBackend.Models
{
    public class NotesModel
    {
        public class RegularNoteClass
        {
            public int NoteId { get; set; }
            public string Type { get; set; }
            public string Email { get; set; }
            public string Title { get; set; }
            public string Text { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class ReminderNoteClass
        {

            public int NoteId { get; set; }
            public string Type { get; set; }
            public DateTime DateTime { get; set; }
            public string Email { get; set; }
            public string Title { get; set; }
            public string Text { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class TodoNoteClass
        {

            public int NoteId { get; set; }
            public string Type { get; set; }
            public bool IsCompleted { get; set; }
            public string Email { get; set; }
            public string Title { get; set; }
            public string Text { get; set; }
            public DateTime DueDate { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        public class BookmarkNoteClass
        {
            public int NoteId { get; set; }
            public string Type { get; set; }
            public string Email { get; set; }
            public string Title { get; set; }
            public string NoteUrl { get; set; }
            public DateTime CreatedAt { get; set; }
        }

    }
}
