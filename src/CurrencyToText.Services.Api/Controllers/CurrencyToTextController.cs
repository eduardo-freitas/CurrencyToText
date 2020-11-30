using System;
using System.ComponentModel.DataAnnotations;
using CurrencyToText.Domain.Business;
using CurrencyToText.Domain.Contract;
using CurrencyToText.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyToText.Services.Api.Controllers
{
    [Route("api/currency-to-words")]
    [ApiController]
    public class CurrencyToTextController : ControllerBase
    {
        private readonly IConversionToWordsManager _conversionToWordsManager;
        public CurrencyToTextController(IConversionToWordsManager conversionToWordsManager)
        {
            this._conversionToWordsManager = conversionToWordsManager;
        }

        [HttpPost]
        public IActionResult ConvertFromCurrencyToWords([FromBody][Required] CurrencyValueToConvert currencyValue)
        {
            try
            {
                var response = _conversionToWordsManager.ConvertToWords(currencyValue);

                if (response.DomainError != null)
                {
                    return new BadRequestObjectResult(response.DomainError);
                }

                return new OkObjectResult(response.Result);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
