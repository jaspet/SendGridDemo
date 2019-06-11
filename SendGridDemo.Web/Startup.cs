using IntelliTect.Coalesce;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SendGridDemo.Data;
using SendGridDemo.Data.Services;
using System.Security.Claims;

namespace SendGridDemo.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Env = env;
        }

        private IConfigurationRoot Configuration { get; }
        private IHostingEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionName = "DefaultConnection";
            string connString = Configuration.GetConnectionString(connectionName);

            // Add Entity Framework services to the services
            services.AddSingleton(Configuration);
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connString));

            services.AddCoalesce<AppDbContext>();
            MessageService messageService = new MessageService(Configuration["App:TwilioAccountSid"], Configuration["App:TwilioAuthToken"], Configuration["App:TwilioPhoneNumber"], Configuration["App:SendGridApiKey"], Configuration["App:ReplyEmail"], Configuration["App:AdminEmails"]);
            services.AddSingleton<IEmailSender, MessageService>((a) =>
            {
                return messageService;
            });

            services.AddSingleton<ISmsSender, MessageService>((a) =>
            {
                return messageService;
            });

            services.AddTransient<IConfigurationRoot>((a) =>
            {
                return Configuration;
            });

            services.AddCors();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null) (resolver as DefaultContractResolver).NamingStrategy = null;

                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


                // Dummy authentication for initial development.
                // Replace this with ASP.NET Core Identity, Windows Authentication, or some other auth scheme.
                // This exists only because Coalesce restricts all generated pages and API to only logged in users by default.
                app.Use(async (context, next) =>
                {
                    Claim[] claims = new[] { new Claim(ClaimTypes.Name, "developmentuser") };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await context.SignInAsync(context.User = new ClaimsPrincipal(identity));

                    await next.Invoke();
                });
                // End Dummy Authentication.
            }
            app.UseLogRequestMiddleware();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

           
        }
    }
}
