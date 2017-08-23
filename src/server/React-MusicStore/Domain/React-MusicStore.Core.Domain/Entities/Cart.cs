using System;
using ReactMusicStore.Core.Domain.Entities.Validations;
using ReactMusicStore.Core.Domain.Interfaces.Validation;
using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Entities
{
    public class Cart : ISelfValidation
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Album Album { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new CartIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}