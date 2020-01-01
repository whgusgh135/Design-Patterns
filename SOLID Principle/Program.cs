using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SOLID_Principle
{
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

        // move these methods to separate class for single respon
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

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today");
            j.AddEntry("I stared at the ceiling for 8 hours");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"e:\Coding\Course\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}