using Employee.Ioc.Configaration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//add it redoc
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Employee",
            Version = "v1", 
            Description ="This is a Employee Project" + "For ASP.NET core web",
            Contact=new OpenApiContact
            {
                Name= "Shahnaz",
              
                Email="Shanu@gmail.com"
            }
        });
});
// end it redoc

builder.Services.MapCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    //add it
    app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Demo Documentation v1"));

    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Demo Documentation";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });
    //
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
