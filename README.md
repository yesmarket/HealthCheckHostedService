# HealthCheckHostedService

As a fallback option for scenarios where Kestrel or ASP.NET Core hosting is unsuitable, an HttpListener based health-check server implementation is also available.

```c#
var healthCheckServer = new HealthCheckServer(port: 1234, provider.GetService<HealthCheckService>());
healthCheckServer.Start();
```

The default configuration will expose health-check endpoint at `/health`.
