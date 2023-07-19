using Microsoft.Extensions.Options;
using StudentAdminPortal.API.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentAdminPortal.API.Repositories;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors((options) => 
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().WithMethods("GET", "POST", "PUT", "DELETE").WithExposedHeaders("*");
    });


});
builder.Services.AddMvcCore();
builder.Services.AddDbContext<StudentAdminContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//builder.Services.AddAutoMapper(typeof(IStartup).Assembly);

builder.Services.AddScoped<IStudentRepository, SqlStudentRepository>();
builder.Services.AddScoped<IImageRepository, LocalStorageImageRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Resources")),RequestPath= "/Resources"
});
app.UseCors("angularApplication");
app.UseAuthorization();

app.MapControllers();

app.Run();
