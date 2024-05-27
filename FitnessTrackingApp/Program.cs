using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.Decorators;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Middleware;
using FitnessTrackingApp.ServerApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// Add Swagger services
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Workout API",
        Version = "v1"
    });
});

// Add controllers and other services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserExerciseService, UserExerciseService>();
builder.Services.AddScoped<IHistoryService,  HistoryService>();
builder.Services.AddDbContext<WorkoutContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("Host"));
});

builder.Services.AddSingleton<ICustomLogger, CustomLogger>();
//builder.Services.Decorate<IWorkoutService, ExampleDecorator>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseMiddleware<LoggingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("corsapp");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Workout API v1");
});
/*
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
*/
app.MapControllers();
app.Run();