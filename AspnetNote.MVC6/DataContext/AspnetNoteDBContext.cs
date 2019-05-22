using AspnetNote.MVC6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.MVC6.DataContext
{
    public class AspnetNoteDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=197.200.1.63,1433;Initial Catalog=AspnetNoteDb;Persist Security Info=True;User ID=kdw;Password=kdw; ");
        }
    }
}
