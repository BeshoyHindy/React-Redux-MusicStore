using System.Collections.Generic;
using ReactMusicStore.Core.Domain.Entities.Validations;
using ReactMusicStore.Core.Domain.Interfaces.Validation;
using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Entities
{
    public class Genre : ISelfValidation
    {
        public Genre()
        {
            Albums = new List<Album>();
        }

        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Album> Albums { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new GenreIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
