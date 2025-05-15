// GetNews API

// Importing necessary namespaces
using GetNews.API.ApiModel;
using GetNews.API.Infrastructure;
using GetNews.Core.ApplicationService;
using Microsoft.Extensions.Options;

namespace GetNews.API
{
    public class SubscriptionController
    {
        public static async Task<object> SignUp(SubscriptionSignUp subscriptionSignUp, IOptions<AppConfig> options)
        {
            var basePath = options.Value.BasePath;
            // IO
            var emailAddress = subscriptionSignUp.EmailAddress;
            var subscription = await SubscriptionFileRepository.LoadSubscription(emailAddress, basePath);

            // Logikk uten IO - i kjernen
            var signUpResult = SubscriptionService.SignUp(emailAddress, subscription);

            // IO

            // Return Error message if sign up failed
            if (!signUpResult.IsSuccess)
            {
                return new { IsSuccess = false, Error = signUpResult.Error.ToString() };
            }

            //  Save subscriber if not null
            if (signUpResult.Value.Subscription != null)
            {
                await SubscriptionFileRepository.SaveSubscription(signUpResult.Value.Subscription, basePath);
            }

            //  Send confirmation if email is provided
            if (signUpResult.Value.Email != null)
            {
                await DummyEmailService.Send(signUpResult.Value.Email, basePath);
            }

            return new { IsSuccess = true, SendtEmail = signUpResult.Value.Email != null };
        }

        public static async Task<object> Verify(SubscriptionVerification verification, IOptions<AppConfig> options)
        {
            // IO
            var basePath = options.Value.BasePath;
            var email = verification.EmailAddress;

            if (!Guid.TryParse(verification.VerificationCode, out var verificationCode))
            {
                return new { IsSuccess = false, Error = "Invalid Verification code format" };
            }

            var subscription = await SubscriptionFileRepository.LoadSubscription(email, basePath);

            // Logikk uten IO - i kjernen
            var result = SubscriptionService.Confirm(email, verificationCode, subscription);


            // IO
            if (!result.IsSuccess) return new { IsSuccess = false, result.Error };

            await SubscriptionFileRepository.SaveSubscription(result.Value, basePath);
            return new { IsSuccess = true };
        }

        public static async Task<object> Unsubscribe(SubscriptionSignUp subscriptionUnsubscribe, IOptions<AppConfig> options)
        {
            var basePath = options.Value.BasePath;
            var email = subscriptionUnsubscribe.EmailAddress;
            Console.WriteLine(email);
            var subscription = await SubscriptionFileRepository.LoadSubscription(email, basePath);
            var result = SubscriptionService.Unsubscribe(email, subscription);

            if (!result.IsSuccess)
            {
                return new
                {
                    IsSuccess = false,
                    Error = result.Error.ToString()
                };
            }

            await SubscriptionFileRepository.SaveSubscription(result.Value, basePath);
            return new { IsSuccess = true };

        }
    }
}
