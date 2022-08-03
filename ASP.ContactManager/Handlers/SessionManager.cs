namespace ASP.ContactManager.Handlers
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor accessor)
        {
            _session = accessor.HttpContext.Session;
        }

        public int nbVue {
            get { return _session.GetInt32("nbVue") ?? 0; }
            set { _session.SetInt32("nbVue",value); }
        }
    }
}
