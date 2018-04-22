
using System.Data.Entity;


using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Data
{
    public partial class LookTechno : IContext
    {
        
      
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
      
    }     
}
