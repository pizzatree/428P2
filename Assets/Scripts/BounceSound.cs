using UnityEngine;

public class BounceSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!(collision.relativeVelocity.magnitude > 0.5))
            return;

        if(!audioSource.isPlaying)
            audioSource.Play();
    }
}