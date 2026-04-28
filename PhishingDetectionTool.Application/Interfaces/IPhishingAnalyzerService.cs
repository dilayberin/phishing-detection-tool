using PhishingDetectionTool.Application.DTOs.Phishing;

namespace PhishingDetectionTool.Application.Interfaces;

public interface IPhishingAnalyzerService//ınput:AnalyzeUrlRequestDto output:AnalyzeUrlResponseDto
{
    AnalyzeUrlResponseDto AnalyzeUrl(AnalyzeUrlRequestDto request);//Bu servisin bir metodu olacak ve URL analiz edecek.
}