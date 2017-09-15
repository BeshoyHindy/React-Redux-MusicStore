﻿using System.Collections.Generic;
using ReactMusicStore.Core.Domain.Entities.Foundation;
using ReactMusicStore.Core.Domain.Entities.Validations;
using ReactMusicStore.Core.Domain.Interfaces.Validation;
using ReactMusicStore.Core.Domain.Validation;

namespace ReactMusicStore.Core.Domain.Entities
{
    public class Album : BaseEntity, ISelfValidation
    {
        //public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool IsValid
        {
            get
            {
                var fiscal = new AlbumIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }
    }
}