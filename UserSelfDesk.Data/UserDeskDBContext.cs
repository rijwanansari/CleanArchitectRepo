using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.Common.Interface;
using UserSelfDesk.CoreCommon.Helper;
using UserSelfDesk.Domain.Common;
using UserSelfDesk.Domain.Master;

namespace UserSelfDesk.Data
{
   public class UserDeskDBContext : DbContext, IApplicationDBContext
    {
        #region Properties
        private readonly IDateTime _dateTime;
        #endregion

        #region Ctor
        public UserDeskDBContext(DbContextOptions<UserDeskDBContext> options, IDateTime dateTime)
          : base(options)
        {
            _dateTime = dateTime;
        }
        #endregion


        #region "Master"
        public DbSet<ReferenceMaster> ReferenceMasters { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDeskDBContext).Assembly);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Author = 1; //Get Current UsereID
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.Editor = 1; //Get Current UsereID
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Editor = 1; //Get Current UsereID
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Author = 1; //Get Current UsereID
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.Editor = 1; //Get Current UsereID
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Editor = 1; //Get Current UsereID
                        entry.Entity.Modified = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        #endregion

    }
}
