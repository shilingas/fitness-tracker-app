using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WorkoutContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("Host"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<WorkoutContext>();
    var exerciseService = new ExerciseService(context);
    exerciseService.AddExercise(0, "TEST");
}


app.Run();
