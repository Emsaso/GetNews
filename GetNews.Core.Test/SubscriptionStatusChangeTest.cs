using GetNews.Core.ApplicationService;
using GetNews.Core.DomainModel;

namespace GetNews.Core.Test
{
    internal class SubscriptionStatusChangeTest
    {

        [Test]
        public void TestSignUpAlreadySubscribed()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Verified, null, true);

            var result = SubscriptionService.SignUp(emailAddress, subscription);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(nameof(SignUpError.AlreadySubscribed)));
        }

        [Test]
        public void TestSignUpUnsubscribed()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Unsubscribed);

            var result = SubscriptionService.SignUp(emailAddress, subscription);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Email, Is.InstanceOf<Email>());
            Assert.That(result.Value.Subscription, Is.EqualTo(subscription));
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.SignedUp));
        }

        [Test]
        public void TestSignUpWhenSignedUp()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.SignedUp);

            var result = SubscriptionService.SignUp(emailAddress, subscription);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Email, Is.InstanceOf<Email>());
            Assert.That(result.Value.Subscription, Is.EqualTo(subscription));
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.SignedUp));
        }

    }
}
