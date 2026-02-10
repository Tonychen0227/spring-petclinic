#:sdk Aspire.AppHost.Sdk@13.1.0

var builder = DistributedApplication.CreateBuilder(args);

var petclinic = builder.AddExecutable("petclinic", "cmd.exe", ".", "/c", "mvnw.cmd", "spring-boot:run")
    .WithHttpEndpoint(targetPort: 8080, name: "http", isProxied: false);

builder.Build().Run();
