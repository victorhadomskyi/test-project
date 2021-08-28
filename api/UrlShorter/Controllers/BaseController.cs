using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UrlShortener.Enums;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult<TResponse> GetResponse<TResponse>(Response<TResponse> responseModel)
        {
            if (responseModel.Status == DataStatus.BadRequest)
            {
                return BadRequest(responseModel.Errors);
            }
            else if (responseModel.Status == DataStatus.NotFound)
            {
                return NotFound(responseModel.Errors);
            }

            return Ok(JsonConvert.SerializeObject(responseModel.Data));
        }
    }
}
