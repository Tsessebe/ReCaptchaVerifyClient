using System.Threading.Tasks;
using FluentResults;

namespace ReCaptchaVerifyClient.Contracts
{
    
    /// <summary>
    /// Re Captcha Client interface.
    /// </summary>
    public interface IReCaptchaClient
    {
        /// <summary>
        /// Verifies the ReCaptcha token received from the client.
        /// </summary>
        /// <param name="recaptchaToken">the ReCaptcha token.</param>
        /// <returns>a Result.</returns>
        Task<Result> VerifyAsync(string recaptchaToken);
        
        /// <summary>
        /// Updates the Recaptcha SecretKey.
        /// </summary>
        /// <param name="key">the new SecretKey</param>
        void UpdateSecretKey(string key);
    }
}