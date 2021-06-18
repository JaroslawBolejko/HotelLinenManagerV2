using FluentValidation.AspNetCore;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Responses;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.WarehauseValidation;
using HotelLinenManagerV2.ApplicationServices.Components.GUSDataConnector;
using HotelLinenManagerV2.DataAccess;
using HotelLinenManagerV2.DataAccess.CQRS;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HotelLinenManagerV2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGUSDataConnector, GUSDataConnector>();
            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateWarehauseValidator>());
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddAutoMapper(typeof(HotelLinensProfile).Assembly);
            services.AddMediatR(typeof(ResponseBase<>));
            services.AddDbContext<WarehauseStorageHotelLinenContext>(
                opt =>
                opt.UseSqlServer(this.Configuration.GetConnectionString("HotelLinenWarhauseConnection")));
             // services.AddControllers();
             services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "HotelLinenManagerV2", Version = "v2" });
            }).AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "HotelLinenManagerV2 v2"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
