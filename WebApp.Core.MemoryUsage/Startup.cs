// #define MVC
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;

namespace WebApp.Core.MemoryUsage
{
    public class Startup
    {
        public const string DETAILS_TOKEN_PATTERN = "(?i)(Light|Medium|Complete)";
        public const string ACTION_TOKEN_PATTERN = "\\D+";
        public const string ID_TOKEN_PATTERN = "^-?\\d+";

        private static class Actions
        {
            public static string Get => nameof(BaseTestController.Get);
            public static string Delete => nameof(BaseTestController.Delete);
            public static string Post => nameof(BaseTestController.Post);
            public static string Put => nameof(BaseTestController.Put);
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
#if MVC
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
#endif
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
            var path = Path.Combine(env.ContentRootPath, "Controllers");
            for (var i = 2; i < 1000; i++)
            {
                var content= File.ReadAllText(Path.Combine(path, "WebApi1Controller.cs"));
                var nc = content.Replace("1", i.ToString());
                File.WriteAllText(Path.Combine(path, $"WebApi{i}Controller.cs"), nc);
            }
            */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

#if MVC
            app.UseMvc(RegisterWebApiRoutes);
#else
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("App Routing Memory Test");
                });
                RegisterWebApiRoutes(endpoints);
#if ROUTE
                endpoints.MapControllers();
#endif

                endpoints.MapGet("/done", async context =>
                {
                    await context.Response.WriteAsync("App Routing Memory Test");
                });
            });
