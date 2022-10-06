using Environment;
using UnityEngine;

namespace Infrastructure
{
    [DefaultExecutionOrder(-100)]
    public class SceneEntryPoint : MonoBehaviour
    {
        public Location Location;
        
        private void Awake()
        {
            Services.Set(Location);
        }
    }
}