// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationManager.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The ValidationManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.BusinessLogic.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Big.Shoe.Company.Core.Managers;
    using Big.Shoe.Company.Core.Models;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The Validation Manager.
    /// </summary>
    public class ValidationManager : IValidationManager
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationManager"/> class.
        /// </summary>
        /// <param name="logger">
        /// The Logger.
        /// </param>
        public ValidationManager(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Validate Orders Date.
        /// </summary>
        /// <param name="orders">The list of orders.</param>
        /// <returns>A list of orders with date validated.</returns>
        public async Task<List<Order>> ValidateOrdersDate(List<Order> orders)
        {
            _logger.LogInformation($"ValidationManager - Validation for Orders date started: {orders}");

            orders.ForEach(x =>
            {
                x.HasDateError = x.DateRequired < DateTime.Now || (x.DateRequired > DateTime.Now && x.DateRequired < DateTime.Now.AddDays(10));
            });

            _logger.LogInformation($"ValidationManager - Validation for Orders date completed: {orders}");

            return await Task.FromResult(orders);
        }
    }
}
