using GetNews.Core.ApplicationService;
using GetNews.Core.DomainModel;

namespace GetNews.Core.Test
{
    internal class SubscriptionStatusChangeTest
    {
        /*
         * Del 1 - SignUp
         */

        [Test]
        public void TestSignUpWhenVerified()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Verified, null, true);

            var result = SubscriptionService.SignUp(emailAddress, subscription);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(nameof(SignUpError.AlreadySubscribed)));
        }

        [Test]
        public void TestSignUpWhenUnsubscribed()
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

        /*
         * Del 2 - Test verification
         */

        [Test]
        public void TestVerifyWhenVerified()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Verified, null, true);

            var confirm = SubscriptionService.Confirm(emailAddress, Guid.NewGuid(), subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(subscription.IsVerified, Is.True);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Verified));
            Assert.That(confirm.Error, Is.EqualTo(nameof(SignUpError.AlreadyVerified)));

        }

        [Test]
        public void TestVerifyWhenSignedUpIncorrectCode()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress);

            var confirm = SubscriptionService.Confirm(emailAddress, Guid.NewGuid(), subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(subscription.IsVerified, Is.False);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.SignedUp));
            Assert.That(confirm.Error, Is.EqualTo(nameof(SignUpError.InvalidVertificationCode)));
        }

        [Test]
        public void TestVerifyWhenSignedUpCorrectCode()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress);

            var confirm = SubscriptionService.Confirm(emailAddress, subscription.VerificationCode, subscription);

            Assert.That(confirm.IsSuccess, Is.True);
            Assert.That(subscription.IsVerified, Is.True);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Verified));
        }

        [Test]
        public void TestVerifyWhenUnsubscribedWithCorrectCode()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Unsubscribed);

            var confirm = SubscriptionService.Confirm(emailAddress, subscription.VerificationCode, subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(subscription.IsVerified, Is.True);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Unsubscribed));
            Assert.That(confirm.Error, Is.EqualTo(nameof(SignUpError.CannotVerifyWhenUnsubscribed)));
        }

        [Test]
        public void TestVerifyWhenUnsubscribedWithIncorrectCode()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Unsubscribed);

            var confirm = SubscriptionService.Confirm(emailAddress, Guid.NewGuid(), subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(subscription.IsVerified, Is.True);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Unsubscribed));
            Assert.That(confirm.Error, Is.EqualTo(nameof(SignUpError.CannotVerifyWhenUnsubscribed)));
        }
    }

        /*
         * Del 3 - Test Unsubscribe
         */
        [TestCase(SubscriptionStatus.Verified, true)]
        public void TestUnsubscribed(SubscriptionStatus status, bool isVerified)
        {
            var subscription = new Subscription(_userEmail.Value, status, null, isVerified, lastStatusChange: new DateOnly(2025, 4, 1));

            SubscriptionService.Unsubscribe(subscription.EmailAddress, subscription);

            Assert.That(subscription.IsVerified, Is.False);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Unsubscribed));
        }

        [Test]
        public void TestSignUpUnsubscribed()
        {
            var emailAddress = _userEmail.Value;
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Unsubscribed);

            var result = SubscriptionService.SignUp(emailAddress, subscription);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Email, Is.InstanceOf<Email>());
            Assert.That(result.Value.Subscription, Is.EqualTo(subscription));
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.SignedUp));
        }
}
