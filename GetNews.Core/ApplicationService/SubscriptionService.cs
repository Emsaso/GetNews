using GetNews.Core.DomainModel;

namespace GetNews.Core.ApplicationService
{
    public class SubscriptionService
    {

        public static Result<EmailAndSubscription> SignUp(string emailAddressStr, Subscription? subscription)
        {
          /*  var emailAddress = new EmailAddress(emailAddressStr);
            if (subscription != null && subscription.Status == SubscriptionStatus.SignedUp)
                return Result<EmailAndSubscription>.Fail(SignUpError.AlreadySignedUp);



            var isUnsubscribed = subscription.Status == SubscriptionStatus.Unsubscribed;
            
            else if(subscription.Status == SubscriptionStatus.Unsubscribed) 
                subscription.ChangeStatus(SubscriptionStatus.SignedUp);

            var mail = Email.CreateConfirmEmail(emailAddressStr, subscription.VerificationCode);
            return Result<EmailAndSubscription>.Ok(new EmailAndSubscription(mail, subscription));
          */

            var emailAddress = new EmailAddress(emailAddressStr);
            var mail = Email.CreateConfirmEmail(emailAddressStr, subscription.VerificationCode);

            if (!emailAddress.IsValid())
                return Result<EmailAndSubscription>.Fail(SignUpError.InvalidEmailAddress);
            if (subscription == null) subscription = new Subscription(emailAddressStr);

            switch (subscription.Status)
                {
                case SubscriptionStatus.SignedUp:
                    return Result<EmailAndSubscription>.Ok(new EmailAndSubscription(mail, subscription));

                case SubscriptionStatus.Verified:
                    return Result<EmailAndSubscription>.Fail(SignUpError.AlreadySubscribed);

                case SubscriptionStatus.Unsubscribed:
                    subscription.ChangeStatus(SubscriptionStatus.SignedUp);
                    subscription.RegenerateVerificationCode();

                    return Result<EmailAndSubscription>.Ok(new EmailAndSubscription(mail, subscription));
                    
                default:
                    return Result<EmailAndSubscription>.Fail(SignUpError.Unknown);
                }
        }

        public static Result<Subscription> Confirm(string userMail, Guid verificationCode, Subscription subscription)
        {
            if (subscription.VerificationCode != verificationCode) return Result<Subscription>.Fail(SignUpError.InvalidVertificationCode);

            if (!new EmailAddress(subscription.EmailAddress).IsEqual(userMail)) return Result<Subscription>.Fail(SignUpError.InvalidEmailAddress);

            if (subscription.IsVerified && subscription.Status == SubscriptionStatus.Verified) return Result<Subscription>.Fail(SignUpError.AlreadySubscribed);

            subscription.ChangeStatus(SubscriptionStatus.Verified);

            return Result<Subscription>.Ok(subscription);
        }

        public static Result<Subscription> Unsubscribe(string userMail, Subscription subscription)
        {
            if (!new EmailAddress(userMail).IsEqual(subscription.EmailAddress)) return Result<Subscription>.Fail(SignUpError.InvalidEmailAddress);

            if (subscription.Status == SubscriptionStatus.Unsubscribed) return Result<Subscription>.Fail(SignUpError.AlreadyUnsubcribed);

            if (!(subscription.Status == SubscriptionStatus.Verified || subscription.IsVerified)) return Result<Subscription>.Fail(SignUpError.Unknown);

            subscription.ChangeStatus(SubscriptionStatus.Unsubscribed);

            return Result<Subscription>.Ok(subscription);

        }
    }
}
