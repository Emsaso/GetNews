using GetNews.Core.DomainModel;

namespace GetNews.Core.ApplicationService
{
    public class SubscriptionService
    {

        public static Result<EmailAndSubscription> SignUp(string emailAddressStr, Subscription? subscription)
        {
            var emailAddress = new EmailAddress(emailAddressStr);
            if (!emailAddress.IsValid())
                return Result<EmailAndSubscription>.Fail(SignUpError.InvalidEmailAddress);
            if (subscription?.Status == SubscriptionStatus.Verified)
                return Result<EmailAndSubscription>.Fail(SignUpError.AlreadySubscribed);
            subscription ??= new Subscription(emailAddressStr);

            var mail = Email.CreateConfirmEmail(emailAddressStr, subscription.VerificationCode);

            if (subscription.Status == SubscriptionStatus.Unsubscribed)
            {
                subscription.ChangeStatus(SubscriptionStatus.SignedUp);
                subscription.RegenerateVerificationCode();
            }

            var emailAndSubscription = new EmailAndSubscription(mail, subscription);
            return Result<EmailAndSubscription>.Ok(emailAndSubscription);
        }

        public static Result<Subscription> Verify(string userMail, Guid verificationCode, Subscription subscription)
        {
            if (subscription.VerificationCode != verificationCode) 
                return Result<Subscription>.Fail(SignUpError.InvalidVerificationCode);

            if (!new EmailAddress(subscription.EmailAddress).IsEqual(userMail))
                return Result<Subscription>.Fail(SignUpError.InvalidEmailAddress);

            if (subscription.IsVerified && subscription.Status == SubscriptionStatus.Verified) 
                return Result<Subscription>.Fail(SignUpError.AlreadySubscribed);
            
            if (subscription.Status == SubscriptionStatus.Unsubscribed)
                return Result<Subscription>.Fail(SignUpError.CannotVerifyWhenUnsubscribed);

            subscription.ChangeStatus(SubscriptionStatus.Verified);

            return Result<Subscription>.Ok(subscription);
        }

        public static Result<Subscription> Unsubscribe(string userMail, Subscription subscription)
        {
            if (!new EmailAddress(userMail).IsEqual(subscription.EmailAddress)) return Result<Subscription>.Fail(SignUpError.InvalidEmailAddress);

            if (subscription.Status == SubscriptionStatus.Unsubscribed) return Result<Subscription>.Fail(SignUpError.AlreadyUnsubscribed);

            if (!(subscription.Status == SubscriptionStatus.Verified)) return Result<Subscription>.Fail(SignUpError.SubscriptionNotFound);

            subscription.ChangeStatus(SubscriptionStatus.Unsubscribed);

            return Result<Subscription>.Ok(subscription);

        }
    }
}
