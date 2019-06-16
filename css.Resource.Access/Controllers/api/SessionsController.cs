using css.Resource.Access.DataTransferObjects.Access;
using css.Resource.Access.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace css.Resource.Access.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : BaseController
    {
        private ISessionsHandler SessionsHandler { get; }

        public SessionsController(ISessionsHandler sessionsHandler)
        {
            SessionsHandler = sessionsHandler;
        }

        [HttpPost]
        public ActionResult<SessionsResponseDto> Create([FromBody] SessionsRequestDto requestDto)
        {
            return Execute(nameof(Create), () => SessionsHandler.Create(requestDto));
        }
    }
}
