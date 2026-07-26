using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/stations")]
public class StationController : ControllerBase
{
    private readonly IStationService _service;

    public StationController(IStationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateStation([FromBody] CreateStationRequest request)
    {
        var result = await _service.CreateStationAsync(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStations()
    {
        var result = await _service.GetAllStationsAsync();
        return Ok(result);
    }

    [HttpGet("{stationId}")]
    public async Task<IActionResult> GetStationById(string stationId)
    {
        var result = await _service.GetStationByIdAsync(stationId);
        if (result == null) return NotFound();
        return Ok(result);
    }
}