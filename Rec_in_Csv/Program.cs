using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rec_in_Csv
{
    class Program
    {
        static void Main(string[] args)
        {
            AppendToCSV();
            ReadCsvFiles();
            
            Console.ReadLine();
        }
        static void AppendToCSV()
        {
            var list = Contacts.GetContacts();
            foreach (var c in list)
            {
                File.AppendAllText("Contactes.csv", $"{c.Name},{c.Phone}\n");
            }
        }
        static void ReadCsvFiles()
        {
            var lines = File.ReadAllLines("Contactes.csv");
            var list = new List<Contact>();
            foreach (var line in lines)
            {
                var values = line.Split(',');
                if (values.Length == 2)
                {
                    var contact = new Contact() { Name = values[0], Phone = values[1] };
                    list.Add(contact);
                }
            }
            list.ForEach(x => Console.WriteLine($"{x.Name}\t{x.Phone}"));
        }
    }
    public class Contacts
    {
         public static List<Contact> GetContacts()
        {
            return new List<Contact>()
            {
                new Contact(){Name = "Jill", Phone = "333-5559"},
                new Contact(){Name = "Pill", Phone = "303-1559"},
                new Contact(){Name = "Sill", Phone = "330-3559"},
                new Contact(){Name = "Rill", Phone = "338-5559"},
            };
        }
    }
    public class Contact
    {
        public string  Name { get; set; }
        public string  Phone { get; set; }
    }
}
