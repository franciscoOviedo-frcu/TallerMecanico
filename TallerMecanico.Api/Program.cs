using Microsoft.EntityFrameworkCore; // Para que reconozca .UseSqlServer()
using TallerMecanico.Api.Data;      // Para que reconozca TallerDbContext


namespace TallerMecanico.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TallerDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      // Aquí pones la URL de tu cliente Blazor. 
                                      // Búscala en las propiedades del proyecto Web (launchSettings.json)
                                      // Probablemente sea algo como "https://localhost:7123"
                                      policy.WithOrigins("https://localhost:7099")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                  });
            });

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

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
