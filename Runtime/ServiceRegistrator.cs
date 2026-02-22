using System.Collections.Generic;
using System.Linq;
using MyPackage.Runtime.ServiceLocator_Core;
using UnityEngine;

namespace MyPackage.Runtime.Registrators
{
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
            
                    ServiceLocator.Register(serviceType, service);

                    var interfaces = serviceType.GetInterfaces()
                        .Where(i => typeof(IService).IsAssignableFrom(i) && i != typeof(IService));

                    foreach (var iface in interfaces)
                    {
                        ServiceLocator.Register(iface, service);
                    }
                }
            }
        }
    }
}