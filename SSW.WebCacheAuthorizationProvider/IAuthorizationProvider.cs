using System.Security.Principal;

namespace SSW.WebCacheAuthorizationProvider
{
    public interface IAuthorizationProvider
    {
        /// <summary>
        ///     Get an IPrincipal object
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        IPrincipal GetPrincipal(IIdentity identity);
    }
}