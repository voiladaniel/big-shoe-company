// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValidationManager.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The Interface for Validation Manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.Core.Managers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Big.Shoe.Company.Core.Models;

    /// <summary>
    /// The interface for Validation Manager.
    /// </summary>
    public interface IValidationManager
    {
        /// <summary>
        /// Validate Orders Date.
        /// </summary>
        /// <param name="orders">The list of orders.</param>
        /// <returns>A list of orders with date validated.</returns>
        Task<List<Order>> ValidateOrdersDate(List<Order> orders);
    }
}
