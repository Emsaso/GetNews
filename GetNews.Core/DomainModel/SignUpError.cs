// Error codes for the sign-up process in the GetNews application.

namespace GetNews.Core.DomainModel
{
    public enum SignUpError
    {
        // This enum defines various error states that can occur during the sign-up process.

        AlreadySignedUp,
        InvalidEmailAddress,
        AlreadySubscribed,
        InvalidVerificationCode,
        AlreadyUnsubscribed,
        Unknown,
        AlreadyVerified,
        SubscriptionNotFound,
        CannotVerifyWhenUnsubscribed
    }
}
