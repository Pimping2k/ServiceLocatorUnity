using System;
using System.Collections.Generic;

namespace SL
{
    public static class CustomServiceLocator
    {
        private static readonly Dictionary<Type, object> services = new();

        public static void Register(Type service, object instance)
        {
            services.TryAdd(service, instance);
        }
        
        public static void Resolve<T>() where T is IService
        {
            
        }
    }
}