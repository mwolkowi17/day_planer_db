using System;
using System.Linq;

namespace day_planer_db
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Day_Elements.DayContext())
            {
                Console.WriteLine("Wprowadź nowy tytuł wpisu:");
                string a = Console.ReadLine();
                Console.WriteLine("Wprowadź nowy wpis");
                string b = Console.ReadLine();
               
                db.Days.Add(
                    new Day_Elements.Day
                    {
                        Title = a,
                        Content=b,
                        
                    }) ;
                db.SaveChanges();
            
                
            }
        }
    }
}
