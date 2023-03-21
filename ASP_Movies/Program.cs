using ASP_Movies.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMovieApiService, MovieApiService>();//создается новый обект на каждое обращение
//builder.Services.AddTransient<MovieApiService>();//при обращении создается один обект при выходе из контроллера уничтожается
//builder.Services.AddSingleton<MovieApiService>();//обращение к классу один на весь проек все обращения идут к нему после использования уничтожается
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{title?}");

app.Run();
