using Crud_Api.Exceptions;
using Crud_Api.Services.Abstracts;
using Crud_Api.Services.Implements;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

namespace Crud_Api
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageServices, LanguageService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IGameService, GameService>();
            return services;
        }
        public static IApplicationBuilder UseTabuExceptionHandler(this
            IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                opt =>
                {
                    opt.Run(async context =>
                    {
                        var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                        var exception = feature.Error;
                        if (exception is IBaseException bEx)
                        {
                            context.Response.StatusCode = bEx.StatusCode;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                StatusCode = bEx.StatusCode,
                                Errormessage = bEx.ErrorMessage

                            });


                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsJsonAsync(new
                            {

                                Errormessage = "Gozlenilmez xeta bas verdi"

                            });
                        }
                    });
                });
            return app;
        }

    }
}
