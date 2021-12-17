using Microsoft.AspNetCore.Mvc;
using StateService.Services;

namespace StateService.Controllers
{
  [ApiController]
  public class StateController : ControllerBase
  {
    private readonly StateService<int> stateService;

    public StateController(StateService<int> stateService)
      => this.stateService = stateService;

    // GET: api/<StateController>
    [HttpGet("state/{user}")]
    public ActionResult<int> Get([FromRoute] string user)
      => Ok(this.stateService.GetState(user));

    // POST api/<StateController>
    [HttpPost("state/{user}")]
    public void Post([FromRoute] string user, [FromBody] int state)
      => this.stateService.SetState(user, state);
  }
}
