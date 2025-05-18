using System;
using Dependency;
using SL;
using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        private ICameraService _cameraService;

        private void Start()
        {
            _cameraService = Locator.Resolve<ICameraService>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.K))
                _cameraService.Foo();
        }
    }
}