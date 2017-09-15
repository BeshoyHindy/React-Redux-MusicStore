using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Service;
using ReactMusicStore.Core.Domain.Validation;
using ReactMusicStore.Services.Interfaces;

namespace ReactMusicStore.Services
{
	public class AlbumAppService : AppService<DbMusicStoreContext>, IAlbumAppService
	{
		private readonly IAlbumService _service;

		public AlbumAppService(IAlbumService albumService)
		{
			_service = albumService;
			//_service = ServiceLocator.Current.GetInstance<IAlbumService>(); 
		}


		public ValidationResult Create(Album orderDetail)
		{
			BeginTransaction();
			ValidationResult.Add(_service.Add(orderDetail));
			if (ValidationResult.IsValid) Commit();

			return ValidationResult;
		}

		public ValidationResult Update(Album orderDetail)
		{
			BeginTransaction();
			ValidationResult.Add(_service.Update(orderDetail));
			if (ValidationResult.IsValid) Commit();

			return ValidationResult;
		}

		public ValidationResult Remove(Album orderDetail)
		{
			BeginTransaction();
			ValidationResult.Add(_service.Delete(orderDetail));
			if (ValidationResult.IsValid) Commit();

			return ValidationResult;
		}

		public Album Get(int id, bool @readonly = false)
		{
			return _service.Get(id, @readonly);
		}

		public IEnumerable<Album> All(bool @readonly = false)
		{
			return _service.All(@readonly);
		}

		public IEnumerable<Album> Find(Expression<Func<Album, bool>> predicate, bool @readonly = false)
		{
			return _service.Find(predicate, @readonly);
		}

		public IEnumerable<Album> GetTopSellingAlbums(int count)
		{
			// Group the order details by album and return
			// the albums with the highest count
			return _service.All()
				.OrderByDescending(a => a.OrderDetails.Count())
				.Take(count)
				.ToList();
		}

		#region Dispose

		public virtual void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		#endregion
	}
}