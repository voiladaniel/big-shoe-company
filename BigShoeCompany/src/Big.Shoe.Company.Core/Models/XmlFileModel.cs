// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlFileModel.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The XmlFileModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.Core.Models
{
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// The XML File Model.
    /// </summary>
    public class XmlFileModel
    {
        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the FormFile.
        /// </summary>
        public IFormFile FormFile { get; set; }
    }
}
