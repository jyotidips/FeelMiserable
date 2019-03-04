using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace FeelMiserable.Models
{
    public class Context : DbContext
    {
        public Context() : base("MyDb")
        {

        }
        public DbSet<SlangStore> SlangStores { get; set; }


    }
}