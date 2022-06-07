using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Task5Back.Authorization;
using Task5Back.Helpers;
using Task5Back.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddCors();

WebApplication app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

using (IServiceScope scope = app.Services.CreateScope())
{
    DataContext dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dataContext.Database.Migrate();
}

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseMiddleware<NameMiddleware>();

app.MapControllers();

app.Run();
