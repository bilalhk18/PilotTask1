using Domain.Entities;
using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
            : base()
        {
        }
    }
    public class DomainContext : IdentityDbContext<ApplicationUser>
    {
        public DomainContext()
          : base("AngularTestDB", throwIfV1Schema: false)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DomainContext(string name)
         : base(name, throwIfV1Schema: false)
        {
        }
       
        public DbSet<User> Users { get; set; }
        public void DropOutstandingChanges()
        {
            foreach (DbEntityEntry entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }

        public Boolean DetectOutstandingChanges()
        {
            int n = 0;

            foreach (DbEntityEntry entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Added:
                    case EntityState.Deleted:
                        n++;
                        break;
                    default: break;
                }
            }
            return (n > 0);
        }



        public void BeginTransaction()
        {
            if (DetectOutstandingChanges())
            {
                throw new Exception("Context has outstanding changes");
            }
        }

        public void DropTransaction()
        {
            DropOutstandingChanges();
        }

        public async Task<Boolean> CommitTransaction()
        {
            await SaveChangesAsync();
            return true;
        }

    }
}
