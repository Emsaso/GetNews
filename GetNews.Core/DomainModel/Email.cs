//  Initializing the Confirmation Email

namespace GetNews.Core.DomainModel
{
   /*public class Email


    {
        public string Body { get; }
        public string Subject { get; }
        public string ToEmailAddress { get; }
        public string FromEmailAddress { get; }
       */

        public record Email (
            string FromEmailAddress,
            string ToEmailAddress,
            string Subject,
            string Body
            )
    {
        public static Email CreateConfirmEmail(string userEmail, Guid code)
        {
            return new Email(
                "getnews@dummymail.com",
                userEmail,
                "Bekreft abonnement på GET News",
                $"Kode: {code}");
        }

        public static Email UnsubscribeEmail(string userEmail)
        {
            return new Email(
                "getnews@dummymail.com",
                userEmail,
                "Endringer i abonnementet",
                "Vi bekrefter at du har meldt deg av Nyhetsbrevet hos GET News.\n"
                );
        }
    }
}
