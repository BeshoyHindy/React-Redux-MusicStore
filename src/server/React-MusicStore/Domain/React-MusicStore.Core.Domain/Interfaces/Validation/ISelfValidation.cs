using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}