#endif
            }

        private HttpMethodRouteConstraint GetNew_HttpRouting_Get_HttpMethodConstraint()
        {
            return new HttpMethodRouteConstraint("GET", "OPTION");
        }

        private HttpMethodRouteConstraint GetNew_HttpRouting_Put_HttpMethodConstraint()
        {
            return new HttpMethodRouteConstraint("PUT", "OPTION");
        }
        private HttpMethodRouteConstraint GetNew_HttpRouting_Post_HttpMethodConstraint()
        {
            return new HttpMethodRouteConstraint("POST", "OPTION");
        }

        private HttpMethodRouteConstraint GetNew_HttpRouting_Delete_HttpMethodConstraint()
        {
            return new HttpMethodRouteConstraint("POST", "DELETE");
        }


        private void RegisterWebApiRoutes(
#if MVC
            IRouteBuilder
#else
            IEndpointRouteBuilder 
#endif
            endpoint)
        {
            var baseUrl = "api/{version}/";

            RegisterWebApiRoute(
                endpoint,
                name: "GetSearchByQueryApi",
                routeTemplate: baseUrl + "{controller}/Search",
                defaults: new
                {
                    action = "Search"
                },
                constraints: new
                {
                    httpMethod = GetNew_HttpRouting_Get_HttpMethodConstraint()
                }
            );

            RegisterWebApiRoute(endpoint,
               name: "GetCountByQueryApi",
                routeTemplate: baseUrl + "{controller}/Count",
                defaults: new
                {
                    action = "Count"
                },
                constraints: new
                {
                    httpMethod = GetNew_HttpRouting_Get_HttpMethodConstraint()
                }
            );

            RegisterWebApiRoute(endpoint,
               name: "GetByIdApi",
                routeTemplate: baseUrl + "{controller}/{id}",
                defaults: new
                {
                    action = Actions.Get
                },
                constraints: new
                {
                    id = ID_TOKEN_PATTERN,
                    httpMethod = GetNew_HttpRouting_Get_HttpMethodConstraint()
                }
            );

            RegisterWebApiRoute(endpoint,
                name: "GetByIdApiWithDetails",
                routeTemplate: baseUrl + "{controller}/{details}/{id}",
                defaults: new
                {
                    action = Actions.Get
                },
                constraints: new
                {
                    details = DETAILS_TOKEN_PATTERN,
                    id = ID_TOKEN_PATTERN,
                    httpMethod = GetNew_HttpRouting_Get_HttpMethodConstraint()
                }
            );

            RegisterWebApiRoute(endpoint,
                name: "DeleteByIdApi",
                routeTemplate: baseUrl + "{controller}/{id}",
                defaults: new
                {
                    action = Actions.Delete
                },
                constraints: new
                {
                    id = ID_TOKEN_PATTERN,
                    httpMethod = GetNew_HttpRouting_Delete_HttpMethodConstraint()
                }
            );

            RegisterWebApiRoute(endpoint,
                name: "GetByIdWithActionApi",
                routeTemplate: baseUrl + "{controller}/{action}/{id}",
                defaults: new
                {
                },
                constraints: new
                {
                    id = ID_TOKEN_PATTERN,
                    action = ACTION_TOKEN_PATTERN
                }
            );
            RegisterWebApiRoute(endpoint,
                name: "GetByIdWithActionApiAndDetails",
                routeTemplate: baseUrl + "{controller}/{details}/{action}/{id}",
                defaults: new
                {
                },
                constraints: new
                {
                    details = DETAILS_TOKEN_PATTERN,
                    id = ID_TOKEN_PATTERN,
                    action = ACTION_TOKEN_PATTERN
                }
            );

            RegisterWebApiRoute(endpoint,
                name: "GetPropertyByIdWithActionApi",
                routeTemplate: baseUrl + "{controller}/{id}/{action}",
                defaults: new
                {
                },
                constraints: new
                {
                    id = ID_TOKEN_PATTERN,
                    action = ACTION_TOKEN_PATTERN
                }
            );

            RegisterWebApiRoute(endpoint,
                name: "GetPropertyByIdWithActionAndDetailsApi",
                routeTemplate: baseUrl + "{controller}/{details}/{id}/{action}",
                defaults: new
                {
                },
                constraints: new
                {
                    details = DETAILS_TOKEN_PATTERN,
                    id = ID_TOKEN_PATTERN,
                    action = ACTION_TOKEN_PATTERN
                }
            );

            RegisterWebApiRoute(endpoint,
                name: "GetDownloadPrintActionApi",
                routeTemplate: baseUrl + "{controller}/{id}/download/{filename}",
                defaults: new
                {
                    action = "Download"
                },
                constraints: new
                {
                    httpMethod = GetNew_HttpRouting_Get_HttpMethodConstraint(),
                    id = ID_TOKEN_PATTERN,
                    // filename = @"^[\w,\s-]+\.[A-Za-z]{3,4}$",
                }
            );
            
            RegisterWebApiRoute(endpoint,
                name: "GetApi",
                routeTemplate: baseUrl + "{controller}/{action}",
                defaults: new
                {
                    action = Actions.Get
                },
                constraints: new
                {
                    httpMethod = GetNew_HttpRouting_Get_HttpMethodConstraint(),
                    action = ACTION_TOKEN_PATTERN
                }
            );
            RegisterWebApiRoute(endpoint,
                name: "GetApiWithDetails",
                routeTemplate: baseUrl + "{controller}/{details}/{action}",
                defaults: new
                {
                    action = Actions.Get
                },
                constraints: new
                {
                    httpMethod = GetNew_HttpRouting_Get_HttpMethodConstraint(),
                    details = DETAILS_TOKEN_PATTERN,
                    action = ACTION_TOKEN_PATTERN
                }
            );
            RegisterWebApiRoute(endpoint,
                name: "PutApiWithoutAction",
                routeTemplate: baseUrl + "{controller}",
                defaults: new
                {
                    action = Actions.Put
                },
                constraints: new
                {
                    httpMethod = GetNew_HttpRouting_Put_HttpMethodConstraint()
                }
            );
            RegisterWebApiRoute(endpoint,
                name: "PostApiWithoutAction",
                routeTemplate: baseUrl + "{controller}",
                defaults: new
                {
                    action = Actions.Post
                },
                constraints: new
                {
                    httpMethod = GetNew_HttpRouting_Post_HttpMethodConstraint()
                }
            );
            RegisterWebApiRoute(endpoint,
                name: "DeleteApiWithoutAction",
                routeTemplate: baseUrl + "{controller}",
                defaults: new
                {
                    action = Actions.Delete
                },
                constraints: new
                {
                    httpMethod = GetNew_HttpRouting_Delete_HttpMethodConstraint()
                }
            );
            RegisterWebApiRoute(endpoint,
                name: "ApiWithAction",
                routeTemplate: baseUrl + "{controller}/{action}",
                defaults: new
                {
                    action = nameof(BaseTestController.Get)
                },
                constraints: new
                {
                    action = ACTION_TOKEN_PATTERN
                }
            );
            RegisterWebApiRoute(endpoint,
                name: "ApiWithActionAndDetails",
                routeTemplate: baseUrl + "{controller}/{details}/{action}",
                defaults: new
                {
                    action = Actions.Get
                },
                constraints: new
                {
                    details = DETAILS_TOKEN_PATTERN,
                    action = ACTION_TOKEN_PATTERN
                }
            );
#if LOG
            _log.Debug("Routes mapped");
#endif
        }

#if MVC
        private static void RegisterWebApiRoute(IRouteBuilder route, string name, string routeTemplate,
            object defaults, object constraints)
        {
            route.MapRoute(
                name: name,
                template: routeTemplate,
                defaults: defaults,
                constraints: constraints);
        }
#else
        private static void RegisterWebApiRoute(IEndpointRouteBuilder endpoint, string name, string routeTemplate,
            object defaults, object constraints)
        {
            endpoint.MapControllerRoute(
                name: name,
                pattern: routeTemplate,
                defaults: defaults,
                constraints: constraints
                );
        }
#endif
    }
}
