using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UserSelfDesk.Domain.Master;

namespace UserSelfDesk.Applcaiton.Common.Interface
{
    public interface IApplicationDBContext
    {

        DbSet<ReferenceMaster> ReferenceMasters { get; set; }
        DbSet<AppSetting> AppSettings { get; set; }

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;


        Task<int> SaveChangesAsync();
    }
}
