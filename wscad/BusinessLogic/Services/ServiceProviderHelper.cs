using System;

namespace wscad.BusinessLogic.Services
{
    public static class ServiceProviderHelper
    {
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}
