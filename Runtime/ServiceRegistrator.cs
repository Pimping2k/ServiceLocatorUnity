using System.Collections.Generic;
using System.Linq;
using MyPackage.Runtime.ServiceLocator_Core;
using UnityEngine;

namespace MyPackage.Runtime.Registrators
{
    [DefaultExecutionOrder(-400)]
    public class ServiceRegistrator : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> _instances = new();

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            InitializeServices();
        }

        private void Start()
        {
            foreach (var kvp in ServiceLocator.Services)
            {
                Debug.Log($"Service type: {kvp.Key.Name}");
            }
        }

        private void InitializeServices()
        {
            foreach (var instance in _instances)
            {
                if (instance is IService service)
                {
                    var serviceType = service.GetType();
                    var interfaces = serviceType.GetInterfaces()
                        .Where(i => typeof(IService).IsAssignableFrom(i) && i != typeof(IService))
                        .ToList();

                    if (interfaces.Count > 0)
                    {
                        foreach (var iface in interfaces)
                        {
                            ServiceLocator.Register(iface, service);
                        }
                    }
                    else
                    {
                        ServiceLocator.Register(serviceType, service);
                    }
                }
            }
        }
    }
}