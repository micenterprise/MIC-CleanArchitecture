using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Website.Controllers;

[Controller]
public abstract class MainControllerBase : Controller
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}