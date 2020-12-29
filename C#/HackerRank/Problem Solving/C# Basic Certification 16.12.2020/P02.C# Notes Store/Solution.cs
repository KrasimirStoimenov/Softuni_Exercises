using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{

    public class NotesStore
    {
        private Dictionary<string, List<string>> notes;
        public NotesStore()
        {
            this.notes = new Dictionary<string, List<string>>()
            {
                {"completed", new List<string>()},
                {"active", new List<string>()},
                {"others", new List<string>()}
            };
        }
        public void AddNote(String state, String name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name cannot be empty");
            }
            if (!this.notes.ContainsKey(state))
            {
                throw new Exception($"Invalid state {state}");
            }

            this.notes[state].Add(name);
        }
        public List<String> GetNotes(String state)
        {
            if (!this.notes.ContainsKey(state))
            {
                throw new Exception($"Invalid state {state}");
            }

            var currentNotes = this.notes[state];

            return currentNotes;
        }
    }

    public class Solution
    {
        public static void Main()
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}