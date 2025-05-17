using SL;
using UnityEngine;

namespace Dependency
{
    public class CameraService : MonoBehaviour, IService
    {
        public void Foo()
        {
            Debug.Log("I`m a camera service");
        }
    }
}