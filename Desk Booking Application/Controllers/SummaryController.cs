using Desk_Booking_Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SummaryController : ControllerBase
{
    private readonly ISummaryService _summaryService;

    public SummaryController(ISummaryService summaryService)
    {
        _summaryService = summaryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSummary()
    {
        var summary = await _summaryService.GetSummaryAsync();
        return Ok(summary);
    }
}
