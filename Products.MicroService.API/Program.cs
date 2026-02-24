using DataAccessLayer;
using DataLogicLayer;
using FluentValidation.AspNetCore;
using Products.MicroService.API.APIEndPoint;
using Products.MicroService.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapProductAPIEndPoint();

app.Run();
