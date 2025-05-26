using GetNews.Core.DomainModel;
using GetNews.Core.ApplicationService;

namespace GetNews.Core.Test
{
    public class TestEmail
    {
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