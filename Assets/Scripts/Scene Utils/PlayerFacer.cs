using System.Collections.Generic;
using UnityEngine;

namespace Scene_Utils
{
    public class PlayerFacer : MonoBehaviour
    {
        private List<Transform> transforms;
        private Transform       player;
    
        private void Start()
        {
            player     = Camera.main.transform;
            transforms = new List<Transform>();

            var gameObjects = GameObject.FindGameObjectsWithTag("RotatingUIElement");
            foreach(var go in gameObjects)
                transforms.Add(go.transform);
        }

        private void LateUpdate()
        {
            foreach(var t in transforms)
                t.LookAt(player);
        }
    }
}
