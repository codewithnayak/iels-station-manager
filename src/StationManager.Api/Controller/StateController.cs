using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/states")]
public class StateController : ControllerBase
{
    private readonly IStateService _service;

    public StateController(IStateService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateState([FromBody] CreateStateRequest request)
    {
        var result = await _service.CreateStateAsync(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStates()
    {
        var result = await _service.GetAllStatesAsync();
        return Ok(result);
    }

    [HttpGet("{stateCode}")]
    public async Task<IActionResult> GetStateByCode(string stateCode)
    {
        var result = await _service.GetStateByCodeAsync(stateCode);
        if (result == null) return NotFound();
        return Ok(result);
    }
}