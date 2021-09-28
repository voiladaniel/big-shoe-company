// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlManager.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The XmlManager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.BusinessLogic.Managers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    using Big.Shoe.Company.Core.Managers;
    using Big.Shoe.Company.Core.Models;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The XML Manager.
    /// </summary>
    public class XmlManager : IXmlManager
    {
        /// <summary>
        /// The Logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// The validation manager.
        /// </summary>
        private readonly IValidationManager _validationManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlManager"/> class.
        /// </summary>
        /// <param name="logger">
        /// The Logger.
        /// </param>
        /// <param name="validationManager">
        /// The Validation Manager.
        /// </param>
        public XmlManager(ILogger logger, IValidationManager validationManager)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validationManager = validationManager ?? throw new ArgumentNullException(nameof(validationManager));
        }

        /// <summary>
        /// Process XML Data async.
        /// </summary>
        /// <param name="xmlFile">The XML File.</param>
        /// <returns>A list of orders.</returns>
        public async Task<OrderItems> ProcessDataAsync(XmlFileModel xmlFile)
        {
            try
            {
                _logger.LogInformation($"XmlManager - Process XML File started: {xmlFile.FileName}");

                XmlSchemaSet schema = new XmlSchemaSet();
                schema.Add(null, "OrderImportValidation.xsd");

                string path = Path.Combine(Directory.GetCurrentDirectory(), "CustomOrders", xmlFile.FileName);

                // Create the file local.
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    xmlFile.FormFile.CopyTo(stream);
                }

                // Validate agaisnt XSD.
                using (var rd = XmlReader.Create(path))
                {
                    XDocument doc = XDocument.Load(rd);
                    doc.Validate(schema, ValidationEventHandler);
                }

                var serializer = new XmlSerializer(typeof(OrderItems));

                // Deserialize and validate date.
                using (var reader = new FileStream($"CustomOrders\\{xmlFile.FileName}", FileMode.Open))
                {
                    var orders = (OrderItems)serializer.Deserialize(reader);

                    await _validationManager.ValidateOrdersDate(orders.ToList());

                    _logger.LogInformation($"XmlManager - Process XML File completed: {xmlFile.FileName}");

                    return await Task.FromResult(orders);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"XmlManager - Processig XML file NOT succesfull: {xmlFile.FileName}, Error: {e.Message}");

                throw;
            }
        }

        /// <summary>
        /// The validation handler for XSD.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The ValidationEventArgs.</param>
        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (Enum.TryParse("Error", out XmlSeverityType type))
            {
                if (type == XmlSeverityType.Error) 
                { 
                    throw new Exception(e.Message); 
                }
            }
        }
    }
}
