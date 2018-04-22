using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace LookTechnoCMS.Data.Infrastructure
{

    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        protected IContext Context;
        protected DbSet<T> Dbset;

        public EntityService(IContext context)
        {
            Context = context;
            Dbset = Context.Set<T>();
        }


        public virtual IEnumerable<T> GetAll()
        {
         
                return Dbset.AsEnumerable<T>();
          
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Dbset;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual T Find(int id)
        {
            //return GetAll().FirstOrDefault(x => x.Id == id);

            throw new NotImplementedException();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void Add(T entity)
        {
            //DbEntityEntry dbEntityEntry = Context.Entry<T>(entity);
            //Dbset.Add(entity);

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            Dbset.Add(entity);
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                Context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public virtual void Delete(T entity)
        {
            //DbEntityEntry dbEntityEntry = Context.Entry<T>(entity);
            //dbEntityEntry.State = EntityState.Deleted;


            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Dbset.Remove(entity);
            Context.SaveChanges();
        }

        public virtual bool Edit(T entity)
        {
            bool result;
            ////DbEntityEntry dbEntityEntry = Context.Entry<T>(entity);
            ////dbEntityEntry.State = EntityState.Modified;
            //if (entity == null) {
            //    throw new ArgumentNullException("entity");
            //}
            //Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            // Context.SaveChanges();
            //return result;
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Context.Entry(entity).State =System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                result = true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);

                var fail = new Exception(msg, dbEx);
                //Debug.WriteLine(fail.Message, fail);
                //throw fail;
                result = false;
            }
            return result;
        }
        public virtual bool CanDeleteRecord(T entity)
        {
            PropertyInfo CascadeList = entity.GetType().GetProperty("CascadeList");
            bool _canDel = true;

            if (CascadeList != null)
            {
                var _CascadeList = (string[])CascadeList.GetValue(entity);

                List<PropertyInfo> forignKeysProperties =
                    entity.GetType()
                        .GetProperties()
                        .Where(o => (_CascadeList.Contains(o.Name)))
                        .Select(o => o)
                        .ToList();
                bool foundRelated =
                    forignKeysProperties.Any(
                        n =>
                            ((int)n.GetValue(entity).GetType().GetProperty("Count").GetValue(n.GetValue(entity))) > 0);

                _canDel = !foundRelated;
            }
            ;

            return _canDel;
        }
        public virtual void Update(T entity)
        {

            if (entity == null) throw new ArgumentNullException("entity");
            try
            {
                Context.Entry(entity).State = EntityState.Detached;
                using (var context = new LookTechno())
                {
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
