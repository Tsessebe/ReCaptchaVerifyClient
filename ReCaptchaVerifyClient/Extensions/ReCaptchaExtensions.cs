using System;
using ReCaptchaVerifyClient.Models;
using Microsoft.Extensions.DependencyInjection;
using ReCaptchaVerifyClient.Contracts;
using ReCaptchaVerifyClient.HttpClients;

namespace ReCaptchaVerifyClient.Extensions
{
    public static class ReCaptchaExtensions
    {
        public static void AddReCaptchaClient(this IServiceCollection services, Action<ReCaptchaOptions> options = null)
        {
            services.Configure(options);

            var apiOptions = new ReCaptchaOptions();
            options?.Invoke(apiOptions);

            services.AddSingleton(apiOptions);

            services.AddHttpClient<IReCaptchaClient, ReCaptchaClient>();
        }
    }
}
