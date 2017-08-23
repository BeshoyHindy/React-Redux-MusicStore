using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Service;
using ReactMusicStore.Core.Domain.Validation;
using ReactMusicStore.Services.Interfaces;

namespace ReactMusicStore.Services
{
    public class OrderAppService : AppService<MusicStoreContext>, IOrderAppService
    {
        private readonly IOrderService _service;

        public OrderAppService(IOrderService orderService)
        {
            _service = orderService;
        }

        public ValidationResult Create(Order order)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Add(order));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Update(Order order)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Update(order));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public ValidationResult Remove(Order order)
        {
            BeginTransaction();
            ValidationResult.Add(_service.Delete(order));
            if (ValidationResult.IsValid) Commit();

            return ValidationResult;
        }

        public Order Get(int id, bool @readonly = false)
        {
            return _service.Get(id, @readonly);
        }

        public IEnumerable<Order> All(bool @readonly = false)
        {
            return _service.All(@readonly);
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate, bool @readonly = false)
        {
            return _service.Find(predicate, @readonly);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}