// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAppSettingsPoco.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The Interface for AppSettingsPoco.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.Core.Data
{
    /// <summary>
    /// The interface for POCO for mapping the AppSettings.JSON file.
    /// </summary>
    public interface IAppSettingsPoco
    {
        /// <summary>
        /// Gets or sets the CORS allowed origins.
        /// </summary>
        string[] CorsAllowedOrigins { get; set; }
    }
}
