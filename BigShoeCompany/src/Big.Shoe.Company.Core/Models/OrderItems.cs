// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderItems.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The OrderItems object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.Core.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// The object for mapping the XML object.
    /// </summary>
    [XmlRoot(ElementName = "BigShoeDataImport")]
    public class OrderItems : List<Order>
    {
    }
}
