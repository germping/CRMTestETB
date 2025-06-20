using API.Extensiones;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container


builder.Services.AddControllers();
builder.Services.AddServicesApplication(builder.Configuration);
builder.Services.AddServicesAuthenticate(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Configuracion cors
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();