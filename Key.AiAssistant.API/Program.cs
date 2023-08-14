using Key.AiAssistant.Application.Configuration;
using Key.AiAssistant.ChatGPT.Configuration;
using Key.AiAssistant.Store.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureStoreServices(builder.Configuration);
builder.Services.ConfigureChatGptServices(builder.Configuration);

builder.Services.AddCors(t => t.AddPolicy("CorsPolicy", p =>
    p.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
));

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InitializeDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();