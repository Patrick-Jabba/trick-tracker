using Microsoft.EntityFrameworkCore;
using ms_tracker.Context;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add DbContext -> postgres
builder.Services.AddDbContext<TrackerContext>(opts => 
opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
assembly => assembly.MigrationsAssembly(typeof(TrackerContext).Assembly.FullName)));

// Add Cors
builder.Services.AddCors(opts => 
{
    opts.AddPolicy(MyAllowSpecificOrigins,
        policy => 
        {
            policy.WithOrigins("http://localhost:8080/")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin();
        });
});

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
