var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_mySpecificOrigins", policy =>
    {
        // policy.WithOrigins("http://localhost:5000", "https://localhost:5000");
        policy.AllowAnyOrigin();
        // policy.WithMethods("GET", "POST", "PUT", "DELETE");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("_mySpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
