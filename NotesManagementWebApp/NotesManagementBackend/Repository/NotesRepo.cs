using NotesManagementBackend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NotesManagementBackend.Repository
{
    public class NotesRepo
    {
        private static List<Dictionary<string, string>> NotesStore = new List<Dictionary<string, string>>();

        public static bool AddNewNote(object note)
        {
            try
            {
                string jsonNote = JsonConvert.SerializeObject(note);
                var noteToDict= JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonNote);
                NotesStore.Add(noteToDict);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetAllNotes(string email, string search = "")
        {
            List<Dictionary<string, string>> searchedNotesStore = new List<Dictionary<string, string>>();

            if (search.Length == 0)
            {

                foreach(var note in NotesStore)
                {
                    if (Convert.ToString(note["Email"]) == email)
                    {
                        searchedNotesStore.Add(note);
                    }
                }
             

                return JsonConvert.SerializeObject(searchedNotesStore);
            }
            else
            {
                if (search=="day")
                {


                    foreach(var note in NotesStore)
                    {
                        if (note["Email"]==email)
                        {
                            if (note["Type"]=="Reminder")
                            {
                                if (IsEqualToDay(note["DateTime"]))
                                {
                                    searchedNotesStore.Add(note);
                                }
                            }
                            if (note["Type"]=="Todo")
                            {
                             
                                if (IsEqualToDay(note["DueDate"]))
                                {
                                    searchedNotesStore.Add(note);
                                }
                            }
                        }
                    }
                  
                    return JsonConvert.SerializeObject(searchedNotesStore);
                }
                else if (search=="week")
                {

                    foreach (var note in NotesStore)
                    {
                        if (note["Email"] == email)
                        {
                            if (note["Type"]=="Reminder")
                            {
                                if (IsEqualToWeek(note["DateTime"]))
                                {
                                    searchedNotesStore.Add(note);
                                }
                            }
                            if (note["Type"] == "Todo")
                            {
                                if (IsEqualToWeek(note["DueDate"]))
                                {
                                    searchedNotesStore.Add(note);
                                }
                            }
                        }
                    }

                  
                    return JsonConvert.SerializeObject(searchedNotesStore);
                }
                else if (search=="month")
                {

                    foreach (var note in NotesStore)
                    {
                        if (note["Email"] == email)
                        {
                            if (note["Type"]=="Reminder")
                            {
                                if (IsEqualToMonth(note["DateTime"]))
                                {
                                    searchedNotesStore.Add(note);
                                }
                            }
                            if (note["Type"] == "Todo")
                            {
                                if (IsEqualToMonth(note["DueDate"]))
                                {
                                    searchedNotesStore.Add(note);
                                }
                            }
                        }
                    }

                    return JsonConvert.SerializeObject(searchedNotesStore);
                }
                else
                {
                    return null;
                }
            }
        }


        private static bool IsEqualToDay(string getDateAndTime)
        {
            DateTime date = Convert.ToDateTime(getDateAndTime).Date;
            if (date.Equals(DateTime.Now.Date))
            {
                return true;
            }
            return false;
        }

        private static bool IsEqualToWeek(string getDateAndTime)
        {
            DateTime datetime = Convert.ToDateTime(getDateAndTime);
            int noteWeekNum = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(datetime, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int todayWeekNum = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

            if (noteWeekNum.Equals(todayWeekNum))
            {
                return true;
            }
            return false;
        }
        private static bool IsEqualToMonth(string getDateAndTime)
        {
            int month = Convert.ToDateTime(getDateAndTime).Month;
            if (month.Equals(DateTime.Now.Month))
            {
                return true;
            }
            return false;
        }
        public static int NumberOfNotes()
        {
            return NotesStore.Count;
        }
        public static bool updateTodoState(string updateNoteId)
        {

            foreach (var note in NotesStore)
            {
                if (note["NoteId"].Equals(updateNoteId))
                {
                    note["IsCompleted"] = "true";
                    return true;
                }
            }
            return false;
        }
     


    }
}
