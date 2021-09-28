// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlController.cs" company="Daniel Voila">
//   Copyright (c) Daniel Voila. All rights reserved.
// </copyright>
// <summary>
//   The XmlController.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Big.Shoe.Company.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Xml.Schema;

    using Big.Shoe.Company.Core.Managers;
    using Big.Shoe.Company.Core.Models;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The XML Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class XmlController : Controller
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// The XML manager.
        /// </summary>
        private readonly IXmlManager _xmlManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlController"/> class.
        /// </summary>
        /// <param name="logger">
        /// The Logger.
        /// </param>
        /// <param name="xmlManager">
        /// The XML Manager.
        /// </param>
        public XmlController(ILogger logger, IXmlManager xmlManager)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _xmlManager = xmlManager ?? throw new ArgumentNullException(nameof(xmlManager));
        }

        /// <summary>
        /// Process XML file async.
        /// </summary>
        /// <param name="xmlFile">The XML file uploaded.</param>
        /// <returns>A list of orders.</returns>
        [HttpPost]
        [Route("ProcessXmlFile")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ProcessXmlFileAsync([FromForm] XmlFileModel xmlFile)
        {
            try
            {
                _logger.LogInformation($"XmlController - Processing XML file started: {xmlFile.FileName}");

                if (xmlFile == null)
                {
                    _logger.LogWarning($"XmlController - XML file is null");

                    return BadRequest();
                }

                var orders = await _xmlManager.ProcessDataAsync(xmlFile);

                _logger.LogInformation($"XmlController - Processing XML file completed: {xmlFile.FileName}");

                return Ok(orders);
            }
            catch (XmlSchemaValidationException ex)
            {
                _logger.LogWarning($"XmlController - Processing XML file Validation NOT succesfull: {xmlFile.FileName}, Error: {ex.Message}");

                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"XmlController - Processing XML file NOT succesfull: {xmlFile.FileName}, Error: {ex.Message}");

                return StatusCode(500, ex);
            }
        }
    }
}