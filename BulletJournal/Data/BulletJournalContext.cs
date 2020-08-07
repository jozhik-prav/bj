using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletJournal.Data
{
    public class BulletJournalContext: DbContext
    {
        public BulletJournalContext(DbContextOptions<BulletJournalContext> options)
            : base(options)
        { 
            Database.EnsureCreated();
        }

        public DbSet<Wish> Wishes { get; set; }
    }
}
