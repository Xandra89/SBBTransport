using Microsoft.AspNetCore.Mvc;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
public class TransportController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public TransportController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet("connections")]
    public async Task<IActionResult> GetConnections(string from, string to)
    {
        string apiUrl = $"https://transport.opendata.ch/v1/connections?from={from}&to={to}";
        var response = await _httpClient.GetStringAsync(apiUrl);
        
        return Ok(response);
    }
}