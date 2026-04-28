using PhishingDetectionTool.Application.DTOs.Phishing;
using PhishingDetectionTool.Application.Interfaces;
using System.Text.RegularExpressions;

namespace PhishingDetectionTool.Application.Services;

public class PhishingAnalyzerService : IPhishingAnalyzerService
{
    public AnalyzeUrlResponseDto AnalyzeUrl(AnalyzeUrlRequestDto request)
    {
        if (!Uri.TryCreate(request.Url, UriKind.Absolute, out var uri)) //kullanıcıdan gelen url yi alır
        {                                          //gerçek bir url mi (https://google.com)
                                                   //protocol + domain formatında mı
                                                   //geçerliyse bir uri objesi üretir. değilse öldürür
            return new AnalyzeUrlResponseDto
            {
                RiskScore = 0,
                IsPhishing = false, //Bu URL değil, analiz yapılmaz,phishing le ilgili değil
                Indicators = new List<string> { "Geçersiz URL formatı !" }
            };
        }
        
        var url = request.Url.ToLower(); // url büyük harf gelirse diye küçültüyoruz,TAM URL
        string host = uri.Host.ToLower();//SADECE DOMAIN KISMI

        var indicators = new List<string>(); //phishing göstergelerini tutacak
        int riskScore = 0;
        
        
        if (Regex.IsMatch(host, @"^\d{1,3}(\.\d{1,3}){3}$")) //1/2/3 haneli bir sayı mı
        {
            riskScore += 30;
            indicators.Add("URL domain yerine IP adresi kullanıyor !");
        }
        
        var domainParts = host.Split('.'); //Çok fazla subdomain var mı kontrolü

        if (domainParts.Length > 4)
        {
            riskScore += 20;
            indicators.Add("URL çok fazla subdomain içeriyor !");
        }
        

        // URL uzunluğu kontrolü
        if (url.Length > 75)
        {
            indicators.Add("URL çok uzun!");
            riskScore += 20;
        }
        

        // phishing anahtar kelimesi var mı 
        if (host.Contains("login") || host.Contains("verify") || host.Contains("account"))
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