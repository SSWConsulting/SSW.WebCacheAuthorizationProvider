using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SSW.WebCacheAuthorizationProvider
{
    public class WebCacheAuthorizationProvider : IAuthorizationProvider
    {

        private const string CacheKeyPrefix = "WEBUSER_";

        private IAuthorizationProvider _baseProvider;
        private HttpContextBase _context;

        public WebCacheAuthorizationProvider(HttpContextBase context, IAuthorizationProvider baseProvider)
        {
            _context = context;
            _baseProvider = baseProvider;
        }

        private static string GetCacheKey(string name)
        {
            return CacheKeyPrefix + name;
        }

        public IPrincipal GetPrincipal(IIdentity identity)
        {
            var key = GetCacheKey(identity.Name);
            var user = GetOrStore(key, () => _baseProvider.GetPrincipal(identity));
            return user;
        }

        public static void RemoveCache(string userName)
        {
            var key = GetCacheKey(userName);
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Cache.Remove(key);
            }
        }
        
        private T GetOrStore<T>(string key, Func<T> generator)
        {
            var result = _context.Cache[key];
            if (result == null)
            {
                result = generator();
                _context.Cache[key] = result;
            }
            return (T)result;
        }
    }
}
