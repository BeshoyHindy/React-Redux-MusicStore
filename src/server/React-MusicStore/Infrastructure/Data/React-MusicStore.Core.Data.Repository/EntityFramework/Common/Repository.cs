using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.Practices.ServiceLocation;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Data.Context.Interfaces;
using ReactMusicStore.Core.Domain.Interfaces.Repository.Common;

namespace ReactMusicStore.Core.Data.Repository.EntityFramework.Common
{
	public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
	{
		private readonly IDbContext _dbContext;

		public Repository()
		{
			var contextManager = ServiceLocator.Current.GetInstance<IContextManager<DbMusicStoreContext>>()
				as ContextManager<DbMusicStoreContext>;

			_dbContext = contextManager.GetContext();
			DbSet = _dbContext.Set<TEntity>();
		}

		protected IDbContext Context
		{
			get { return _dbContext; }
		}

		protected DbSet<TEntity> DbSet { get; }

		public virtual void Add(TEntity entity)
		{
			DbSet.Add(entity);
		}

		public virtual void Delete(TEntity entity)
		{
			DbSet.Remove(entity);
		}

		public TEntity Get(int id)
		{
			return DbSet.Find(id);
		}

		public virtual void Update(TEntity entity)
		{
			var entry = Context.Entry(entity);
			DbSet.Attach(entity);
			entry.State = EntityState.Modified;
		}

		public virtual IEnumerable<TEntity> All(bool @readonly = false)
		{
			return @readonly
				? DbSet.AsNoTracking().ToList()
				: DbSet.ToList();
		}

		public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
		{
			return @readonly
				? DbSet.Where(predicate).AsNoTracking()
				: DbSet.Where(predicate);
		}

		public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			IQueryable<TEntity> query = DbSet;

			if (filter != null)
			{
				query = query.AsExpandable().Where(filter);
			}

			// applies the eager-loading expressions after parsing the comma-delimited list
			foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			return orderBy != null ? orderBy(query) : query;

		}

		public virtual async Task<ICollection<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			if (selector == null)
				throw new ArgumentNullException("selector");
			IQueryable<TEntity> query = DbSet;

			if (filter != null)
			{
				query = query.AsExpandable().Where(filter);
			}

			// applies the eager-loading expressions after parsing the comma-delimited list
			foreach (var includeProperty in includeProperties.Split
				(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			// applies the eager-loading expressions after parsing the comma-delimited list

			return await (orderBy != null ? orderBy(query).Select(selector).ToListAsync() : query.Select(selector).ToListAsync());
		}

		public virtual TEntity GetById(object id)
		{
			return DbSet.Find(id);
		}

		public virtual async Task<TEntity> GetByAsync(object id)
		{
			return await DbSet.FindAsync(id);
		}

		public virtual TEntity Insert(TEntity entity)
		{
			return DbSet.Add(entity);
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = DbSet.Find(id);
			Delete(entityToDelete);
		}

		//public virtual void Delete(TEntity entityToDelete)
		//{
		//    if (Context.Entry(entityToDelete).State == EntityState.Detached)
		//    {
		//        DbSet.Attach(entityToDelete);
		//    }
		//    DbSet.Remove(entityToDelete);
		//}

		public virtual void Detach(TEntity entityToUpdate)
		{
			Context.Entry(entityToUpdate).State = EntityState.Detached;
		}
		//public virtual void Update(TEntity entityToUpdate)
		//{
		//    DbSet.Attach(entityToUpdate);
		//    Context.Entry(entityToUpdate).State = EntityState.Modified;
		//}

		public virtual void Update(TEntity entityToUpdate, List<string> excluded)
		{
			DbSet.Attach(entityToUpdate);
			var entry = Context.Entry(entityToUpdate);
			entry.State = EntityState.Modified;

			if (excluded != null)
			{
				foreach (var name in excluded)
				{
					entry.Property(name).IsModified = false;
				}
			}
		}

		public virtual void DeleteRange(IQueryable<TEntity> entitiesToDelete)
		{
			foreach (var entity in entitiesToDelete)
			{
				if (Context.Entry(entity).State == EntityState.Detached)
				{
					DbSet.Attach(entity);
				}
			}
			DbSet.RemoveRange(entitiesToDelete.AsEnumerable());
		}



		public void Save()
		{
			Context.SaveChanges();
		}



		public virtual IQueryable<TEntity> Table
		{
			get
			{
				if (_dbContext.ForceNoTracking)
				{
					return this.DbSet.AsNoTracking();
				}
				return this.DbSet;
			}
		}

		public virtual IQueryable<TEntity> TableUntracked
		{
			get
			{
				return this.DbSet.AsNoTracking();
			}
		}

		public virtual ICollection<TEntity> Local
		{
			get
			{
				return this.DbSet.Local;
			}
		}




		#region Dispose

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing) return;

			if (Context == null) return;
			Context.Dispose();
		}

		#endregion
	}
}
