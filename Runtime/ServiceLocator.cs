using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyPackage.Runtime.ServiceLocator_Core
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();
        
        public static IReadOnlyDictionary<Type, object> Services => _services;

        public static void Register(Type type, object instance)
        {
            if (_services.TryAdd(type, instance))
            {
                Debug.Log($"[ServiceLocator] Registered: {type.Name}");
            }
            else
            {
                _services[type] = instance;
                Debug.LogWarning($"[ServiceLocator] Service {type.Name} was overwritten.");
            }
        }

        public static void Register<T>(T instance) where T : class
        {
            Register(typeof(T), instance);
        }
        
        public static bool UnRegister(Type service)
        {
            return _services.Remove(service);
        }

        public static T Resolve<T>() where T : class
        {
            if (_services.TryGetValue(typeof(T), out var instance))
                return (T)instance;

            Debug.LogError($"[ServiceLocator] Service of type {typeof(T).Name} not found!");
            return null;
        }

        public static bool TryGetService<T>(out T instance) where T : class
        {
            if (_services.TryGetValue(typeof(T), out var obj))
            {
                instance = (T)obj;
                return true;
            }
            
            instance = null;
            return false;
        }

        public static void Clear()
        {
            _services.Clear();
        }
    }
}