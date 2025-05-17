using System;
using System.Collections.Generic;
using System.Linq;

namespace SL
{
    public static class Locator
    {
        private static readonly Dictionary<Type, object> _services = new();
        
        public static IReadOnlyDictionary<Type, object> Services => _services;

        public static void Register<T>(T instance) where T : IService
        {
            var type = instance.GetType();
            _services[type] = instance;
        }

        public static bool UnRegister(Type service)
        {
            return _services.Remove(service);
        }

        public static T Resolve<T>() where T : IService
        {
            return _services.TryGetValue(typeof(T), out var instance) ? (T)instance : default;
        }

        public static bool TryGetService<T>(out object instance) where T : IService
        {
            if (_services.TryGetValue(typeof(T), out instance))
                return true;
            
            return false;
        }
    }
}