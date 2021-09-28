// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The Order object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.Core.Models
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The Order object.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets Customer name.
        /// </summary>
        [XmlAttribute]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets Customer Email.
        /// </summary>
        [XmlAttribute]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets Quantity.
        /// </summary>
        [XmlAttribute]
        public ushort Quantity { get; set; }

        /// <summary>
        /// Gets or sets Notes.
        /// </summary>
        [XmlAttribute]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets Size.
        /// </summary>
        [XmlAttribute]
        public float Size { get; set; }

        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        [XmlAttribute]
        public DateTime DateRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Date is not valid.
        /// </summary>
        public bool HasDateError { get; set; }
    }
}
