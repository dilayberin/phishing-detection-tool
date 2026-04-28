namespace PhishingDetectionTool.Application.DTOs.Phishing;

public class AnalyzeUrlResponseDto
{
    public int RiskScore { get; set; }

    public bool IsPhishing { get; set; }

    public List<string> Indicators { get; set; } = new List<string>();}  //saldırı belirtileri