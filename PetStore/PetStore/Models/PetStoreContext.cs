using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;


namespace PetStore.Models
{
    public class PetStoreContext: DbContext
    {
        public PetStoreContext()
            : base("PetStoreEntities")
        {
        }
        public DbSet<Pet> Pets { get; set; }
    }
}