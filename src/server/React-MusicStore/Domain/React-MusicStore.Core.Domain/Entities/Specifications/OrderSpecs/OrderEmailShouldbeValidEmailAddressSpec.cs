﻿using System.Text.RegularExpressions;
using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.OrderSpecs
{
    public class OrderEmailShouldbeValidEmailAddressSpec : ISpecification<Order>
    {
        public bool IsSatisfiedBy(Order order)
        {
            // RFC 5322 - 99.99%
            const string emailRegExpPattern =
                @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

            return Regex.IsMatch(order.Email, emailRegExpPattern);
        }
    }
}
