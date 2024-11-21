using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Comunicaciones
            services.AddScoped<IDetalles_FacturasComunicacion, Detalles_FacturasComunicacion>();
            services.AddScoped<IServiciosComunicacion, ServiciosComunicacion>();
            services.AddScoped<IFacturasComunicacion, FacturasComunicacion>();
            services.AddScoped<IMetodos_De_PagosComunicacion, Metodos_De_PagosComunicacion>();
            // Presentaciones
            services.AddScoped<IDetalles_FacturasPresentacion, Detalles_FacturasPresentacion>();
            services.AddScoped<IServiciosPresentacion, ServiciosPresentacion>();
            services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
            services.AddScoped<IMetodos_De_PagosPresentacion, Metodos_De_PagosPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}