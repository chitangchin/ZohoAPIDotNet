# Zoho API for .NET

## A NuGET Package for Zoho's OAuth-protected APIs.

- Simplified API interaction with Zoho services (e.g., Zoho CRM).

### Running Tests

#### 1. Clone the repository
```bash
git clone https://github.com/chitangchin/ZohoAPIDotNet.git
```

#### 2. Install dependencies and build
```bash
dotnet restore
dotnet build
```

#### 3. Securely store API keys  
Use `.NET user-secrets` to store **Client ID, Client Secret, and Org ID**.  

You can generate your Client ID and Client Secret at:  
[Zoho API Console](https://api-console.zoho.com/client)

```bash
dotnet user-secrets init
dotnet user-secrets set "clientId" "1000.xxxxxxxxxxxxxxxxxxxxx"
dotnet user-secrets set "clientSecret" "bxxxxxxxxxxxxxxxxxxxxxxxxxxxxa"
dotnet user-secrets set "orgId" "xxxxxxxx"
```

#### 4. Run Tests
```bash
dotnet test
```
