using Microsoft.Practices.ServiceLocation;
using ReactMusicStore.Core.Data.Context.Interfaces;
using ReactMusicStore.Core.Domain.Validation;
using ReactMusicStore.Services.Interfaces.Common;

namespace ReactMusicStore.Services
{
    public class AppService<TContext> : ITransactionAppService<TContext>
        where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _unitOfWork;

        public AppService()
        {
            ValidationResult = new ValidationResult();
        }

        protected ValidationResult ValidationResult { get; private set; }

        public virtual void BeginTransaction()
        {
            _unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _unitOfWork.BeginTransaction();
        }

        public virtual void Commit()
        {
            _unitOfWork.SaveChanges();
        }
    }

}
