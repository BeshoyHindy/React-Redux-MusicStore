using System.Collections.Generic;
using ReactMusicStore.Core.Domain.Entities.Validations;
using ReactMusicStore.Core.Domain.Interfaces.Validation;
using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Entities
{
    public class Artist : ISelfValidation
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new ArtistIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}