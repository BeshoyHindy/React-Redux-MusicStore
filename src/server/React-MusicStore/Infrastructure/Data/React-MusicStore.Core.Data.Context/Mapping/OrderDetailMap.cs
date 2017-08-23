﻿using System.Data.Entity.ModelConfiguration;
using ReactMusicStore.Core.Domain.Entities;

namespace ReactMusicStore.Core.Data.Context.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            // Primary Key
            HasKey(t => t.OrderDetailId);

            // Properties
            Property(t => t.Quantity)
                .IsRequired();

            // Relationship
            HasRequired(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.OrderId);

            HasRequired(t => t.Album)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.AlbumId);

            Ignore(t => t.ValidationResult);
        }
    }
}