using System;
using System.Collections.Generic;

namespace SL
{
    public static class Locator
    {
        private static readonly Dictionary<Type, object> _services = new();
        
        public static IReadOnlyDictionary<Type, object> Services => _services;

        public static void Register(Type service, object instance)
        {
            _services.TryAdd(service, instance);
        }

        public static bool UnRegister(Type service)
        {
            return _services.Remove(service);
        }

        public static object Resolve<T>() where T : IService
        {
            return _services.GetValueOrDefault(typeof(T));
        }
    }
}