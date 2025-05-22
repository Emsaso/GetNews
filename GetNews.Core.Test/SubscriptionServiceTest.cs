using GetNews.Core.DomainModel;
using GetNews.Core.ApplicationService;

namespace GetNews.Core.Test
{
    public class SubscriptionServiceTest
    {

        [TestCase(SubscriptionStatus.SignedUp, true)]
        [TestCase(SubscriptionStatus.SignedUp, false)]
        [TestCase(SubscriptionStatus.Verified, false)]
        public void TestUnsubscribedWithError(SubscriptionStatus status, bool isVerified)
        {
         
            var userEmail = "no-replay@getAcademy.no";
            var fakeEmail = "no-replay@getAcademyno";

            var subscription = new Subscription(userEmail, status, null, isVerified, lastStatusChange: new DateOnly(2025, 4, 1));
            var subscription_1 = new Subscription(fakeEmail, status, null, isVerified, lastStatusChange: new DateOnly(2025, 4, 1));

            var result = SubscriptionService.Unsubscribe(subscription_1.EmailAddress, subscription);
            var result_1 = SubscriptionService.Unsubscribe(subscription_1.EmailAddress, subscription_1);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(SignUpError.Unknown.ToString()).Or.EqualTo(SignUpError.InvalidEmailAddress.ToString()));
        }


            [Test]
            public void TestCreateConfirmationEmail()
            {
                var hexCode = Guid.NewGuid();
                var emailAddress = "no-reply@getacademy.no";
                var email = Email.CreateConfirmEmail(emailAddress, hexCode);

                Assert.That(email, Is.InstanceOf<Email>());
                Assert.That(email.Body, Is.EqualTo($"Kode: {hexCode}"));
                Assert.That(email.ToEmailAddress, Is.EqualTo(emailAddress));
                Assert.That(email.FromEmailAddress, Is.EqualTo("getnews@dummymail.com"));
                Assert.That(email.Subject, Is.EqualTo("Bekreft abonnement på GET News"));
            }

            [Test]
            public void TestCreateUnsubscribedEmail()
            {
                var emailAddress = "no-replaygetAcademy.no";
                var email = Email.UnsubscribeEmail(emailAddress);

                Assert.That(email, Is.InstanceOf<Email>());

                Assert.That(email.ToEmailAddress, Is.EqualTo(emailAddress));
                Assert.That(email.Subject, Is.EqualTo("Endringer i abonnementet"));
                Assert.That(email.FromEmailAddress, Is.EqualTo("getnews@dummymail.com"));
                Assert.That(email.Body, Is.EqualTo($"Vi bekrefter at du har meldt deg av Nyhetsbrevet hos GET News.\n"));
            }
    }
}