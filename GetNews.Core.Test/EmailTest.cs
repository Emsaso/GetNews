using GetNews.Core.DomainModel;
using GetNews.Core.ApplicationService;


namespace GetNews.Core.Test
{
    public class EmailTest
    {
        private EmailAddress _userEmail;
        private EmailAddress _fakeEmail;
        private EmailAddress _fakeEmail_1;

        [SetUp]
        public void Setup()
        {
            _userEmail = new EmailAddress("no-replay@getAcademy.no");
            _fakeEmail = new EmailAddress("no-replay@getAcademyno");
            _fakeEmail_1 = new EmailAddress("no-replaygetAcademy.no");
        }

        [Test]
        public void TestCreateConfirmationEmail()
        {
            var hexCode = Guid.NewGuid();
            var emailAddress = _userEmail.Value;
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
            var email = Email.UnsubscribeEmail(_userEmail.Value);

            Assert.That(email, Is.InstanceOf<Email>());

            Assert.That(email.ToEmailAddress, Is.EqualTo(_userEmail.Value));
            Assert.That(email.Subject, Is.EqualTo("Endringer i abonnementet"));
            Assert.That(email.FromEmailAddress, Is.EqualTo("getnews@dummymail.com"));
            Assert.That(email.Body, Is.EqualTo($"Vi bekrefter at du har meldt deg av Nyhetsbrevet hos GET News.\n"));
        }
    }
}