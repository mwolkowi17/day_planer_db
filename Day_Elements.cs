using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace day_planer_db
{
    class Day_Elements
    {
        public class DayContext : DbContext
        {
            public DbSet<Day> Days { get; set; }
            

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=blogging.db");
        }
        public class Day
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
        }
    }
}
