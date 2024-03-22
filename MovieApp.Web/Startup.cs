using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieApp.Web.Data;

namespace MovieApp.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        //services mvc göre ayarlarýz burada


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MsSQLConnection")));
            //options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();//services mvc göre ayarlarýz burada
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DataSeeding.Seed(app);
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                //yan yana yazarken hiç boþluk olmasýn
                );




                //ctrl+k+c yaptým cunku uzun uzun hep yazamayýz kýsa yolu var yukarýda yazdým  
                ////http://localhost:235929/
                //endpoints.MapControllerRoute(
                //    name: "home",
                //    pattern:"",
                //    defaults: new {controller = "Home" , action = "Index"}
                //    );
                ////http://localhost:235929/about
                //endpoints.MapControllerRoute(
                //   name: "about",
                //   pattern: "about",
                //   defaults: new { controller = "Home", action = "About" }
                //   );

                ////http://localhost:235929/movies/
                //endpoints.MapControllerRoute(
                //   name: "movies",
                //   pattern: "movies",
                //   defaults: new { controller = "Movies", action = "Movies" }
                //   );

                ////http://localhost:235929/movies/list
                //endpoints.MapControllerRoute(
                //    name: "movieList",
                //    pattern: "movies/list",
                //    defaults: new { controller = "Movies", action = "List" }
                //    );

                ////http://localhost:235929/movies/details
                //endpoints.MapControllerRoute(
                //    name: "movieDetails",
                //    pattern: "movies/details",
                //    defaults: new { controller = "Movies", action = "Details" }
                //    );








                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                //endpoints.MapGet("/movies", async context =>
                //{
                //    await context.Response.WriteAsync("Movie List");
                //});bunlarý silip route þemasý oluþturacaðýz



            });
        }
    }
}
