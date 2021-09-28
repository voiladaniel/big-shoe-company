// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppSettingsPoco.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The AppSettingsPoco.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.Data.Settings
{
    using Big.Shoe.Company.Core.Data;

    /// <summary>
    /// The POCO for mapping the AppSettings.JSON file.
    /// </summary>
    public class AppSettingsPoco : IAppSettingsPoco
    {
        /// <summary>
        /// Gets or sets the CORS allowed origins.
        /// </summary>
        public string[] CorsAllowedOrigins { get; set; }
    }
}
