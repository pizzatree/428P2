using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPour : MonoBehaviour
{
    ParticleSystem waterParticle;
    // Start is called before the first frame update
    void Start()
    {
        waterParticle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Angle(Vector3.down, transform.forward) <= 90f){
            waterParticle.Play();
        }
        else {
            waterParticle.Stop();
        }
    }
}
