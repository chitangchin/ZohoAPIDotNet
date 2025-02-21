# Zoho API for .NET

## A .NET library for using Zoho's OAuth-protected APIs.

### Features

- OAuth 2.0 authentication flow for Zoho API.
- Refresh token management.
- Secure API requests using access tokens.
- Simplified API interaction with Zoho services.
    - Zoho CRM
    - Zoho Books
    - Zoho Subscriptions

### Running Tests

## **2. Install Dependencies**  
```bash
dotnet restore
```

## **3. Securely Store API Keys**  
Use `.NET user-secrets` to store **Client ID, Client Secret, and Org ID**.  

You can generate your Client ID and Client Secret:
https://api-console.zoho.com/client

```bash
dotnet user-secrets init
dotnet user-secrets set "clientId" "1000.xxxxxxxxxxxxxxxxxxxxx"
dotnet user-secrets set "clientSecret" "bxxxxxxxxxxxxxxxxxxxxxxxxxxxxa"
dotnet user-secrets set "orgId" "xxxxxxxx"
```





