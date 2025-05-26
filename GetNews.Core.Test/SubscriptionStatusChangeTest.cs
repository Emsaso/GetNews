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

            var confirm = SubscriptionService.Verify(emailAddress, subscription.VerificationCode, subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(confirm.Error, Is.EqualTo(nameof(SignUpError.AlreadyVerified)));

            Assert.That(subscription.IsVerified, Is.True);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Verified));
            

        }

        [Test]
        public void TestVerifyWhenSignedUpIncorrectCode()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress);

            var confirm = SubscriptionService.Verify(emailAddress, Guid.NewGuid(), subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(subscription.IsVerified, Is.False);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.SignedUp));
            Assert.That(confirm.Error, Is.EqualTo(nameof(SignUpError.InvalidVerificationCode)));
        }

        [Test]
        public void TestVerifyWhenSignedUpCorrectCode()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress);

            var confirm = SubscriptionService.Verify(emailAddress, subscription.VerificationCode, subscription);

            Assert.That(confirm.IsSuccess, Is.True);
            Assert.That(subscription.IsVerified, Is.True);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Verified));
        }

        [Test]
        public void TestVerifyWhenUnsubscribedWithCorrectCode()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Unsubscribed);

            var confirm = SubscriptionService.Verify(emailAddress, subscription.VerificationCode, subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(subscription.IsVerified, Is.False);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Unsubscribed));
            Assert.That(confirm.Error, Is.EqualTo(nameof(SignUpError.CannotVerifyWhenUnsubscribed)));
        }

        [Test]
        public void TestVerifyWhenUnsubscribedWithIncorrectCode()
        {
            var emailAddress = "no-replay@getAcademy.no";
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Unsubscribed);

            var confirm = SubscriptionService.Verify(emailAddress, subscription.VerificationCode, subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(subscription.IsVerified, Is.False);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Unsubscribed));
            Assert.That(confirm.Error, Is.EqualTo(nameof(SignUpError.CannotVerifyWhenUnsubscribed)));
        }

        /*
         * Del 3 - Test Unsubscribe
         */

        //  TODO : Create new test for each test cases in Unsubscribiton
        public void TestUnsubscribed()
        {
            var userEmail = "no-replay@getAcademy.no";
            var subscription = new Subscription(userEmail, SubscriptionStatus.Verified, null);

            SubscriptionService.Unsubscribe(subscription.EmailAddress, subscription);

            Assert.That(subscription.IsVerified, Is.False);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Unsubscribed));
        }

        [Test]
        public void TestSignUpUnsubscribed()
        {
            var userEmail = "no-replay@getAcademy.no";
            var subscription = new Subscription(userEmail, SubscriptionStatus.Unsubscribed);

            var result = SubscriptionService.SignUp(userEmail, subscription);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Email, Is.InstanceOf<Email>());
            Assert.That(result.Value.Subscription, Is.EqualTo(subscription));
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.SignedUp));
        }
        
        [Test]
        public void TestUnsubscribedWithfakeEmailAddress()
        {
            var userEmail = "no-replay@getAcademy.no";
            var subscription = new Subscription(userEmail, SubscriptionStatus.SignedUp, null, true, lastStatusChange: new DateOnly(2025, 4, 1));


            var fakeEmail = "no-replay@getAcademyno";
            var result = SubscriptionService.Unsubscribe(fakeEmail, subscription);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(SignUpError.Unknown.ToString()).Or.EqualTo(SignUpError.InvalidEmailAddress.ToString()));
        }
        public void TestUnsubscribedWithSignedUpAndIsVerified()
        {;

            var userEmail = "no-replay@getAcademy.no";


            var subscription = new Subscription(userEmail, SubscriptionStatus.SignedUp, null, true, lastStatusChange: new DateOnly(2025, 4, 1));

            var result = SubscriptionService.Unsubscribe(subscription.EmailAddress, subscription);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(SignUpError.Unknown.ToString()).Or.EqualTo(SignUpError.InvalidEmailAddress.ToString()));
        }
        [Test]
        public void TestUnsubscribedWithSignedUpAndIsNotVerified()
        {

            var userEmail = "no-replay@getAcademy.no";

            var subscription = new Subscription(userEmail, SubscriptionStatus.SignedUp, null, false, lastStatusChange: new DateOnly(2025, 4, 1));

            var result = SubscriptionService.Unsubscribe(subscription.EmailAddress, subscription);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(SignUpError.SubscriptionNotFound.ToString()));
        }
    }
}
