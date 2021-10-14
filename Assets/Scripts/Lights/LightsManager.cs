using System.Linq;
using UnityEngine;

namespace Lights
{
    public class LightsManager : MonoBehaviour
    {
        public static LightsManager Instance;

        [SerializeField] private float flickerDistance = 3f;
        [SerializeField] private Color flickerColor    = Color.red;

        private LightChanger[] adjustableLights;

        private void Awake()
        {
            if(Instance)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            adjustableLights = FindObjectsOfType<LightChanger>();
        }

        public void ChangeFlickerInZone(Vector3 position, bool flickering)
        {
            var lights = adjustableLights
                .Where(t => Vector3.Distance(t.transform.position, position) < flickerDistance);

            foreach(var light in lights)
                light.ChangeFlickering(flickering, flickerColor);
        }

        [ContextMenu("Demo Flicker")]
        private void DemoFlicker() 
            => ChangeFlickerInZone(transform.position, true);
    }
}