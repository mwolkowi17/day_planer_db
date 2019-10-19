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
                
                bool loop_main = true;
                while (loop_main == true)
                {
                    Console.WriteLine("Jeśli chcesz wprowadzić nowy rekord wpisz: r");
                    Console.WriteLine("Jeśli chcesz zobaczyć wpisy wprowadź: w");
                    Console.WriteLine("Jeśli chcesz skasować jakiś element wprowadź: k");
                    string decyzja_start = Console.ReadLine();
                    //string decyzja_a = Console.ReadLine();
                    //string decyzja_b = Console.ReadLine();
                    if (decyzja_start == "r") { 
                    Console.WriteLine("Wprowadź nowy tytuł wpisu:");
                    string a = Console.ReadLine();
                    Console.WriteLine("Wprowadź nowy wpis");
                    string b = Console.ReadLine();

                    db.Days.Add(
                        new Day_Elements.Day
                        {
                            Title = a,
                            Content = b,

                        });
                    db.SaveChanges();
                    }
                   
                    
                    
                    if (decyzja_start == "w")
                    {
                        var lista = db.Days.ToList();
                        foreach (var n in lista)
                        {
                            Colorgreen();
                            Console.WriteLine("===============================================================================");
                            Console.WriteLine(n.Id);
                            Console.WriteLine(n.Title);
                            Console.WriteLine(n.Content);
                            Console.WriteLine("===============================================================================");
                            Colorgrey();
                        }
                    }
                    bool decyzja_C = false;
                    
                    
                    if (decyzja_start == "k")
                    {
                        decyzja_C = true;
                    }
                    
                    while (decyzja_C == true)
                    {
                        Console.WriteLine("Wprowadź nr Id posta do skasowania:");
                        string decyzja_d = Console.ReadLine();
                        int kas = Convert.ToInt32(decyzja_d);
                        var singlePost = db.Days
                                .Single(b => b.Id == kas);
                        db.Days.Remove(singlePost);
                        db.SaveChanges();
                        Console.WriteLine("chcesz skasować kolejny wpisz n:");
                        string decyzja_e = Console.ReadLine();
                        if (decyzja_e != "n")
                        {
                            decyzja_C = false;
                        }
                       
                    }
                    Console.WriteLine("Chcesz zakończyć program wpisz end, jeśli chcesze kontynuować naciśnij dowolny inny klawisz");
                    string koniec = Console.ReadLine();
                    if (koniec == "end")
                    {
                        loop_main = false;
                    }
                }
                static void Colorgreen()
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                static void Colorgrey()
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }
        }
    }
}
