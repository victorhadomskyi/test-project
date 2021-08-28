using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Constants;
using UrlShortener.Domain;
using UrlShortener.Enums;
using UrlShortener.Helpers.Interfaces;
using UrlShortener.Models;
using UrlShortener.Repositories.Interfaces;
using UrlShortener.Services.Interfaces;

namespace UrlShortener.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly IEncryptedUrlRepository _repository;
        private readonly IEncryptionHelper _helper;

        public UrlShortenerService(IEncryptedUrlRepository repository,
            IEncryptionHelper helper)
        {
            _repository = repository;
            _helper = helper;
        }

        public async Task<Response<string>> AddEncodedUrlAsync(string url, string baseUrl)
        {
            var encrypted = new EncyptedUrl
            {
                Url = url,
                EncryptedUrl = baseUrl + _helper.EncryptUrl(url)
            };

            var encryptedUrl = await _repository.AddAsync(encrypted);

            var response = new Response<string>();

            if(encryptedUrl != null)
            {
                response.Data = encryptedUrl;
                return response;
            }

            response.Status = DataStatus.BadRequest;
            response.AddError(ApplicationConstants.UrlAlreadyExists);
            return response;
        }

        public async Task<Response<List<string>>> GetAsync()
        {
            var encyptedUrls = await _repository.GetAsync();

            return new Response<List<string>>
            {
                Data = encyptedUrls.Select(encUrl => encUrl.EncryptedUrl).ToList()
            };
        }

        public async Task<Response<string>> GetAsync(string encryptedUrl)
        {
            var encyptedUrl = await _repository.GetAsync(encryptedUrl);

            var response = new Response<string>();

            if (encyptedUrl != null)
            {
                response.Data = encyptedUrl.Url;
                return response;
            }

            response.Status = DataStatus.NotFound;
            response.AddError(ApplicationConstants.UrlDoesntExist);
            return response;
        }
    }
}
