# DEMO .NET user-secrets in integration tests

How can use the users secrets in integration tests



## Configure the secrets in project

**Go to the root folder of the project**
```bash
cd src
```


**Init the user secrets**
```bash
dotnet user-secrets init
```


**Add a secret**
```bash
dotnet user-secrets set "DemoProperty" "DemoUserSicret"
```



## Configure the secrets in tests project


**Copy the same `UserSecretsId` from src project to tests project**
```xml
  <PropertyGroup>
    <UserSecretsId>de928048-cd49-4c8d-afab-c3774bb3177e</UserSecretsId>
  </PropertyGroup>
```

**Configure the `WebApplicationFactory`. Add the line**
```csharp
builder.ConfigureAppConfiguration(c => c.AddUserSecrets(Assembly.GetExecutingAssembly(), true));
```

**E.g:**
```csharp
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Demo.Tests.Config;

public class WebAPIFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseStartup<TEntryPoint>();
        builder.UseEnvironment(Environments.Staging);

        builder.ConfigureAppConfiguration(c => c.AddUserSecrets(Assembly.GetExecutingAssembly(), true));
    }
}
```

---
**NOTE**

Just do this step if you want to use the same secrets.
If you want to use different secrets, generate a different guid and add it to the `UserSecretsId` tests project.

---
