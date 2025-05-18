using System.Collections.Generic;
using System.Linq;
using SL;
using UnityEngine;
using UnityEngine.Serialization;

namespace Registrators
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
            foreach (var kvp in Locator.Services)
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
                    var interfaces = service.GetType().GetInterfaces()
                        .Where(i => typeof(IService).IsAssignableFrom(i) && i != typeof(IService));

                    foreach (var iface in interfaces)
                    {
                        Locator.Register(iface, service);
                    }
                }
            }
        }
    }
}