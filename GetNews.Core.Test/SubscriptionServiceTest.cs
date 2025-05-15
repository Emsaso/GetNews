using GetNews.Core.DomainModel;
using GetNews.Core.ApplicationService;


namespace GetNews.Core.Test
{
    public class SubscriptionServiceTest
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
        public void TestSignUpWithValidEmailAddress()
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
        public void TestUnsubscribedEmail()
        {
            var email = Email.UnsubscribeEmail(_userEmail.Value);

            Assert.That(email, Is.InstanceOf<Email>());

            Assert.That(email.ToEmailAddress, Is.EqualTo(_userEmail.Value));
            Assert.That(email.Subject, Is.EqualTo("Endringer i abonnementet"));
            Assert.That(email.FromEmailAddress, Is.EqualTo("getnews@dummymail.com"));
            Assert.That(email.Body, Is.EqualTo($"Vi bekrefter at du har meldt deg av Nyhetsbrevet hos GET News.\n"));
        }

        [Test]
        public void TestNewSignUp()
        {
            var emailAddress = _userEmail.Value;
            var result = SubscriptionService.SignUp(emailAddress, null);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Email, Is.InstanceOf<Email>());
            Assert.That(result.Value.Subscription, Is.InstanceOf<Subscription>());
        }

        [Test]
        [TestCase("kake@gmail", TestName = "Invalid email address")]
        [TestCase("kakegmail.no", TestName = "Invalid email address")]
        public void TestSignUpInvalidEmailAddress(string userEmail)
        {
            var result = SubscriptionService.SignUp(userEmail, null);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(SignUpError.InvalidEmailAddress.ToString()));
        }

        [Test]
        public void TestSignUpAlreadySubscribed()
        {
            var emailAddress = _userEmail.Value;
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Verified);

            var result = SubscriptionService.SignUp(_userEmail.Value, subscription);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(SignUpError.AlreadySubscribed.ToString()));
        }

        [Test]
        public void TestSignUpUnsubscribed()
        {
            var emailAddress = _userEmail.Value;
            var subscription = new Subscription(emailAddress, SubscriptionStatus.Unsubscribed);

            var result = SubscriptionService.SignUp(emailAddress, subscription);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Email, Is.InstanceOf<Email>());
            Assert.That(result.Value.Subscription, Is.InstanceOf<Subscription>());
        }

        [TestCase(SubscriptionStatus.Verified, false)]
        public void TestSignUpWithExistingUnVerified(SubscriptionStatus status, bool isVerified)
        {
            var emailAddress = _userEmail.Value;
            var subscription = new Subscription(emailAddress, status, null, isVerified, lastStatusChange: new DateOnly(2025, 4, 1));

            var SignedUp = SubscriptionService.SignUp(subscription.EmailAddress, null);
            var SignedUp_1 = SubscriptionService.SignUp(subscription.EmailAddress, subscription);


            Assert.That(SignedUp.IsSuccess, Is.True);
            Assert.That(SignedUp_1.IsSuccess, Is.False);
            Assert.That(SignedUp_1.Error, Is.EqualTo(SignUpError.AlreadySubscribed.ToString()));
        }

        [TestCase(SubscriptionStatus.SignedUp, true)]
        [TestCase(SubscriptionStatus.SignedUp, false)]
        public void TestConfirmation(SubscriptionStatus status, bool isVerified)
        {
            var emailAddress = _userEmail.Value;
            var subscription = new Subscription(emailAddress, status, null, isVerified, lastStatusChange: new DateOnly(2025, 4, 1));

            var confirm = SubscriptionService.Confirm(emailAddress, subscription.VerificationCode, subscription);

            Assert.That(confirm.IsSuccess, Is.True);
            Assert.That(subscription.IsVerified, Is.True);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.Verified));
        }
        [TestCase(SubscriptionStatus.Verified, true)]
        [TestCase(SubscriptionStatus.SignedUp, true)]
        [TestCase(SubscriptionStatus.Verified, false)]
        
        public void TestInvalidConfirmation(SubscriptionStatus status, bool isVerified)
        {
            var fakeAddress = _fakeEmail.Value;
            var emailAddress = _userEmail.Value;
            var fakeAddress_1 = _fakeEmail_1.Value;

            var lastStatusUpdate = new DateOnly(2025, 4, 1);

            var subscription = new Subscription(emailAddress, status, null, isVerified, lastStatusUpdate);

            var confirm = SubscriptionService.Confirm(fakeAddress_1, subscription.VerificationCode, subscription);
            var confirm_1 = SubscriptionService.Confirm(subscription.EmailAddress, Guid.NewGuid(), subscription);
            var confirm_2 = SubscriptionService.Confirm(fakeAddress, subscription.VerificationCode, subscription);
            var confirm_3 = SubscriptionService.Confirm(subscription.EmailAddress, subscription.VerificationCode, subscription);

            Assert.That(confirm.IsSuccess, Is.False);
            Assert.That(confirm_1.IsSuccess, Is.False);
            Assert.That(confirm_2.IsSuccess, Is.False);
            Assert.That(confirm_3.IsSuccess, Is.False);

            Assert.That(confirm.Error, Is.EqualTo(SignUpError.InvalidEmailAddress.ToString()));  
            Assert.That(confirm_2.Error, Is.EqualTo(SignUpError.InvalidEmailAddress.ToString()));
            Assert.That(confirm_1.Error, Is.EqualTo(SignUpError.InvalidVertificationCode.ToString()));
            Assert.That(confirm_3.Error, Is.EqualTo(SignUpError.AlreadySubscribed.ToString()));
        }

        [TestCase(SubscriptionStatus.Verified, true)]

        public void TestUnsubscribed(SubscriptionStatus status, bool isVerified)
        {
            var subscription = new Subscription(_userEmail.Value, status, null, isVerified, lastStatusChange: new DateOnly(2025, 4, 1));

            SubscriptionService.Unsubscribe(subscription.EmailAddress, subscription);
            SubscriptionService.Unsubscribe(subscription.EmailAddress.ToLower(), subscription);
            SubscriptionService.Unsubscribe(subscription.EmailAddress.ToUpper(), subscription);

            Assert.That(subscription.IsVerified, Is.False);
            Assert.That(subscription.Status, Is.EqualTo(SubscriptionStatus.SignedUp));
        }
            
        [TestCase(SubscriptionStatus.SignedUp, true)]
        [TestCase(SubscriptionStatus.SignedUp, false)]
        [TestCase(SubscriptionStatus.Verified, false)]
        public void TestUnsubscribedWithError( SubscriptionStatus status, bool isVerified)
        {
            var userEmail = _userEmail.Value;
            var fakeEmail = _fakeEmail.Value;

            var subscription = new Subscription(userEmail, status, null, isVerified, lastStatusChange: new DateOnly(2025, 4, 1));
            var subscription_1 = new Subscription(fakeEmail, status, null, isVerified, lastStatusChange: new DateOnly(2025, 4, 1));
            
            var result = SubscriptionService.Unsubscribe(subscription_1.EmailAddress, subscription);
            var result_1 = SubscriptionService.Unsubscribe(subscription_1.EmailAddress, subscription_1); 
            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Error, Is.EqualTo(SignUpError.Unknown.ToString()).Or.EqualTo(SignUpError.InvalidEmailAddress.ToString()));
        }
        
    }
}