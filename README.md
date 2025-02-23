# Zoho API for .NET

## A .NET library for using Zoho's OAuth-protected APIs.

**Primary Goal:** Provide the developer community with a concise solution for Zoho's OAuth-protected APIs. I plan to keep this library updated with Zoho's latest API versions.

### Why are we using OAuth-protected APIs?

Traditionally, in client-server authentication models, to provide third-party applications access to restricted resources, the resource owner has to share their credentials with the third party.

#### Here are the issues and limitations:

- The third-party app needs to store the credentials for future use.
- Servers require password authentication, inheriting the security weaknesses of passwords.
- Limited scope for restricting access to protected resources.
- If the resource owner changes their credentials, it revokes access for all third parties.

### Abstract: How OAuth Works

Reference: [OAuth 2.0 RFC](https://datatracker.ietf.org/doc/html/rfc6749#section-2.1)

### Advantages of OAuth 2.0
- Clients are not required to support password authentication or store user credentials, as authentication and authorization are done through OAuth tokens.
- Clients gain delegated access, i.e., access only to resources authorized by the user.
- Users can revoke third-party application delegated access at any time.
- OAuth access tokens expire after a set time. If the client faces a security breach, user data will be compromised only until the access token is valid.

### Abstract: How this project works

There are two types of flows to generate an access token via OAuth 2.0:
- **Authorization Code Flow**
    - We want to use the Authorization Code Flow for applications that are considered public, where credentials are exposed. This adds an additional layer of security to prevent malicious attempts.
    - Examples:
        - Server-based apps
        - Mobile & desktop apps
        - Client-based apps
            - SPA (performs logic directly in the browser using JS)
 
- **Implicit Flow**
    - We want to use the Implicit Flow when we know our application is at zero risk of exposing client credentials.
        - Self-client

- **Device Authorization Grant Flow**
    - We want to use this flow when the app runs on devices with limited capabilities, like a TV or printer.

### Features

- OAuth 2.0 authentication flow for Zoho API.
- Refresh token management.
- Secure API requests using access tokens.
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