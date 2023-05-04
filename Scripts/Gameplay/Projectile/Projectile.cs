using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speedMult = 3;
    [SerializeField] Vector3 targetScale;
    [SerializeField] ProjectileType projectileType;
    void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speedMult);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collisionable"))
        {
            if (collision.gameObject.TryGetComponent(out Droni droni))
            {
                droni.PlayFall(collision);
                transform.SetParent(droni.transform);
            }
            
            gameObject.AddComponent<ProjectileShrink>().PlaySparks(projectileType);
            Destroy(GetComponent<Collider>());
            Destroy(this);
        }
        
    }
}
