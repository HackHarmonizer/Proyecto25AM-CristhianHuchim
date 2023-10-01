using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Proyecto25AM_CristhianHuchim.Context;
using Proyecto25AM_CristhianHuchim.Services.IServices;
using Proyecto25AM_CristhianHuchim.Services.Services;

namespace Proyecto25AM_CristhianHuchim
{
    public class Startup
    {
        private readonly string _MyCors = "CristhianGeovannyHuchimToh";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //Cadena de conexion 
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Inyeccion de dependencia
            services.AddTransient<IClienteServices, ClienteServices>();
            services.AddTransient<IDepartamentoServices, DepartamentoServices>();
            services.AddTransient<IEmpleadoServices, EmpleadoServices>();
            services.AddTransient<IFacturaServices, FacturaServices>();
            services.AddTransient<IPuestoServices, PuestoServices>();
            services.AddTransient<IRolServices, RolServices>();
            services.AddTransient<IUsuarioServices, UsuarioServices>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: _MyCors, builder =>
                {
                    //builder.WithOrigins("http://localhost");
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .AllowAnyHeader().AllowAnyMethod();

                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(_MyCors);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
