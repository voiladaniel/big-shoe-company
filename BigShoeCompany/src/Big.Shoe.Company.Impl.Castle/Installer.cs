// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Installer.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The Installer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Big.Shoe.Company.Impl.Castle
{
    using Big.Shoe.Company.BusinessLogic.Managers;
    using Big.Shoe.Company.Core.Data;
    using Big.Shoe.Company.Core.Managers;
    using Big.Shoe.Company.Data.Settings;

    /// <summary>
    /// <inheritdoc cref="Installer"/>
    /// </summary>
    public class Installer : IWindsorInstaller
    {
        /// <summary>
        /// The AppSettings.JSON configuration file, mapped into a POCO for type-safety.
        /// </summary>
        private readonly IAppSettingsPoco _appSettingsPoco;

        /// <summary>
        /// Initializes a new instance of the <see cref="Installer"/> class.
        /// </summary>
        /// <param name="appSettingsPoco">
        /// The app settings easy config POCO.
        /// </param>
        public Installer(IAppSettingsPoco appSettingsPoco)
        {
            _appSettingsPoco = appSettingsPoco;
        }

        /// <summary>
        /// <inheritdoc cref="Installer"/>
        /// </summary>
        /// <param name="container">
        /// the container.
        /// </param>
        /// <param name="store">
        /// The ConfigurationStore.
        /// </param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IAppSettingsPoco>().ImplementedBy<AppSettingsPoco>()
                    .DependsOn(_appSettingsPoco)
                    .LifestyleSingleton(),
                  Component.For<IXmlManager>().ImplementedBy<XmlManager>().LifestyleScoped(),
                  Component.For<IValidationManager>().ImplementedBy<ValidationManager>().LifestyleScoped());
        }
    }
}
