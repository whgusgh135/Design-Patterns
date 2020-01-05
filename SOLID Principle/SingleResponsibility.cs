using System;
using System.Collections.Generic;
using System.IO;

namespace SOLID_Principle
{
    // SINGLE RESPONSIBILITY PRINCIPLE
    // A class should have one, and only one, reason to change
    
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern
        }

        public void removeEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // Journal class should be only responsible for one thing
        // that is to add entries.
        // Move these save methods to separate class for single responsibility principle
        public void Save(string filename)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {
            
        }

        public void Load(Uri uri)
        {
            
        }
    }

    // Seperated save responsibility to a new class
    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }
}