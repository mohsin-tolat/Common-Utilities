
using System;
using System.Net;
using EncryptionUtility.API.Interfaces;
using EncryptionUtility.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EncryptionUtility.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EncryptionController : ControllerBase
    {
        private readonly ILogger<EncryptionController> logger;
        private readonly IEncryptionService encryptionService;

        public EncryptionController(ILogger<EncryptionController> logger, IEncryptionService encryptionService)
        {
            this.logger = logger;
            this.encryptionService = encryptionService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetEncryptedValue([FromQuery] string plainText)
        {
            try
            {
                ApiOutput<string> apiOutput = new ApiOutput<string>();
                apiOutput.Result = this.encryptionService.ToEncrypt(plainText);
                apiOutput.StatusCode = (int)HttpStatusCode.OK;
                apiOutput.Error = string.Empty;
                return Ok(apiOutput);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error Occurred in GetEncryptedValue");
                return BadRequest("Error Occurred in GetEncryptedValue");
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDecryptedValue([FromQuery] string encryptedText)
        {
            try
            {
                ApiOutput<string> apiOutput = new ApiOutput<string>();
                apiOutput.Result = this.encryptionService.ToDecrypt(encryptedText);
                apiOutput.StatusCode = (int)HttpStatusCode.OK;
                apiOutput.Error = string.Empty;
                return Ok(apiOutput);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Error Occurred in GetDecryptedValue");
                return BadRequest("Error Occurred in GetDecryptedValue");
            }
        }
    }
}