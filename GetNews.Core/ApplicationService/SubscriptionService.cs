using GetNews.Core.DomainModel;

namespace GetNews.Core.ApplicationService
{
    public class SubscriptionService
    {

        public static Result<EmailAndSubscription> SignUp(string emailAddressStr, Subscription? subscription)
        {

            /*TODO:
                A. Når man signer up, så er det tre mulige statuser man kan ha fra før: SignedUp, Verified og Unsubscribed. Sørg først
                    for at dere har unit tester som sjekker om dette oppfører seg som det skal. Om det finnes en Subscription fra før, 
                    og at status endres, så test at det ikke lages ny Subscription, men at den som returneres er den gamle - og at status
                    er endret, om det er det riktige. 

                B. Skriv koden i SubscriptionService.SignUp med så lite gjentakelse av kode som mulig. Og gjør den så lesbar som mulig. 
                    Målet er at det er lett å lese hva som skjer ved hvert av de fire forskjellige utgangspunktene (ingen Subscription
                    fra før - eller SignedUp, Verified eller Unsubscribed).
            */
            var emailAddress = new EmailAddress(emailAddressStr);
            if (!emailAddress.IsValid())
                return Result<EmailAndSubscription>.Fail(SignUpError.InvalidEmailAddress);

            //? Fjerne Disse 7 linjene og heller sette Switch på subscription.Status?
            //            var isUnsubscribed = subscription.Status == SubscriptionStatus.Unsubscribed;
            if (subscription == null) subscription = new Subscription(emailAddressStr);
            else if (subscription.Status == SubscriptionStatus.Unsubscribed)
                subscription.ChangeStatus(SubscriptionStatus.SignedUp);

            var mail = Email.CreateConfirmEmail(emailAddressStr, subscription.VerificationCode);
            return Result<EmailAndSubscription>.Ok(new EmailAndSubscription(mail, subscription));

            //! Switch statement fungerer som det skal i følge testene. 
            //            switch (subscription.Status)
            //            {
            //                case SubscriptionStatus.Verified:
            //                    return Result<EmailAndSubscription>.Fail(SignUpError.AlreadySubscribed);

            //                case SubscriptionStatus.SignedUp or SubscriptionStatus.Unsubscribed:
            //                    if (subscription.Status == SubscriptionStatus.Unsubscribed) subscription.ChangeStatus(SubscriptionStatus.SignedUp);
            //                    if (subscription == null) subscription = new Subscription(emailAddressStr);
            //                    var mail = Email.CreateConfirmEmail(emailAddressStr, subscription.VerificationCode);
            //                    return Result<EmailAndSubscription>.Ok(new EmailAndSubscription(mail, subscription));

            //                default:
            //                    return Result<EmailAndSubscription>.Fail(SignUpError.Unknown);
            //            }
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
