using System.Collections.Generic;
using Newtonsoft.Json;

namespace ReCaptchaVerifyClient.Models
{
    internal class ReCaptchaResponse
    {
        public ReCaptchaResponse()
        {
            ErrorCodes = new List<string>();
        }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public string ChallengeTs { get; set; } = string.Empty;

        [JsonProperty("hostname")]
        public string Hostname { get; set; } = string.Empty;

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}