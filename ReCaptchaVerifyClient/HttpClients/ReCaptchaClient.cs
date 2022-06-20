using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentResults;
using Newtonsoft.Json;
using ReCaptchaVerifyClient.Models;
using ReCaptchaVerifyClient.Contracts;

namespace ReCaptchaVerifyClient.HttpClients
{
    public class ReCaptchaClient : IReCaptchaClient
    {
        private const string RemoteAddress = "https://www.google.com/recaptcha/api/siteverify";

        private readonly HttpClient httpClient;
        private readonly ReCaptchaOptions options;

        public ReCaptchaClient(HttpClient httpClient, ReCaptchaOptions options)
        {
            this.httpClient = httpClient;
            this.options = options;
        }

        public async Task<Result> VerifyAsync(string recaptchaToken)
        {
            var response = await GetCaptchaResultDataAsync(recaptchaToken);

            if (response == null || !response.Success)
            {
                return Result.Fail("Verify Failed.");
            }

            return Result.Ok();
        }

        public void UpdateSecretKey(string key)
        {
            options.SecretKey = key;
        }

        private async Task<ReCaptchaResponse?> GetCaptchaResultDataAsync(string token)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("secret", options.SecretKey),
                new KeyValuePair<string, string>("response", token)
            });
            var res = await httpClient.PostAsync(RemoteAddress, content);
            if (res.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var jsonResult = await res.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(jsonResult))
            {
                return null;
            }
            var result = JsonConvert.DeserializeObject<ReCaptchaResponse>(jsonResult);
            return result;
        }
    }
}
