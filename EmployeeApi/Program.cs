using Autofac;
using Autofac.Extensions.DependencyInjection;
using EmployeeApi.Data;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Use Autofac as DI container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add controllers & MediatR
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Autofac registrations
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<DapperContext>().AsSelf().SingleInstance();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "Employee API is running. Use /api/employee to get data.");

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
