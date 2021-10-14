using UnityEngine;

namespace Scene_Utils
{
    public class TextMeshTimeUpdater : MonoBehaviour
    {
        private TextMesh timeTextObject;

        private void Start()
        {
            timeTextObject = GetComponent<TextMesh>();
            InvokeRepeating(nameof(UpdateTime), 0f, 10f);
        }

        private void UpdateTime()
        {
            timeTextObject.text = System.DateTime.Now.ToString("h:mm tt");
        }
    }
}