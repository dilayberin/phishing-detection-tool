using Microsoft.AspNetCore.Mvc;
using PhishingDetectionTool.Application.DTOs.Phishing;
using PhishingDetectionTool.Application.Interfaces;

namespace PhishingDetectionTool.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhishingController : ControllerBase
{
    private readonly IPhishingAnalyzerService _analyzer;

    public PhishingController(IPhishingAnalyzerService analyzer)
    {
        _analyzer = analyzer;
    }

    [HttpPost("analyze-url")]
    public IActionResult AnalyzeUrl([FromBody] AnalyzeUrlRequestDto request)
    {
        var result = _analyzer.AnalyzeUrl(request);
        return Ok(result);
    }
}