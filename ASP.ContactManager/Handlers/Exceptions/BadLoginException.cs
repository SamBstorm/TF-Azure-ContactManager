namespace ASP.ContactManager.Handlers.Exceptions
{
    public class BadLoginException : Exception
    {
        public BadLoginException() : base("Identifiant ou mot de passe incorrect.")
        {

        }
    }
}
