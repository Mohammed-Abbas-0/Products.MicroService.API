using DataAccessLayer;
using DataLogicLayer;
using Products.MicroService.API.APIEndPoint;
using Products.MicroService.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

//  "category": "Electronics",
// ??? ???? ????????? ?? int
//  "category": 1,  ????? ??? ???
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(
        new System.Text.Json.Serialization.JsonStringEnumConverter());
});
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapProductAPIEndPoint();

app.Run();
