using PhishingDetectionTool.Application.DTOs.Phishing;
using PhishingDetectionTool.Application.Interfaces;

namespace PhishingDetectionTool.Application.Services;

public class PhishingAnalyzerService : IPhishingAnalyzerService
{
    public AnalyzeUrlResponseDto AnalyzeUrl(AnalyzeUrlRequestDto request)
    {
        var indicators = new List<string>(); //phishing göstergelerini tutacak.
        int riskScore = 0;

        var url = request.Url.ToLower(); //url büyük harflerle gelirse diye küçültüyoruz

        // URL uzunluğu kontrolü
        if (url.Length > 75)
        {
            indicators.Add("URL çok uzun!");
            riskScore += 20;
        }

        // IP adresi içeriyor mu
        if (url.Contains("192.") || url.Contains("127.") || url.Contains("0.0."))
        {
            indicators.Add("URL IP adresi içeriyor!");
            riskScore += 30;
        }

        // phishing anahtar kelimesi var mı 
        if (url.Contains("login") || url.Contains("verify") || url.Contains("account"))
        {
            indicators.Add("URL şüpheli anahtar kelime içeriyor!");
            riskScore += 20;
        }

        bool isPhishing = riskScore >= 50;

        return new AnalyzeUrlResponseDto
        {
            RiskScore = riskScore,
            IsPhishing = isPhishing,
            Indicators = indicators
        };
    }
}