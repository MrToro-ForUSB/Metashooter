using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droni : MonoBehaviour
{
    [SerializeField] List<ParticleSystem> particles;
    public void PlayFall(Collision collision)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.useGravity = true;
            rigidbody.velocity = collision.relativeVelocity * 20;
            
            foreach (ParticleSystem particle in particles)
            {
                particle.Play();
            }
            Destroy(this);
        }
    }
}
