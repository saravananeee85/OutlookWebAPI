using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OutlookwebApi.Models;

namespace TodoApi.Models
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
           : base(options)
        {
        }

        public DbSet<TodoItem> USERPERSONAS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(@"Data Source = companycal.database.windows.net; Initial Catalog = UserMiroservice; Integrated Security = false;User ID=demo;Password=Welcome2020");

        }

    }
}
