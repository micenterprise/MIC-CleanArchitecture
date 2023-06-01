using CleanArchitecture.Application.TodoLists.Queries.GetTodos;
using CleanArchitecture.Website.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class TodoController : MainControllerBase
{
    [Authorize]
    public async Task<IActionResult> Index()
    {    
        return View(await Mediator.Send(new GetTodosQuery()));
    }
}
