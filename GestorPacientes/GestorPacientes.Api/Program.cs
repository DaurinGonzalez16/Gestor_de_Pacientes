using GestorPacientes.Application.Contract;
using GestorPacientes.Application.Service;
using GestorPacientes.Infraestructure.Context;
using GestorPacientes.Infraestructure.Interfaces;
using GestorPacientes.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;


namespace GestorPacientes.Api
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


            //Registro de dependencia base de de datos //
            object value = builder.Services.AddDbContext<GestorPacientesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GestorPacientesContext")));

            // Repositories //
            builder.Services.AddTransient<IPacientesRepository, PacienteRepository>();
            builder.Services.AddTransient<IPacientesServices, PacientesService>();
            /*------------------------------------------------------------------------*/
            builder.Services.AddTransient<IAgendaCitasRepository, AgendaRepository>();
            builder.Services.AddTransient<IAgendaCitaService, AgendaService>();

          


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}