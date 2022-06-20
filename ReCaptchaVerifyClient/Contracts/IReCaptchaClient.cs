using System.Threading.Tasks;
using FluentResults;

namespace ReCaptchaVerifyClient.Contracts
{
    public interface IReCaptchaClient
    {
        Task<Result> VerifyAsync(string recaptchaToken);
        void UpdateSecretKey(string key);
    }
}