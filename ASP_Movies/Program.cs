using ASP_Movies.Extension;
using ASP_Movies.Options;
using ASP_Movies.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IRecentMoviesStorage, RecentMoviesStorage>();//
//builder.Services.AddScoped<IMovieApiService, MovieApiService>();//��������� ����� ����� �� ������ ���������
//builder.Services.AddTransient<MovieApiService>();//��� ��������� ��������� ���� ����� ��� ������ �� ����������� ������������
//builder.Services.AddSingleton<MovieApiService>();//��������� � ������ ���� �� ���� ����� ��� ��������� ���� � ���� ����� ������������� ������������
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();//����������� �����������



//builder.Services.Configure<MovieApiOptions>(options =>
//{
//	options.ApiKey = builder.Configuration["MovieApi:ApiKey"];
//	options.BaseUrl = builder.Configuration["MovieApi:BaseUrl"];

//});
builder.Services.AddMovieApi(options =>
{
	options.ApiKey = builder.Configuration["MovieApi:ApiKey"];
	options.BaseUrl = builder.Configuration["MovieApi:BaseUrl"];

});


Console.WriteLine("/////////");
Console.WriteLine(builder.Configuration.GetSection("MovieApi").GetValue<string>("BaseUrl"));
Console.WriteLine(builder.Configuration["MovieApi:BaseUrl"]);
Console.WriteLine(builder.Configuration["MovieApi:ApiKey"]);


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
