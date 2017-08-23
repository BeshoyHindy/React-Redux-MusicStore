namespace ReactMusicStore.Core.Domain.Interfaces.Specification
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}