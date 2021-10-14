using UnityEngine;

namespace Scene_Utils
{
    public class Spinner : MonoBehaviour
    {
        [SerializeField] 
        private Vector3 spinRatePerAxis = Vector3.zero;

        private void Update()
        {
            var amount = spinRatePerAxis * Time.deltaTime;
            transform.Rotate(amount);
        }
    }
}