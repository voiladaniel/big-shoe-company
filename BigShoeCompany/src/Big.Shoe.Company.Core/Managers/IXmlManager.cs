// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXmlManager.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The Interface for XML Manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.Core.Managers
{
    using System.Threading.Tasks;

    using Big.Shoe.Company.Core.Models;

    /// <summary>
    /// The Interface for XML Manager.
    /// </summary>
    public interface IXmlManager
    {
        /// <summary>
        /// Process XML Data async.
        /// </summary>
        /// <param name="xmlFile">The XML File.</param>
        /// <returns>A list of orders.</returns>
        Task<OrderItems> ProcessDataAsync(XmlFileModel xmlFile);
    }
}
