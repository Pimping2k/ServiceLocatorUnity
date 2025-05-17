using System;
using System.Collections.Generic;
using System.Linq;
using Dependency;
using SL;
using UnityEngine;

namespace DefaultNamespace
{
    public class ServiceRegistrator : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> instances = new();
        private List<IService> _services = new();

        private CameraService _test;
        
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
            
            _test = Locator.Resolve<CameraService>();
        }

        private void InitializeServices()
        {
            _services = instances.OfType<IService>().ToList();
            
            foreach (var service in _services)
            {
                Locator.Register<IService>(service);
            }
        }
    }
}