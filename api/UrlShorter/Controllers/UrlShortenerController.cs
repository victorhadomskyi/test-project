using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortener.Controllers;
using UrlShortener.Dtos;
using UrlShortener.Filters;
using UrlShortener.Services.Interfaces;

namespace UrlShorter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlShortenerController : BaseController
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlShortenerController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> Get()
        {
            var response = await _urlShortenerService.GetAsync();
            return GetResponse(response);
        }

        [HttpGet("{encryptedUrl}")]
        public async Task<ActionResult<string>> Get([FromRoute] string encryptedUrl)
        {
            var baseUrl = GetBaseUrl();
            var response = await _urlShortenerService.GetAsync(baseUrl + encryptedUrl);
            var result = GetResponse(response);
            if (result.Result is OkObjectResult)
            {
                return Redirect(response.Data);
            }

            return result;
        }

        [HttpPost]
        [ModelStateValidation]
        public async Task<ActionResult<string>> Post([FromBody] AddShortenedUrlDto dto)
        {
            var baseUrl = GetBaseUrl();
            var response = await _urlShortenerService.AddEncodedUrlAsync(dto.Url, baseUrl);
            return GetResponse(response);
        }

        private string GetBaseUrl()
        {
            return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}/UrlShortener/";
        }
    }
}
