using Quizzando;
using Quizzando.AutoMapper;
using Quizzando.DataAccess;
using Quizzando.Exception.Filters;
using Quizzando.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration["ConnectionStrings:DefaultConnetion"] = Environment.GetEnvironmentVariable("DEFAULT_CONNETION");

builder.Services.AddControllers();

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAutoMapper(typeof(AutoMapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
