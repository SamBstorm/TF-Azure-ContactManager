using BLL.ContactManager.Entities;
using System.Text.Json;

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


        public User? CurrentUser
        {
            get { return JsonSerializer.Deserialize<User>(_session.GetString(nameof(CurrentUser))??"null"); }
            set { _session.SetString(nameof(CurrentUser), JsonSerializer.Serialize(value)); }
        }
    }
}
