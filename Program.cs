using ABDM.ExternalServices;
using ABDM.Middleware;
using Serilog;
using Serilog.Exceptions;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithExceptionDetails()
    .WriteTo.Console()
    .WriteTo.File("Logs/app-log",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
     .CreateLogger();

try
{
    Log.Information("Application Starts.");

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddSwaggerGen();


    // Add Cors 
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            builder => builder
                .WithOrigins("http://localhost:5173", "http://localhost:5173/", "https://localhost:5173")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
    });
    // End Cord



    // Register Services as dependency Injections 
    builder.Services.AddHttpClient();
    builder.Services.AddScoped<IAuthServices, AuthServices>(); // Authentication Service 
    builder.Services.AddScoped<IAadhaarServices, AadhaarServices>(); // Aadhaar Services  

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<GlobalExceptionMiddleware>(); //  Exception Handle Middleware 

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseCors("AllowAll");

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush(); // ensures all logs are flushed on exit
}