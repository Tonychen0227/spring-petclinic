#:sdk Aspire.AppHost.Sdk@13.1.0
#:package Aspire.Hosting.Azure.PostgreSQL@13.1.0

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddAzurePostgresFlexibleServer("postgres").RunAsContainer();

var petclinicDb = postgres.AddDatabase("petclinic");

var petclinic = builder.AddExecutable("petclinic-exe", "cmd.exe", "..", "/c", "mvnw.cmd", "spring-boot:run", "-Dspring-boot.run.profiles=postgres")
    .WithHttpEndpoint(targetPort: 8080, name: "http", isProxied: false)
    .WithReference(petclinicDb)
    .WaitFor(petclinicDb)
    .WithEnvironment("POSTGRES_JDBC_URL", petclinicDb.Resource.JdbcConnectionString)
    .WithEnvironment("POSTGRES_USER", postgres.Resource.UserName)
    .WithEnvironment("POSTGRES_PASS", postgres.Resource.Password);

builder.Build().Run();
