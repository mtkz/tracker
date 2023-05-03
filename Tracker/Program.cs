using Infrastructure;
using Infrastructure.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();


//builder.Services.AddApplicationServices(builder.Configuration);
//builder.Services.AddCoreServices();
builder.Services.ConfigureApplicationPersistence(builder.Configuration);
//builder.Host.UseSerilog((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration));
//builder.Services.AddHostedService<DataSeeder>();
// Register the Swagger generator, defining 1 or more Swagger documents
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wellbeing Appointmenter Service", Version = "v1" });
//    c.AddSwaggerAuthentication(builder.Configuration.GetSection(nameof(SwaggerConfiguration)).Get<SwaggerConfiguration>());
//});

//builder.Services.AddDbContext<DatabaseContext>(option =>
//               option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("CorsPolicy");

//app.UseGlobalExceptionHandler();

app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Appointmenter Service V1");
    c.RoutePrefix = string.Empty;
    //c.SetClientAuthentication(builder.Configuration.GetSection(nameof(SwaggerConfiguration)).Get<SwaggerConfiguration>());
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

