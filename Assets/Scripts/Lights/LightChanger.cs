using UnityEngine;

namespace Lights
{
    public class LightChanger : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 5f)]   private float flickerSpeed = 2.5f;
        [SerializeField, Range(0f,   0.8f)] private float lightCutoff  = 0.35f;

        private bool  flickering;
        private float startIntensity;
        private Color defaultColor;

        private Vector2 noiseOffset;

        private new Light light;
    
        private void Start()
        {
            light          = GetComponent<Light>();
            defaultColor   = light.color;
            startIntensity = light.intensity;

            noiseOffset = new Vector2(Random.value, Random.value);
        }

        private void Update()
        {
            if(!flickering)
                return;

            var pos = Time.time * flickerSpeed;
            light.intensity = (Mathf.PerlinNoise(pos + noiseOffset.x, pos + noiseOffset.y) - lightCutoff) * startIntensity;
        }

        [ContextMenu("Demo Flicker")]
        private void DemoFlicker()
            => ChangeFlickering(true, Color.red);
    
        public void ChangeFlickering(bool flicker, Color color = new Color())
        {
            flickering  = flicker;
            light.color = color;

            if(flickering)
                return;

            light.intensity = startIntensity;
            light.color     = defaultColor;
        }
    }
}