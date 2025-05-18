using Dependency;
using UnityEngine;

namespace Gameplay
{
    public class CameraManager : MonoBehaviour, ICameraService
    {
        public void Foo()
        {
            Debug.Log("I`m working");
        }
    }
}