
using Aplicacion.Interface;
using Aplicacion.Service;
using Infraestructura.Persistencia.Contexto;
using Infraestructura.Repositorio;

namespace Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repositorio<>));
            builder.Services.AddScoped<ReservasService>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddSqlServer<Contexto>(builder.Configuration.GetConnectionString("StringConection"));

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
}
