using System.Threading.Tasks;
using API.Models;
using API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vostok.Logging.Abstractions;

namespace API.Controllers
{
    [ApiController]
    [Route("/about/")]
    [Produces("application/json")]
    public class AboutController : Controller
    {
        private readonly IOptionsMonitor<About> aboutOptions;
        private readonly ILog log;
        private const string ControllerName = nameof(AboutController);
        private const string GetAboutMethodName = nameof(GetAbout);
        /// <summary>
        ///     AboutController constructor
        /// </summary>
        /// <param name="aboutOptions">IOptionsMonitor<About></param>
        /// <param name="log"></param>
        public AboutController(IOptionsMonitor<About> aboutOptions, ILog log)
        {
            this.aboutOptions = aboutOptions;
            this.log = log;
        }
        
        /// <summary>
        ///     Returns aboutText
        /// </summary>
        /// <returns>string</returns>
        /// <response code="200">Returns aboutText</response>
        // GET: /about/
        [HttpGet]
        public async Task<ActionResult<string>> GetAbout()
        {
            log.RequestInfo(ControllerName, GetAboutMethodName);
            var about =  aboutOptions.CurrentValue.Text;
            log.ResponseInfo(ControllerName, GetAboutMethodName);
            return Ok(about);
        }
    }
}