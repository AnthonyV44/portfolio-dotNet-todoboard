using Asp.Versioning;

namespace VforV.Portfolio.DotNet.ToDoBoard.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // builder.Services.AddAutoMapper()
        
        builder.Services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddProblemDetails();
        builder.Services.AddApiVersioning(i =>
        {
            i.DefaultApiVersion = new ApiVersion(1, 0);
            i.AssumeDefaultVersionWhenUnspecified = true;
            i.ReportApiVersions = true;
        });
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}