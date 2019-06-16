using css.Resource.Access.DataTransferObjects.Common;
using css.Resource.Access.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace css.Resource.Access.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : BaseController
    {
        private IPingHandler PingHandler { get; }

        public PingController(IPingHandler pingHandler)
        {
            PingHandler = pingHandler;
        }

        [HttpGet]
        public ActionResult<PingResponseDto> Ping()
        {
            return Execute(nameof(Ping), () => PingHandler.Ping());
        }
    }
}
