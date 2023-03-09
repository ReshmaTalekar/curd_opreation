using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RBTalekar.Models
{
    public class ServicesContext:DbContext
    {
        public DbSet<Employee> emp { get; set; }
    }
}