using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}