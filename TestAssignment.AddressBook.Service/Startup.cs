using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TestAssignment.AddressBook.Repositories;

namespace TestAssignment.AddressBook.Service
{
    public class Startup
    {

        private string _uiOriginPolicyName = "_originUiPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            // support for configurations
            services.AddOptions();
            services.Configure<PhoneDbContextCfg>(Configuration.GetSection("Database"));

            // controllers 
            services.AddControllers();

            // setup origin headers for clients ui
            var uiOrigins = GetUiOrigins();
            if(uiOrigins.Any())
            {
                services.AddCors(options =>
                    options.AddPolicy(_uiOriginPolicyName, builder =>
                        builder.WithOrigins(uiOrigins).AllowAnyMethod().AllowAnyHeader()));
            }
            
            // mvc with custom data validation filter
            services.AddMvc(opt => opt.Filters.Add<ModelsValidationFilter>());

            // data mapping
            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(), typeof(Startup));

            // swagger generator
            services.AddSwaggerDocument(c =>
            {
                c.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Phone service API";
                    document.Info.Description = "Phone service API";
                };
            });

            // repository stuff
            services.AddDbContext<PhoneDbContext>();
            services.AddTransient<IContactsRepository, ContactsRepository>();
            services.AddTransient<ISampleContactsRepository, SampleContactsRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // development exception page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // https redirect
            app.UseHttpsRedirection();

            // ui origins (allow browser clients to access data)
            var uiOrigins = GetUiOrigins();
            if(uiOrigins.Any())
            {
                app.UseCors(_uiOriginPolicyName);
            }

            // routing endpoints setup
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // swagger JSON
            app.UseOpenApi();
            app.UseSwaggerUi3();

        }

        private string[] GetUiOrigins()
        {
            var originRaw = Configuration.GetSection("AllowOriginHeader").Value;
            var origins = originRaw.Split(";").Select(p => p.Trim()).Where(p => !string.IsNullOrWhiteSpace(p)).ToArray();
            return origins;
        }
    }
}
