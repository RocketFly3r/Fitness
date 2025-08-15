using Fitness.Api.Member.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Api.Member.Controllers;


public sealed class MemberController(ISender sender) : MemberControllerBase(sender)
{
    [HttpPost]
    public async Task<IActionResult> LoginAsync() => await Task.FromResult(new OkObjectResult("Login successful"));
}