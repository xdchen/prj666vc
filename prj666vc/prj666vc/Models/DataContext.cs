using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prj666vc.Models
{
    public class DataContext : DbContext
    {
        // The constructor for the base class (DbContext) is called
        // before this constructor's block is executed 
        // The data in parentheses is passed to the base class constructor
        public DataContext() : base("name=DataContext") { }

        // DbSet objects
        public DbSet<Note> Notes { get; set; }        
    }
}