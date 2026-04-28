# Phishing Detection API

A basic phishing detection system built with **.NET 9 Web API**.

This project analyzes URLs to see if they might be phishing links by looking for suspicious keywords, strange URL patterns, or IP addresses.

---

## Features

- URL phishing analysis
- Risk scoring system
- Phishing indicator detection
- REST API architecture
- Swagger API documentation

---

## Project Architecture

This project follows a layered architecture:

PhishingDetectionTool

│
├── PhishingDetectionTool.Api → API Controllers
├── PhishingDetectionTool.Application → Business Logic & Services
└── PhishingDetectionTool.Domain → Entities & Core Models

---

## Technologies

- .NET 9
- ASP.NET Core Web API
- Swagger / OpenAPI
- Clean architecture principles

---

## Example Request

POST /api/phishing/analyze-url

{
"url": "http://paypa1-login-security.com
"
}

---

## Example Response

{
"riskScore": 60,
"isPhishing": true,
"indicators": [
"URL şüpheli anahtar kelime içeriyor!",
"URL çok uzun!"
]
}


## Future Improvements

- Domain extraction and analysis
- WHOIS domain age verification
- Subdomain phishing detection
- Integration with phishing datasets

---
