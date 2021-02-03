using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Store_API
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
            // https://stackoverflow.com/questions/64858434/net5-0-blazor-wasm-cors-client-exception
            // https://dzone.com/articles/cors-in-net-core-net-core-security-part-vi#:~:text=CORS%20stands%20for%20Cross%2DOrigin,origin%20requests%20while%20rejecting%20others.%22
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    //builder.WithOrigins("https://localhost:5004","http://localhost:5003", "http://client_container:80"));
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // https://stackoverflow.com/questions/51385671/failed-to-determine-the-https-port-for-redirect-in-docker
            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // https://stackoverflow.com/questions/64858434/net5-0-blazor-wasm-cors-client-exception
            // https://dzone.com/articles/cors-in-net-core-net-core-security-part-vi#:~:text=CORS%20stands%20for%20Cross%2DOrigin,origin%20requests%20while%20rejecting%20others.%22
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
