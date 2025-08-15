using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Api.Member.Controllers.Base
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MemberControllerBase(ISender sender) : ControllerBase
    {
        protected readonly ISender _sender = sender;
    }
}